using RevisionProgram2.onlineFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class ServerWait : Form
    {
        readonly TcpListener server;

        readonly List<ClientMember> members;

        public ServerWait(int port)
        {
            server = new TcpListener(IPAddress.Any, port);

            InitializeComponent();
        }

        bool finished;

        void AddMember(ClientMember member)
        {
            MemberList.Items.Add(member.name);
            members.Add(member);
        }

        private void ServerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (server.Pending())
                {
                    ThreadPool.QueueUserWorkItem(AuthenticateUser, server.AcceptTcpClient());
                }
            }
        }

        private void AuthenticateUser(object state)
        {
            var client = (TcpClient)state;
            var stream = client.GetStream();
            
            while (!stream.DataAvailable && !finished) { }

            string username = stream.ReadString(client.ReceiveBufferSize);

            if (!finished)
            {
                Invoke((MethodInvoker)delegate 
                {
                    AddMember(new ClientMember(username, stream));
                });
            }
        }

        private void BeginBtn_Click(object sender, EventArgs e)
        {
            finished = true;

            members.ForEach(x => x.stream.WriteByte(0));
        }

        private void ServerWait_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
