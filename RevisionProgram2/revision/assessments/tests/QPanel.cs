using RevisionProgram2.dialogs;
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
using static RevisionProgram2.revision.tests.Test;

namespace RevisionProgram2.revision.assessments.tests
{
    public partial class QPanel : UserControl, IColourSpecific
    {
        public QPanel()
        {
            InitializeComponent();
        }

        

        public QPanel(Panel _owner, Question _question, int _id)
        {
            InitializeComponent();

            Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            question = _question;
            owner = _owner;
            editor = owner.FindForm() as TestEditor;

            ID = _id;

            RefreshControls();

            Theme.ChangeControl(this);
        }

        
        readonly Question question;
        readonly TestEditor editor;
        readonly Panel owner;

        int id;
        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                //moveUpStrip.Enabled = id != 0;
                //moveDownStrip.Enabled = id < GetForm.questions.Count - 1;
            }
        }

        void RefreshControls()
        {
            QuestionLbl.Text = "Question: " + question.question;
            if (question.multipleChoice != -1) QuestionLbl.Text += "  (Multiple Choice)";
            QuestionLbl.Text += Environment.NewLine;


            AnswersLbl.Text = (question.multipleChoice == -1 ? "Answers:" : "Options:") + Environment.NewLine;
            foreach (string str in question.answers)
            {
                if (AnswersLbl.Text != "") AnswersLbl.Text += Environment.NewLine;
                AnswersLbl.Text += str;
            }

            if (question.multipleChoice != -1)
            {
                AnswersLbl.Text += Helper.twoLines + "Correct answer: " + question.answers[question.multipleChoice];
            }


            AnswersLbl.Top = QuestionLbl.Bottom + 18;

            Height = PreferredSize.Height + 12;

            EditBtn.Top = Height / 2 - 13;
        }

        public void UpdateTheme(Theme theme)
        {
            BackColor = theme.GetColour("QuestionBackcolour");
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            FileContext.Show(Cursor.Position);
        }

        private void EditStrip_Click(object sender, EventArgs e)
        {
            editor.SetNativeEnabled(false);

            var questionEditor = new QuestionEditor(question);

            questionEditor.FormClosing += (s, ev) =>
            {
                editor.SetNativeEnabled(true);

                if (questionEditor.DialogResult == DialogResult.OK)
                {
                    editor.changes = true;

                    Question q = questionEditor.GetQuestion();

                    question.question = q.question;
                    question.answers = q.answers;
                    question.multipleChoice = q.multipleChoice;

                    int prvHeight = Height;

                    RefreshControls();

                    foreach (QPanel panel in owner.Controls)
                    {
                        if (panel == this) continue;

                        if (panel.ID > ID)
                        {
                            panel.Top -= prvHeight - Height;
                        }
                    }
                }
            };

            questionEditor.Show();
        }

        private void DeleteStrip_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowWait("Are you sure you want to delete this question?",
                            "Delete",
                            MsgBox.Options.yesNo,
                            MsgBox.MsgIcon.EXCL) == "Yes")
            {
                editor.changes = true;


                foreach (QPanel panel in owner.Controls)
                {
                    if (panel == this) continue;

                    if (panel.ID > ID)
                    {
                        panel.ID--;
                        panel.Top -= Height + 9;
                    }
                }

                owner.Controls.Remove(this);
                editor.questions.Remove(question);

                editor.RefreshOK();
            }
        }

        private void DuplicateStrip_Click(object sender, EventArgs e)
        {
            editor.AddQuestion(question, true);
        }

        private void MoveUpStrip_Click(object sender, EventArgs e)
        {
            editor.changes = true;

            foreach (Control c in Parent.Controls)
            {
                QPanel qpc = c as QPanel;
                if (qpc.ID == ID - 1)
                {
                    Top = c.Top;
                    c.Top += Height + 6;

                    editor.questions[ID] = qpc.question;
                    editor.questions[ID - 1] = question;

                    qpc.ID++;
                    ID--;

                    break;
                }
            }

            owner.ScrollControlIntoView(this);
        }

        private void MoveDownStrip_Click(object sender, EventArgs e)
        {
            editor.changes = true;

            foreach (QPanel qpc in owner.Controls)
            {
                if (qpc.ID == ID + 1)
                {
                    qpc.Top = Top;
                    Top += qpc.Height + 6;

                    editor.questions[ID + 1] = question;
                    editor.questions[ID] = qpc.question;

                    qpc.ID--;
                    ID++;

                    break;
                }
            }

            owner.ScrollControlIntoView(this);
        }
    }
}
