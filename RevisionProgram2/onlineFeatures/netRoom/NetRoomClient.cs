using RevisionProgram2.dialogs;
using RevisionProgram2.onlineFeatures;
using RevisionProgram2.onlineFeatures.netRoom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.netRoom
{
    public class NetRoomClient : NetRoomPeer
    {
        public static void Begin(string username, string ip, int port)
        {
            var client = new TcpClient();

            if (!ClientConnect.Attempt(client, ip, port)) return;

            CurrentRoom = new NetRoomClient(username, client);
        }

        public NetRoomClient(string username, TcpClient _client) : base(username)
        {
            client = _client;
            stream = client.GetStream();

            //stream.WriteByte(0);
            stream.SendString(username);

            Begin();
        }

        readonly TcpClient client;
        readonly NetworkStream stream;

        protected override void AddEvents(ChatRoom room)
        {
            room.GetWorker.DoWork += GetWorker_DoWork;
            room.FormClosing += Room_FormClosing;

            room.MessageSent += Room_MessageSent;
        }

        private void Room_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }

        private void GetWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                byte[] buffer = new byte[client.ReceiveBufferSize];
                
                if (stream.Read(buffer, 0, buffer.Length) > 0)
                {
                    string s = Encoding.ASCII.GetString(buffer);

                    var msgType = (ServerMessageType)byte.Parse(s[0].ToString());
                    var msg     = s.Substring(1, s.Length - 1);

                    switch (msgType)
                    {
                        case ServerMessageType.MESSAGE:
                            room.ReceiveMessage(msg);
                            break;
                        case ServerMessageType.CONNECTED:
                            room.ReceiveMessage($"{msg} has joined.");
                            break;
                    }
                }
            }
        }

        private void Room_MessageSent(string message)
        {
            stream.SendString(message);
        }
    }
}
