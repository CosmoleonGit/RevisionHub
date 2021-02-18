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

        const int timeout = 10000;

        public override bool Setup()
        {
            WaitingForm.BeginWait("Connecting to host...", () => 
            {
                while (!client.Connected)
                {
                    try
                    {
                        client.Connect(ip, port);
                    } catch
                    {
                        if (MsgBox.ShowWait($"Could not connect to server." +
                                        $"{Helper.twoLines}" +
                                        $"Would you like to try again?",
                                        "Connection timeout.",
                                        MsgBox.Options.yesNo,
                                        MsgBox.MsgIcon.ERROR) == "No")
                        {
                            break;
                        }
                    }
                }
            });

            if (!client.Connected) return false;

            socket = client.Client;
            stream = client.GetStream();

            return true;
        }
        public override void Finish()
        {
            base.Finish();
            client.Close();
        }

        protected override string WriteDirectory => "C:/Users/Compaq/Desktop/Client Test/";
    }
}
