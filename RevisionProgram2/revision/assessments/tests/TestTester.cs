using RevisionProgram2.revision.tests;
using RevisionProgram2.specialControls;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RevisionProgram2.revision.tests.Test;

namespace RevisionProgram2.revision.assessments.tests
{
    internal partial class TestTester : Form
    {
        internal AskingQuestion[] questions;

        int curID = 0;
        public Action onFinish;

        AskingQuestion CurrentQuestion => questions[curID];

        readonly bool canSkip;

        public TestTester(string flashcardsName, IEnumerable<Question> _questions, bool _canSkip = false)
        {
            InitializeComponent();

            canSkip = _canSkip;

            Text = flashcardsName + " - Test";

            var list = _questions.Select(x => new AskingQuestion(x)).ToList();

            questions = list.ToArray();

            TestProgress.Maximum = questions.Length;
        }

        public TestResults Results => new TestResults(questions);

        private void TestTester_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;

            if (canSkip)
            {
                CheckBtn.Text = "Skip";
            }

            MoveToQuestion(0);

            CenterToScreen();
        }

        private void MoveToQuestion(int id)
        {
            curID = id;

            NumLbl.Text = $"Question {curID + 1} of {questions.Length}";
            QuestionLbl.Text = CurrentQuestion.question.question;
            TestProgress.Value = id;

            if (canSkip)
            {
                CheckBtn.Enabled = true;
            }

            if (CurrentQuestion.question.multipleChoice == -1)
            {
                AcceptButton = CheckBtn;

                InputTxt.Enabled = true;
                //CheckBtn.Enabled = false;

                InputTxt.Text = "";

                TypedPanel.Visible = true;
                MultiplePanel.Visible = false;

                ActiveControl = InputTxt;
            } else
            {
                AcceptButton = null;

                MultiplePanel.Controls.Clear();

                for (int i = CurrentQuestion.question.answers.Length - 1; i >= 0; i--)
                //for (int i = 0; i < CurrentQuestion.question.answers.Length; i++)
                {
                    string a = CurrentQuestion.question.answers[i];

                    var btn = new ColourSpecificButton()
                    {
                        Text = a,
                        Font = Font,
                        AutoSize = true,
                        //Size = new Size(0, 40),
                        //Dock = DockStyle.Top,
                        FlatStyle = FlatStyle.Flat,
                        TabIndex = i,
                        TabStop = true,
                        BackColourName = "ChoiceColourBack",
                        ForeColourName = "ChoiceColourFore"
                    };

                    btn.Size = new Size(0, btn.Height + 6);
                    btn.Dock = DockStyle.Top;

                    btn.FlatAppearance.BorderSize = 0;
                    
                    btn.SendToBack();

                    Theme.ChangeControl(btn);

                    btn.Click += Btn_Click;

                    MultiplePanel.Controls.Add(btn);
                }

                MultiplePanel.Height = MultiplePanel.PreferredSize.Height;

                MultiplePanel.Visible = true;
                TypedPanel.Visible = false;
            }

            CorrectPanel.Visible = false;

            Height = PreferredSize.Height;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button sBtn = sender as Button;

            sBtn.FlatAppearance.BorderSize = 2;
            Guess(sBtn.Text);
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            Guess(InputTxt.Text);
        }

        private void Guess(string guess)
        {
            

            if (TypedPanel.Visible)
            {
                InputTxt.Enabled = false;
                CheckBtn.Enabled = false;
            } else
            {
                foreach (Control c in MultiplePanel.Controls)
                {
                    c.TabStop = false;
                }

                foreach (Control c in MultiplePanel.Controls)
                {
                    c.Enabled = false;
                }
            }

            bool correct = questions[curID].Attempt(guess);

            if (correct)
            {
                CorrectLbl.BackColourName = "CorrectBackcolour";
                CorrectLbl.ForeColourName = "CorrectForecolour";
                CorrectLbl.Text = "Correct!";
            } else
            {
                CorrectLbl.BackColourName = "IncorrectBackcolour";
                CorrectLbl.ForeColourName = "IncorrectForecolour";
                CorrectLbl.Text = "Incorrect...";
            }

            Theme.ChangeControl(CorrectLbl);

            AnswersLbl.Text = CurrentQuestion.AnswerList();

            CorrectPanel.Height = AnswersLbl.Top + AnswersLbl.PreferredHeight + NextBtn.Height + 6;

            NextBtn.Text = (curID == questions.Length - 1) ? "Show Results" : "Next Question";

            CorrectPanel.BringToFront();
            CorrectPanel.Visible = true;

            Height = PreferredSize.Height;

            AcceptButton = NextBtn;
            
            NextBtn.Focus();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (curID < questions.Length - 1)
            {
                MoveToQuestion(curID + 1);
            } else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void InputTxt_TextChanged(object sender, EventArgs e)
        {
            if (canSkip)
            {
                CheckBtn.Text = (InputTxt.Text != "") ? "Check" : "Skip";
            } else
            {
                CheckBtn.Enabled = InputTxt.Text != "";
            }
            
        }

        private void TestTester_FormClosing(object sender, FormClosingEventArgs e)
        {
            onFinish?.Invoke();
        }

        private void QuestionLbl_TextChanged(object sender, EventArgs e)
        {
            QuestionLbl.ScaleFontToFit(6f, 16f);
        }
    }
}
