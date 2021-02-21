using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.dialogs
{
    public partial class ProgressForm : Form
    {
        public ProgressForm(string message, Action<IProgress<float>> _action)
        {
            InitializeComponent();

            MessageLbl.Text = message;
            action = _action;

            progress = new Progress<float>(x => TaskProgress.Value = (int)(x * 100));
        }

        readonly Action<Progress<float>> action;
        public readonly Progress<float> progress;

        bool isClosing;
        private void ProcessWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            action(progress);
            isClosing = true;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
            ProcessWorker.RunWorkerAsync();
        }

        public static void Begin(string _message, Action<IProgress<float>> work, Action onFinish)
        {
            var progressForm = new ProgressForm(_message, work);

            progressForm.FormClosing += (s, e) =>
            {
                onFinish?.Invoke();
            };

            progressForm.Show();
        }

        public static void BeginWait(string _message, Action<IProgress<float>> work)
        {
            var progressForm = new ProgressForm(_message, work);

            progressForm.ShowDialog();
        }

        private void ProgressForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !isClosing)
                e.Cancel = true;
        }

        private void ProcessWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
    }
}
