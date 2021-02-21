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
        public WaitingForm(string message, Action<DoWorkEventArgs> _action, Action _onFinish = null, Func<bool> _onCancel = null)
        {
            InitializeComponent();

            MessageLbl.Text = message;
            action = _action;
            onFinish = _onFinish;
            onCancel = _onCancel;
        }

        readonly Action<DoWorkEventArgs> action;
        readonly Action onFinish;
        readonly Func<bool> onCancel;
        
        bool isClosing;
        private void ProcessWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            action(e);
            isClosing = true;
            onFinish?.Invoke();
        }

        private void WaitingForm_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
            ProcessWorker.RunWorkerAsync();
        }

        public static void Begin(string message, Action<DoWorkEventArgs> work, Action onFinish, Func<bool> onCancel = null)
        {
            var waitingForm = new WaitingForm(message, work, onFinish, onCancel);

            waitingForm.Show();
        }

        public static void BeginWait(string message, Action<DoWorkEventArgs> work, Func<bool> onCancel = null)
        {
            var waitingForm = new WaitingForm(message, work, null, onCancel);

            waitingForm.ShowDialog();
        }

        private void WaitingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !isClosing)
            {
                ProcessWorker.CancelAsync();

                if (onCancel != null)
                {
                    MessageLbl.Text = "Cancelling...";
                    e.Cancel = !onCancel();
                }
                else e.Cancel = true;
            }
        }

        private void ProcessWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
    }
}
