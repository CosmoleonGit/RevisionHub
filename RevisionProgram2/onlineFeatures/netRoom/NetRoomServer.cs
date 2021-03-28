using RevisionProgram2.onlineFeatures;
using RevisionProgram2.onlineFeatures.netRoom;
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

namespace RevisionProgram2.netRoom
{
    enum ServerMessageType
    {
        MESSAGE,
        CONNECTED,
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
            username = _username;
            server = _server;

            members = new ConcurrentBag<ClientMember>();
            //joinQueue = new ConcurrentQueue<ClientMember>();

            server.Start();
            ThreadPool.QueueUserWorkItem(AcceptIncomingConnections);

            Begin();
        }

        private void AcceptIncomingConnections(object state)
        {
            while (true)
            {
                var client = server.AcceptTcpClient();

                ThreadPool.QueueUserWorkItem(AuthenticateClient, client);
            }
        }

        private void AuthenticateClient(object state)
        {
            var client = (TcpClient)state;
            var stream = client.GetStream();

            string username;

            try
            {
                username = stream.WaitForString(client.ReceiveBufferSize);
            }
            catch (IOException)
            {
                client.Close();
                stream.Close();
                return;
            }

            var member = new ClientMember(username, stream);

            Broadcast(x =>
            {
                x.stream.SendString($"{(byte)ServerMessageType.CONNECTED}{username}");
            });

            members.Add(member);

            ThreadPool.QueueUserWorkItem(WorkClient, member);
        }

        private void WorkClient(object state)
        {
            var member = (ClientMember)state;

            while (true)
            {
                try
                {
                    byte[] buffer = new byte[server.Server.ReceiveBufferSize];

                    if (member.stream.Read(buffer, 0, buffer.Length) > 0)
                    {
                        string msg = Encoding.ASCII.GetString(buffer);
                        string chatMsg = $"({member.name}) {msg}";
                        room.ReceiveMessage(chatMsg);

                        Broadcast(x =>
                        {
                            if (x != member)
                            {
                                x.stream.SendString($"{(byte)ServerMessageType.MESSAGE}{chatMsg}");
                            }
                        });
                    }
                }
                catch (ObjectDisposedException) { break; }
                catch (Exception ex)
                {
                    Helper.Error("An error occured.", ex.Message);
                    room.Close();
                    break;
                }
            }
        }

        readonly string username;
        readonly TcpListener server;

        readonly ConcurrentBag<ClientMember> members;
        //readonly ConcurrentQueue<ClientMember> joinQueue;

        protected override void AddEvents(ChatRoom room)
        {
            //room.GetWorker.DoWork += GetWorker_DoWork;
            room.FormClosing += Room_FormClosing;

            room.MessageSent += Room_MessageSent;
        }

        private void Room_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var member in members)
                member.stream.Close();
            server.Stop();
        }

        private void GetWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    foreach (var member in members)
                    {
                        byte[] buffer = new byte[server.Server.ReceiveBufferSize];

                        if (member.stream.Read(buffer, 0, buffer.Length) > 0)
                        {
                            string msg = Encoding.ASCII.GetString(buffer);
                            string chatMsg = $"({member.name}) {msg}";
                            room.ReceiveMessage(chatMsg);

                            Broadcast(x =>
                            {
                                if (x != member)
                                {
                                    x.stream.SendString($"{(byte)ServerMessageType.MESSAGE}{chatMsg}");
                                }
                            });
                        }
                    }
                }
                catch (ObjectDisposedException) { break; }
                catch (Exception ex)
                {
                    Helper.Error("An error occured.", ex.Message);
                    room.Close();
                    break;
                }
            }
        }

        private void Room_MessageSent(string message)
        {
            Broadcast(x => x.stream.SendString($"{(byte)ServerMessageType.MESSAGE}({username}) {message}"));
        }

        private void Broadcast(Action<ClientMember> action)
        {
            foreach (var member in members)
            {
                try
                {
                    action(member);
                } catch (IOException)
                {

                }
            }
        }
    }
}
