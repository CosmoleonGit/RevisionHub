using RevisionProgram2.onlineFeatures.netRoom;
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
        public event MessageEvent MessageSent;
        public event MessageEvent MessageReceived;

        readonly List<ClientMember> members;

        public ChatRoom(List<ClientMember> _members)
        {
            InitializeComponent();

            members = _members;
        }

        private void SendTxt_TextChanged(object sender, EventArgs e)
        {
            SendBtn.Enabled = SendTxt.Text != "";
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            MessageSent(SendTxt.Text);
            SendTxt.Text = "";
        }
    }
}
