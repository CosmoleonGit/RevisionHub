using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.folderSync
{
    public partial class OnlineChoose : Form
    {
        public OnlineChoose()
        {
            InitializeComponent();
        }

        private void OnlineChoose_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);

#if DEBUG
            IPTxt.Text = "127.0.0.1";
            PortNumeric.Value = 1234;
#endif
        }

        public bool Host => HostRadio.Checked;

        public string IP => IPTxt.Text;
        public int Port => (int)PortNumeric.Value;

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void HostRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (JoinRadio.Checked)
            {
                IPLbl.Enabled = true;
                IPTxt.Enabled = true;
            }

            CheckValid();
        }

        private void JoinRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (HostRadio.Checked)
            {
                IPLbl.Enabled = false;
                IPTxt.Enabled = false;
            }
            
            CheckValid();
        }

        private void IPTxt_TextChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        private void PortNumeric_ValueChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        void CheckValid()
        {
            ConnectBtn.Enabled = HostRadio.Checked || IPTxt.Text != "";
        }
    }
}
