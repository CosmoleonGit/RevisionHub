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

namespace RevisionProgram2.dialogs
{
    public partial class WaitingForm : Form
    {
        public WaitingForm(string message, Action _action, Action _onFinish = null)
        {
            InitializeComponent();

            MessageLbl.Text = message;
            action = _action;
            onFinish = _onFinish;
        }

        readonly Action action, onFinish;

        bool isClosing;
        private void ProcessWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            action();
            isClosing = true;
            onFinish?.Invoke();
            Invoke(new Action(() => { Close(); }));
        }

        private void WaitingForm_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
            ProcessWorker.RunWorkerAsync();
        }

        public static void Begin(string message, Action work, Action onFinish)
        {
            var waitingForm = new WaitingForm(message, work, onFinish);

            waitingForm.Show();
        }

        public static void BeginWait(string message, Action work, Action onFinish = null)
        {
            var waitingForm = new WaitingForm(message, work, onFinish);

            waitingForm.ShowDialog();
        }

        private void WaitingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !isClosing)
                e.Cancel = true;
        }
    }
}
