using RevisionProgram2.revision.tests;
using RevisionProgram2.specialControls;
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
using static RevisionProgram2.revision.assessments.tests.TestTester;

namespace RevisionProgram2.revision.assessments.tests
{
    internal partial class ResultsForm : Form
    {
        readonly string name;
        internal AskingQuestion[] questions;

        internal ResultsForm(string _name, AskingQuestion[] _questions)
        {
            InitializeComponent();

            name = _name;
            questions = _questions;

            Text = name + " - Test Results";

            uint correctAnswers = 0;

            foreach (AskingQuestion q in questions)
            {
                if (q.Correct) correctAnswers++;

                #region Create question panel
                var qtPanel = new ColourSpecificPanel()
                {
                    Left = 6,
                    Top = ResultsPanel.PreferredSize.Height + 6,
                    Width = ResultsPanel.Width - 24,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColourName = "QuestionBackcolour"
                };
                #endregion

                #region Create question label
                var qPanel = new ColourSpecificPanel()
                {
                    Dock = DockStyle.Top,
                    BackColourName = "QuestionBackcolour"
                };

                // Create label displaying the question
                var qLabel = new ColourSpecificLabel()
                {
                    Font = ResultsPanel.Font,
                    Text = $"Question: {q.question.question}",
                    MaximumSize = new Size(qtPanel.Width, 0),
                    AutoSize = true,
                    
                    //TextAlign = ContentAlignment.MiddleLeft,
                    
                    //Height = ResultsPanel.PreferredSize.Height + 12,
                    //Dock = DockStyle.Top,
                    BackColourName = "QuestionBackcolour",
                    ForeColourName = "QuestionForecolour"
                };

                qPanel.Controls.Add(qLabel);

                //qtPanel.Controls.Add(new Label() { BackColor = Color.Black, Top = qLabel.Bottom });

                qPanel.Height = qLabel.Bottom;
                //qPanel.Dock = DockStyle.Top;
                #endregion

                // Create label showing whether it was correct or not
                var corLabel = new ColourSpecificLabel()
                {
                    Text = q.Correct ? "Correct" : "Incorrect",
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = false,
                    Height = qPanel.Bottom + 18,
                    Dock = DockStyle.Top,
                    BackColourName = q.Correct ? "CorrectBackcolour" : "IncorrectBackcolour",
                    ForeColourName = q.Correct ? "CorrectForecolour" : "IncorrectForecolour"
                };

                corLabel.Height = corLabel.PreferredHeight + 12;

                var gPanel = new ColourSpecificPanel()
                {
                    BackColourName = "QuestionBackcolour",
                    Dock = DockStyle.Top,
                };

                // Create label showing the guess
                var gLabel = new ColourSpecificLabel()
                {
                    Font = ResultsPanel.Font,
                    MaximumSize = new Size(qtPanel.Width - 80, 0),
                    AutoSize = true,
                    Text = "Your guess: " + q.Guess + Helper.twoLines + q.AnswerList(),
                    BackColourName = "QuestionBackcolour",
                    ForeColourName = "QuestionForecolour"
                };

                gPanel.Controls.Add(gLabel);

                gPanel.Height = gPanel.PreferredSize.Height + 6;

                // Add all of the labels in reverse order (cause that's how docking works apparently)
                //qPanel.Controls.Add(cALabel);
                qtPanel.Controls.Add(gPanel);
                qtPanel.Controls.Add(corLabel);
                qtPanel.Controls.Add(qPanel);

                // Resize the question panel to fit its contents.
                //qPanel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                qtPanel.Height = gPanel.Bottom;

                // Add it to the results panel.
                ResultsPanel.Controls.Add(qtPanel);
            }
            
            ScoreLbl.Text = $"You scored {correctAnswers} out of {questions.Length}" +
                            $" ({Math.Round((float)correctAnswers / questions.Length * 100, 1, MidpointRounding.AwayFromZero)}%)";
            //percentageLbl.Text = CStr(Math.Round((correctAnswers / questions.Count) * 100, 1, MidpointRounding.AwayFromZero)) & "%"

            TestIncorrectBtn.Visible = correctAnswers != questions.Length;
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
        }

        private void TryAgainBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TestIncorrectBtn_Click(object sender, EventArgs e)
        {
            /*
            var questionList = new List<Test.Question>();

            foreach (AskingQuestion q in questions)
            {
                if (!q.Correct) questionList.Add(q.question);
            }
            */

            DialogResult = DialogResult.Abort;
            Close();
        }
    }
}
