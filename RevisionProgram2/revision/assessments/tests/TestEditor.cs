using RevisionProgram2.dialogs;
using RevisionProgram2.revision.tests;
using RevisionProgram2.themes;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RevisionProgram2.revision.assessments.tests.TestTester;
using static RevisionProgram2.revision.tests.Test;

namespace RevisionProgram2.revision.assessments.tests
{
    internal partial class TestEditor : Form
    {
        #region Simulate Show Dialog

        const int GWL_STYLE = -16;
        const int WS_DISABLED = 0x08000000;

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        internal void SetNativeEnabled(bool enabled)
        {
            SetWindowLong(Handle, GWL_STYLE, GetWindowLong(Handle, GWL_STYLE) &
                ~WS_DISABLED | (enabled ? 0 : WS_DISABLED));
        }

        #endregion

        public Action onFinish;
        readonly string testName;
        public TestEditor(string _testName, string description = "", IEnumerable<Question> questionArray = null)
        {
            InitializeComponent();

            testName = _testName;

            Text = testName + " - Test Editor";

            DescTxt.Text = description;

            if (questionArray != null) questions = questionArray.ToList();
        }
        
        internal List<Question> questions = new List<Question>();

        private void OKBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            closing = true;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Cancellation();
        }

        bool closing = false;

        private void TestEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing && e.CloseReason == CloseReason.UserClosing)
            {
                Cancellation();
                if (!closing) e.Cancel = true;
            }

            if(!e.Cancel)
                onFinish?.Invoke();
        }

        private void Cancellation()
        {
            if (changes)
            {
                if (MsgBox.ShowWait("All saved changes will be lost. Proceed?",
                                       "Cancel",
                                       MsgBox.Options.yesNo,
                                       MsgBox.MsgIcon.EXCL) == "Yes")
                {
                    DialogResult = DialogResult.Cancel;
                    closing = true;
                    Close();
                }
            }
            else
            {
                closing = true;
                Close();
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddQuestion(null, true);
        }

        internal bool changes = false;

        internal void AddQuestion(Question q = null, bool scrollToEnd = false)
        {
            SetNativeEnabled(false);

            var questionEditor = new QuestionEditor(q, s => !questions.Any(x => x.question == s));

            questionEditor.FormClosing += (s, e) =>
            {
                SetNativeEnabled(true);
                Focus();

                if (questionEditor.DialogResult == DialogResult.OK)
                {
                    changes = true;

                    Question question = questionEditor.GetQuestion();
                    questions.Add(question);

                    var questionPanel = new QPanel(QuestionPanel, question, QuestionPanel.Controls.Count);
                    
                    AddPanel(questionPanel);

                    if (scrollToEnd)
                    {
                        QuestionPanel.VerticalScroll.Value = 0;
                        QuestionPanel.ScrollControlIntoView(questionPanel);
                    }

                    RefreshOK();

                    foreach (var control in QuestionPanel.Controls)
                    {
                        QPanel qPanel = control as QPanel;

                        qPanel.ID = qPanel.ID;
                    }
                }
            };

            questionEditor.Show();
        }

        private void TestEditor_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;

            if (questions != null)
            {
                questions = questions.ToList();

                foreach (Question q in questions)
                {
                    AddPanel(new QPanel(QuestionPanel, q, QuestionPanel.Controls.Count));
                }

                RefreshOK();
            }
        }

        void AddPanel(QPanel panel)
        {
            panel.Top = ((QuestionPanel.Controls.Count != 0) ? QuestionPanel.Controls[QuestionPanel.Controls.Count - 1].Bottom : 0) + 6;

            if (QuestionPanel.Controls.Count == 0)
                panel.Width = QuestionPanel.Width - 12;
            else
                panel.Width = QuestionPanel.Controls[0].Width;

            QuestionPanel.Controls.Add(panel);
        }

        private void DescBtn_Click(object sender, EventArgs e)
        {
            DescGroup.Visible ^= true;
            DescBtn.Text = "Description " + (DescGroup.Visible ? "<<<" : ">>>");
            Width = PreferredSize.Width + 6;
        }

        internal void RefreshOK()
        {
            OKBtn.Enabled = QuestionPanel.Controls.Count > 0;
            PreviewBtn.Enabled = OKBtn.Enabled;
            NumLbl.Text = $"{questions.Count} question" + (questions.Count != 1 ? "s" : "");
        }

        public string Description
        {
            get { return DescTxt.Text; }
            set { DescTxt.Text = value; }
        }

        public bool Save(string path)
        {
            List<string> list = new List<string>
                {
                    "TEST",
                    testVersion
                };

            list.AddRange(Helper.SplitIntoLines(Description));

            foreach (Question question in questions)
            {
                list.Add(char.MaxValue.ToString());
                list.Add(question.question);

                list.Add(char.MaxValue.ToString());
                list.Add(question.multipleChoice.ToString());

                list.Add(char.MaxValue.ToString());

                foreach (string s in question.answers)
                {
                    list.Add(s);
                }
            }

            try
            {
                File.Delete(path);
                File.WriteAllLines(path, list.ToArray());

                return true;
            }
            catch (IOException ex)
            {
                Helper.Error("Error saving test.", ex.Message);

                return false;
            }
        }

        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            StartTest(testName, questions.ToArray(), false);
        }

        private void DescTxt_TextChanged(object sender, EventArgs e)
        {
            changes = true;
        }
    }
}
