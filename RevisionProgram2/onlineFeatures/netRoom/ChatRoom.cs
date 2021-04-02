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

namespace RevisionProgram2.onlineFeatures.netRoom
{
    public delegate void MessageEvent(string message);
    public delegate void ChallengeEvent();
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
        public event ChallengeEvent AcceptedChallenge, DeclinedChallenge;

        public void ReceiveMessage(string message)
        {
            if (!IsDisposed)
                Invoke((MethodInvoker)delegate ()
                {
                    if (ChatTxt.Text.Length != 0)
                        ChatTxt.AppendText(Environment.NewLine);
                    ChatTxt.AppendText(message);
                });
        }

        public void AddMember(string name, bool silent = false)
        {
            memberNames.Add(name);
            RefreshMemberList();
            if (!silent) ReceiveMessage($"{name} has joined.");
        }

        public void RemoveMember(string name)
        {
            memberNames.Remove(name);
            RefreshMemberList();
            ReceiveMessage($"{name} has left.");
        }

        void RefreshMemberList()
        {
            Invoke((MethodInvoker)delegate ()
            {
                MembersLbl.Text = username;

                foreach (var member in memberNames)
                {
                    MembersLbl.Text += $"\n{member}";
                }
            });
        }

        internal BackgroundWorker GetWorker => NetworkWorker;

        private void SendTxt_TextChanged(object sender, EventArgs e)
        {
            SendBtn.Enabled = SendTxt.Text != "";
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            MessageSent?.Invoke(SendTxt.Text);
            ReceiveMessage($"({username}) {SendTxt.Text.Trim()}");
            SendTxt.Text = "";
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            MembersLbl.Text = username;
            
            Icon = Properties.Resources.Revision_Program;

            Theme.ChangeFormTheme(this);

            NetworkWorker.RunWorkerAsync();
        }

        private void ChatRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            NetRoomPeer.CurrentRoom = null;
        }

        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            AcceptedChallenge?.Invoke();
            HideChallenge();
        }

        private void DeclineBtn_Click(object sender, EventArgs e)
        {
            DeclinedChallenge?.Invoke();
            HideChallenge();
        }

        public void ReceiveChallenge(string username, string testName)
        {
            Invoke((MethodInvoker)delegate ()
            {
                ChallengeLbl.Text = $"{username} has challenged everyone to {testName}.";

                ChallengeGroup.Visible = true;
                ChatTxt.Height = ChallengeGroup.Top - ChatTxt.Top - 6;

                DeclineBtn.Text = "Decline";
                AcceptBtn.Visible = true;
            });
        }

        public void BeginChallenge(string username, string testName)
        {
            ReceiveChallenge(username, testName);

            Invoke((MethodInvoker)delegate ()
            {
                DeclineBtn.Text = "Cancel";
                AcceptBtn.Visible = false;
            });
        }

        private void SendTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendBtn.PerformClick();
                e.SuppressKeyPress = true;
            }  
        }

        public void HideChallenge()
        {
            Invoke((MethodInvoker)delegate ()
            {
                ChallengeGroup.Visible = false;
                ChatTxt.Height = MessagePanel.Top - ChatTxt.Top - 6;
            });
        }
    }
}
