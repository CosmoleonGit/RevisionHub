using RevisionProgram2.dialogs;
using RevisionProgram2.onlineFeatures;
using RevisionProgram2.onlineFeatures.netRoom;
using RevisionProgram2.revision.assessments.tests;
using System;
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
    public enum ClientMessageType
    {
        MESSAGE,
        DISCONNECTED,
        CHALLENGE_ACCEPTED,
        CHALLENGE_DECLINED,
        READY_FOR_DATA,
        RESULTS
    }

    public class NetRoomClient : NetRoomPeer
    {
        public static void Begin(string username, string ip, int port)
        {
            var client = new TcpClient();

            if (!ClientConnect.Attempt(client, ip, port)) return;

            var netRoomClient = new NetRoomClient(username, client);

            try
            {
                netRoomClient.Setup();
            }
            catch (Exception e)
            {
                Helper.Error("Failed to start client.", e.Message);
                return;
            }

            CurrentRoom = netRoomClient;
        }

        public NetRoomClient(string username, TcpClient _client) : base(username)
        {
            client = _client;
            stream = client.GetStream();
        }

        void Setup()
        {
            stream.SendString(username);

            var membersToAdd = new Queue<string>();

            byte[] buffer = new byte[client.ReceiveBufferSize];
            int l = 0;
            while (true)
            {
                Array.Clear(buffer, 0, buffer.Length);

                if ((l = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (buffer[0] == 1) break;

                    var name = Encoding.ASCII.GetString(buffer, 1, buffer.Length - 1)
                                                        .Replace("\0", string.Empty);

                    membersToAdd.Enqueue(name);

                    if (hostName == null)
                        hostName = name;

                    stream.WriteByte(0);
                }
            }

            //stream.WriteByte(0);

            ThreadPool.QueueUserWorkItem(WorkClient);

            Begin();

            while (membersToAdd.Any())
                room.AddMember(membersToAdd.Dequeue(), true);
        }

        string hostName = null;

        FileStream challengeStream;

        private void WorkClient(object state)
        {
            byte[] buffer = new byte[client.ReceiveBufferSize];

            while (!Closed)
            {
                Array.Clear(buffer, 0, buffer.Length);

                try
                {
                    if (stream.Read(buffer, 0, buffer.Length) > 0)
                    {
                        var msgType = (ServerMessageType)buffer[0];
                        
                        string GetString() => Encoding.ASCII.GetString(buffer, 1, buffer.Length - 1)
                                                            .Replace("\0", string.Empty);

                        switch (msgType)
                        {
                            case ServerMessageType.MESSAGE:
                                room.ReceiveMessage(GetString());
                                break;
                            case ServerMessageType.CONNECTED:
                                room.AddMember(GetString());
                                break;
                            case ServerMessageType.DISCONNECTED:
                                room.RemoveMember(GetString());
                                break;
                            case ServerMessageType.SERVER_STOP:
                                if (!Closed) room.Close();
                                MsgBox.ShowWait("The connection has been lost.",
                                                "Client",
                                                null,
                                                MsgBox.MsgIcon.INFO);
                                break;
                            case ServerMessageType.REQUEST_CHALLENGE:
                                string s = GetString();
                                ChallengeName = s;
                                room.ReceiveChallenge(hostName, s);

                                break;
                            case ServerMessageType.DECLINE_CHALLENGE:
                                room.HideChallenge();
                                room.ReceiveMessage($"{GetString()} has declined the challenge.");
                                break;
                            case ServerMessageType.SEND_TEST_DATA:
                                ResetChallenge();

                                if (challengeStream == null)
                                    challengeStream = File.OpenWrite($"{ChallengePath}{ChallengeName}");

                                challengeStream.Write(buffer, 1, buffer.Length - 1);

                                SendBlankMsg(ClientMessageType.READY_FOR_DATA);

                                break;
                            case ServerMessageType.BEGIN_TEST:
                                challengeStream.Dispose();
                                challengeStream = null;

                                room.Invoke((MethodInvoker)delegate ()
                                {
                                    BeginTest();
                                });
                                    
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!Closed)
                    {
                        room.Invoke((MethodInvoker)delegate ()
                        {
                            room.Close();
                        });

                        Helper.Error("An error occured.", ex.Message);

                        break;
                    }
                }
            }
        }

        public void SendBlankMsg(ClientMessageType type)
        {
            stream.Write(new[] { (byte)type }, 0, 1);
        }

        public void SendBytes(ClientMessageType type, byte[] msg)
        {
            byte[] buffer = new byte[msg.Length + 1];
            buffer[0] = (byte)type;
            msg.CopyTo(buffer, 1);

            stream.Write(buffer, 0, buffer.Length);
        }

        public void SendString(ClientMessageType type, string msg)
        {
            SendBytes(type, Encoding.ASCII.GetBytes(msg));
        }

        public override void Challenge(string path)
        {
            MsgBox.ShowWait("This feature hasn't been implemented yet.",
                            "Challenge",
                            null,
                            MsgBox.MsgIcon.EXCL);
        }

        readonly TcpClient client;
        readonly NetworkStream stream;

        protected override void AddEvents(ChatRoom room)
        {
            room.FormClosing += Room_FormClosing;

            room.MessageSent += Room_MessageSent;

            room.AcceptedChallenge += Room_AcceptedChallenge;

            room.DeclinedChallenge += Room_DeclinedChallenge;
        }

        private void Room_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SendBlankMsg(ClientMessageType.DISCONNECTED);
            }
            finally
            {
                if (challengeStream != null)
                {
                    challengeStream.Dispose();
                    File.Delete($"{ChallengePath}{ChallengeName}");
                }

                client.Close();
                stream.Close();
            }
        }

        private void Room_AcceptedChallenge()
        {
            SendBlankMsg(ClientMessageType.CHALLENGE_ACCEPTED);
        }

        private void Room_DeclinedChallenge()
        {
            SendBlankMsg(ClientMessageType.CHALLENGE_DECLINED);
        }

        private void Room_MessageSent(string message)
        {
            SendString(ClientMessageType.MESSAGE, message);
        }

        protected override void OnResults(TestResults results)
        {
            var buffer = new byte[8];
            BitConverter.GetBytes(results.Correct.Count()).CopyTo(buffer, 0);
            BitConverter.GetBytes(results.All.Count()).CopyTo(buffer, 4);

            SendBytes(ClientMessageType.RESULTS, buffer);
        }

        protected override void OnTestFinish()
        {
            if (MsgBox.ShowWait($"Do you want to keep {ChallengeName}?",
                                "Keep Test",
                                MsgBox.Options.yesNo,
                                MsgBox.MsgIcon.INFO) == "Yes")
            {
                Directory.CreateDirectory($"{Helper.LocalDirectory}Saved Tests");

                string writeTo = $"{Helper.LocalDirectory}Saved Tests/{ChallengeName}";

                if (File.Exists(writeTo) && MsgBox.ShowWait($"There is already a file named {ChallengeName}." +
                                                            $"Do you want to overwrite it?",
                                                            "Overwrite",
                                                            MsgBox.Options.yesNo,
                                                            MsgBox.MsgIcon.INFO) == "No")
                {
                    goto delete;
                }

                File.Delete(writeTo);
                File.Move($"{ChallengePath}{ChallengeName}", writeTo);
            }

        delete:
            File.Delete($"{ChallengePath}{ChallengeName}");
        }
    }
}
