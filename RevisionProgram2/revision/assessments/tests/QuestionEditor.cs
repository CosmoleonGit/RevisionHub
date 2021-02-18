using RevisionProgram2.dialogs;
using RevisionProgram2.revision.tests;
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
using static RevisionProgram2.revision.tests.Test;

namespace RevisionProgram2.revision.assessments.tests
{
    internal partial class QuestionEditor : Form
    {
        readonly Predicate<string> checkQuestion;
        public QuestionEditor(Question question = null, Predicate<string> _checkQuestion = null)
        {
            InitializeComponent();

            if (question != null)
            {
                Question q = question;

                QuestionTxt.Text = q.question;
                foreach (string s in q.answers)
                {
                    AnswerList.Items.Add(s);
                }

                SetCombo();
                
                if (question.multipleChoice != -1)
                {
                    MultipleCheck.Checked = true;
                    CorrectCombo.SelectedIndex = question.multipleChoice;
                }

                
            } else
            {
                ActiveControl = QuestionTxt;
            }

            checkQuestion = _checkQuestion;

            CheckValid();
        }

        private void QuestionEditor_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
            
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string newAns = TextInput.GetInputWait("Enter a possible answer for this question",
                                                   "Answer", 
                                                   "", 
                                                   (string s) => { return !AnswerList.Items.Contains(s); }, 
                                                   true).Trim();
        
            if (newAns != "")
            {
                AnswerList.Items.Add(newAns);
                CheckValid();
                SetCombo();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            string newAns = TextInput.GetInputWait("Enter a possible answer for this question",
                                                   "Answer",
                                                   AnswerList.SelectedItem.ToString(),
                                                   (string s) => { return !AnswerList.Items.Contains(s); }, 
                                                   true).Trim();

            if (newAns != "")
            {
                AnswerList.Items[AnswerList.SelectedIndex] = newAns;
                SetCombo();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowWait("Are you sure you want to delete this answer?",
                                "Delete",
                                MsgBox.Options.yesNo,
                                MsgBox.MsgIcon.EXCL) == "Yes")
            {
                AnswerList.Items.Remove(AnswerList.SelectedItem);
                CheckValid();
                SetCombo();
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AnswerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditBtn.Enabled = AnswerList.SelectedIndex != -1;
            DeleteBtn.Enabled = EditBtn.Enabled;
        }

        private void QuestionTxt_TextChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        const int answerLimit = 10;

        private void CheckValid()
        {
            //if (AnswerList.Items.Count > 1) CorrectCombo.SelectedIndex = 0;
            OKBtn.Enabled = QuestionTxt.Text != "" && AnswerList.Items.Count > 0;

            if (checkQuestion != null) OKBtn.Enabled &= checkQuestion(QuestionTxt.Text);

            AddBtn.Enabled = AnswerList.Items.Count < answerLimit;

            MultipleCheck.Enabled = AnswerList.Items.Count > 1;
            if (!MultipleCheck.Enabled) MultipleCheck.Checked = false;
        }

        internal Question GetQuestion()
        {
            List<string> answerList = new List<string>();
            foreach (string s in AnswerList.Items)
            {
                answerList.Add(s);
            }
            return new Question(QuestionTxt.Text.Trim(), answerList.ToArray(), MultipleCheck.Checked ? CorrectCombo.SelectedIndex : -1);
        }

        private void MultipleCheck_CheckedChanged(object sender, EventArgs e)
        {
            //CheckValid();
            CorrectCombo.SelectedIndex = 0;

            CorrectLbl.Visible = MultipleCheck.Checked;
            CorrectCombo.Visible = MultipleCheck.Checked;

            AnswerGroup.Height = AnswerGroup.PreferredSize.Height - 6;

            OKBtn.Top = AnswerGroup.Bottom + 6;
            CancelBtn.Top = AnswerGroup.Bottom + 6;

            Height = PreferredSize.Height + 6;
        }

        private void SetCombo()
        {
            int sI = CorrectCombo.SelectedIndex;

            CorrectCombo.Items.Clear();
            foreach (string s in AnswerList.Items)
            {
                CorrectCombo.Items.Add(s);
            }
            //if (AnswerList.Items.Count > 1) CorrectCombo.SelectedIndex = 0;
            CorrectCombo.SelectedIndex = Math.Min(sI, AnswerList.Items.Count - 1);
        }
    }
}
