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
    public class ServerSync : OnlineSync
    {
        readonly TcpListener server;

        public ServerSync(int port)
        {
            server = new TcpListener(IPAddress.Any, port);
        }

        public override bool Setup()
        {
            server.Start();

            TcpClient client = null;
            WaitingForm.BeginWait("Waiting for client to connect...", () => client = server.AcceptTcpClient());

            socket = client.Client;
            stream = client.GetStream();
            
            return true;
        }

        public override void Finish()
        {
            base.Finish();
            server.Stop();
        }
    }
}
