using RevisionProgram2.onlineFeatures.netRoom;
using RevisionProgram2.themes;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.netRoom
{
    public delegate void MessageEvent(string message);
    public partial class ChatRoom : Form
    {
        public ChatRoom(string _username)
        {
            InitializeComponent();

            username = _username;
            memberNames = new List<string>();
        }

        readonly string username;
        readonly List<string> memberNames;

        public event MessageEvent MessageSent;

        public void ReceiveMessage(string message)
        {
            Invoke((MethodInvoker)delegate ()
            {
                if (ChatTxt.Text.Length != 0)
                    ChatTxt.AppendText(Environment.NewLine);
                ChatTxt.AppendText(message);
            });
        }

        public void AddMember(string name)
        {
            memberNames.Add(name);
            ReceiveMessage($"{name} has joined.");
        }

        public void RemoveMember(string name)
        {
            memberNames.Remove(name);
            ReceiveMessage($"{name} has left.");
        }

        void RefreshMemberList()
        {
            MembersLbl.Text = username;

            foreach (var member in memberNames) 
            {
                MembersLbl.Text += $"\n{member}";
            }
        }

        internal BackgroundWorker GetWorker => NetworkWorker;

        private void SendTxt_TextChanged(object sender, EventArgs e)
        {
            SendBtn.Enabled = SendTxt.Text != "";
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            MessageSent(SendTxt.Text);
            ReceiveMessage($"({username}) {SendTxt.Text}");
            SendTxt.Text = "";
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Revision_Program;

            Theme.ChangeFormTheme(this);

            NetworkWorker.RunWorkerAsync();
        }

        private void ChatRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetRoomPeer.CurrentRoom = null;
        }
    }
}
