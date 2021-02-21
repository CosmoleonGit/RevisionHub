#define OFFLINE

using RevisionProgram2.dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.folderSync
{
    public class ClientSync : OnlineSync
    {
        readonly TcpClient client;

        readonly string ip;
        readonly int port;

        public override bool PushFirst => false;

        public ClientSync(string _ip, int _port)
        {
            client = new TcpClient();

            ip = _ip;
            port = _port;
        }

        public override bool Setup()
        {
            bool closed = false;
            WaitingForm.BeginWait("Connecting to host...", ev => 
            {
                while (!client.Connected)
                {
                    try
                    {
                        client.Connect(ip, port);
                    } catch
                    {
                        if (closed || !ConnectionFailure())
                        {
                            break;
                        }
                    }
                }
            }, () =>
            {
                closed = true;
                client.Close();
                return true;
            });
            
            if (closed || !client.Connected) return false;

            socket = client.Client;
            stream = client.GetStream();

            stream.ReadTimeout = timeout;

            return true;
        }

        public override void Finish()
        {
            base.Finish();
            client.Close();
        }

#if OFFLINE && DEBUG
        protected override string WriteDirectory => $"C:/Users/{Environment.UserName}/Desktop/Client Test/";
#endif
    }
}
