using RevisionProgram2.dialogs;
using RevisionProgram2.onlineFeatures;
using RevisionProgram2.onlineFeatures.netRoom;
using RevisionProgram2.revision.assessments.tests;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.onlineFeatures.netRoom
{
    public enum ServerMessageType
    {
        MESSAGE,
        CONNECTED,
        DISCONNECTED,
        SERVER_STOP,
        REQUEST_CHALLENGE,
        DECLINE_CHALLENGE,
        SEND_TEST_DATA,
        BEGIN_TEST
    }

    public class NetRoomServer : NetRoomPeer
    {
        public static void Begin(string username, int port)
        {
            var listener = new TcpListener(IPAddress.Any, port);

            CurrentRoom = new NetRoomServer(username, listener);
        }

        public NetRoomServer(string _username, TcpListener _server) : base(_username)
        {
            server = _server;

            members = new List<ClientMember>();
            //joinQueue = new ConcurrentQueue<ClientMember>();

            server.Start();
            ThreadPool.QueueUserWorkItem(AcceptIncomingConnections);

            room.Text = "Chat Room - Server";

            Begin();
        }

        private void AcceptIncomingConnections(object state)
        {
            while (true)
            {
                TcpClient client;

                try
                {
                    client = server.AcceptTcpClient();
                } catch
                {
                    break;
                }

                ThreadPool.QueueUserWorkItem(AuthenticateClient, client);
            }
        }

        private void AuthenticateClient(object state)
        {
            var client = (TcpClient)state;
            var stream = client.GetStream();

            string clientName;

            try
            {
                clientName = stream.WaitForString(client.ReceiveBufferSize);

                byte[] buffer;
                byte[] serializedName;

                serializedName = Encoding.ASCII.GetBytes(username);
                buffer = new byte[serializedName.Length + 1];
                serializedName.CopyTo(buffer, 1);

                stream.Write(buffer, 0, buffer.Length);
                stream.WaitForResponse();
                
                foreach (var member in members)
                {
                    serializedName = Encoding.ASCII.GetBytes(member.name);
                    buffer = new byte[serializedName.Length + 1];
                    serializedName.CopyTo(buffer, 1);

                    stream.Write(buffer, 0, buffer.Length);
                    stream.WaitForResponse();
                }

                stream.WriteByte(1);
                //stream.WaitForResponse();
            }
            catch (IOException)
            {
                client.Close();
                stream.Close();
                return;
            }

            var newMember = new ClientMember(clientName, stream);

            Broadcast(x =>
            {
                x.SendString(ServerMessageType.CONNECTED, clientName);
            });

            room.AddMember(newMember.name);

            lock (members)
            {
                members.Add(newMember);
            }

            ThreadPool.QueueUserWorkItem(WorkClient, newMember);
        }

        FileStream challengeStream;

        //bool challenging;

        private void WorkClient(object state)
        {
            var member = (ClientMember)state;

            byte[] buffer = new byte[server.Server.ReceiveBufferSize];

            while (!Closed)
            {
                try
                {
                    Array.Clear(buffer, 0, buffer.Length);

                    if (member.Read(buffer, 0, buffer.Length) > 0)
                    {
                        var msgType = (ClientMessageType)buffer[0];

                        switch (msgType)
                        {
                            case ClientMessageType.MESSAGE:
                                string msg = Encoding.ASCII.GetString(buffer, 1, buffer.Length - 1)
                                                                     .Replace("\0", string.Empty);

                                string chatMsg = $"({member.name}) {msg}";
                                room.ReceiveMessage(chatMsg);

                                Broadcast(x =>
                                {
                                    if (x != member)
                                    {
                                        x.SendString(ServerMessageType.MESSAGE, chatMsg);
                                    }
                                });
                                break;
                            case ClientMessageType.DISCONNECTED:
                                member.Stop();
                                break;
                            case ClientMessageType.CHALLENGE_ACCEPTED:
                                string acceptMsg = $"{member.name} has accepted the challenge.";
                                room.ReceiveMessage(acceptMsg);

                                Broadcast(x =>
                                {
                                    x.SendString(ServerMessageType.MESSAGE, acceptMsg);
                                    x.ChallengeState = ChallengeState.ACCEPTED;
                                });

                                if (members.TrueForAll(x => x.ChallengeState == ChallengeState.ACCEPTED))
                                {
                                    challengeStream = File.OpenRead(ChallengePath);

                                    ThreadPool.QueueUserWorkItem(SendFileData);
                                }

                                break;
                            case ClientMessageType.CHALLENGE_DECLINED:
                                room.ReceiveMessage($"{member.name} has declined the challenge.");

                                Broadcast(x =>
                                {
                                    x.ChallengeState = ChallengeState.DECIDING;
                                    x.SendString(ServerMessageType.DECLINE_CHALLENGE, member.name);
                                });

                                break;
                            case ClientMessageType.READY_FOR_DATA:
                                member.ChallengeState = ChallengeState.PENDING_DATA;

                                if (members.TrueForAll(x => x.ChallengeState == ChallengeState.PENDING_DATA))
                                {
                                    ThreadPool.QueueUserWorkItem(SendFileData);
                                }

                                break;
                            case ClientMessageType.RESULTS:
                                int correct = BitConverter.ToInt32(buffer, 1);
                                int all = BitConverter.ToInt32(buffer, 5);

                                string resultsMsg = ResultsMessage(member.name, correct, all);

                                room.ReceiveMessage(resultsMsg);

                                Broadcast(x =>
                                {
                                    x.SendString(ServerMessageType.MESSAGE, resultsMsg);
                                });

                                break;
                        }

                        
                    }
                }
                catch (ObjectDisposedException) { break; }
                catch (Exception ex)
                {
                    if (!Closed)
                        room.Invoke((MethodInvoker)delegate ()
                        {
                            room.Close();
                        });

                    Helper.Error("An error occured.", ex.Message);
                    
                    break;
                }

                if (member.Finished)
                {
                    if (!Closed) room.RemoveMember(member.name);

                    lock (members)
                    {
                        members.Remove(member);
                    }

                    Broadcast(x => x.SendString(ServerMessageType.DISCONNECTED, member.name));

                    return;
                }
            }
        }

        private void SendFileData(object state)
        {
            byte[] fileBuffer = new byte[2047];
            if (challengeStream.Read(fileBuffer, 0, fileBuffer.Length) > 0)
            {
                Broadcast(x =>
                {
                    x.ChallengeState = ChallengeState.READING_DATA;

                    x.SendBytes(ServerMessageType.SEND_TEST_DATA, fileBuffer);
                });
            } else
            {
                challengeStream.Dispose();
                challengeStream = null;

                Broadcast(x =>
                {
                    x.ChallengeState = ChallengeState.DECIDING;
                    x.SendBlankMsg(ServerMessageType.BEGIN_TEST);
                });

                room.HideChallenge();

                room.Invoke((MethodInvoker)delegate ()
                {
                    BeginTest();
                });
            }
        }

        private void CloseServer()
        {
            if (challengeStream != null)
                challengeStream.Dispose();

            lock (members)
            {
                Broadcast(x =>
                {
                    x.SendBlankMsg(ServerMessageType.SERVER_STOP);
                    x.stream.Close();
                });

                server.Stop();
            }
        }

        readonly TcpListener server;
        
        readonly List<ClientMember> members;

        protected override void AddEvents(ChatRoom room)
        {
            room.FormClosing += Room_FormClosing;

            room.MessageSent += Room_MessageSent;

            room.DeclinedChallenge += Room_DeclinedChallenge;
        }

        private void Room_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseServer();
        }

        private void Room_DeclinedChallenge()
        {
            room.ReceiveMessage($"{username} has declined the challenge.");

            Broadcast(x =>
            {
                x.ChallengeState = ChallengeState.DECIDING;
                x.SendString(ServerMessageType.DECLINE_CHALLENGE, username);
            });
        }

        private void Room_MessageSent(string message)
        {
            Broadcast(x => x.SendString(ServerMessageType.MESSAGE, $"({username}) {message}"));
        }

        private void Broadcast(Action<ClientMember> action)
        {
            lock (members)
            {
                foreach (var member in members)
                {
                    if (!member.Finished)
                        action(member);
                }
            }
        }

        public override void Challenge(string path)
        {
            room.BeginChallenge(username, Path.GetFileName(path));
            room.Focus();

            bool anyMembers;

            lock (members)
            {
                anyMembers = members.Any();
            }

            if (anyMembers)
            {
                Broadcast(x =>
                {
                    x.SendString(ServerMessageType.REQUEST_CHALLENGE, Path.GetFileName(path));
                });

                base.Challenge(path);
            }
            else
            {
                MsgBox.ShowWait("There must be at least one person connected to challenge.",
                                "Challenge",
                                null,
                                MsgBox.MsgIcon.EXCL);
            }
        }



        protected override void OnResults(TestResults results)
        {
            string msg = ResultsMessage(username, results.Correct.Count(), results.All.Count());

            Broadcast(x =>
            {
                x.SendString(ServerMessageType.MESSAGE, msg);
            });

            room.ReceiveMessage(msg);
        }

        string ResultsMessage(string player, int correct, int total) =>
            $"{player} scored {correct} out of {total}.";
    }
}
