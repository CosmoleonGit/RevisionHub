using RevisionProgram2.revision.flashcards;
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
using static RevisionProgram2.revision.flashcards.Flashcards;

namespace RevisionProgram2.revision.assessments.flashcards
{
    public partial class FlashcardTester : Form
    {
        public FlashcardTester(string flashcardsName, IEnumerable<Card> _cards)
        {
            InitializeComponent();
            Text = flashcardsName + " - Flashcards";
            cards = _cards.ToArray();
        }

        readonly Card[] cards;

        Card ThisCard => cards[currentID];

        public Action onFinish;

        int currentID;

        private bool side;
        public bool Side { get { return side; } 
            set { 
                side = value;

                FlashcardBtn.BackColourName = side ? "CardRightBack" : "CardLeftBack";
                FlashcardBtn.ForeColourName = side ? "CardRightFore" : "CardLeftFore";
                Theme.ChangeControl(FlashcardBtn); 

                FlashcardBtn.Text = side ? ThisCard.side2 : ThisCard.side1;
                
                FitFont();
            }
        }

        private void FitFont()
        {
            
        }

        private void SwitchTo(int newID)
        {
            //if (newID < 0 || newID >= cards.Length) return;
            currentID = newID;

            Side = false;

            RefreshInfo();
        }

        private void RefreshInfo()
        {
            CurrentLbl.Text = "Card " + (currentID + 1).ToString() + " of " + cards.Length.ToString();

            LeftBtn.Enabled = currentID != 0;
            RightBtn.Enabled = currentID < cards.Length - 1;

            LeftMostBtn.Enabled = LeftBtn.Enabled;
            RightMostBtn.Enabled = RightBtn.Enabled;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FlashcardTester_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;

            SwitchTo(0);
        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            SwitchTo(currentID - 1);
        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            SwitchTo(currentID + 1);
        }

        private void LeftMostBtn_Click(object sender, EventArgs e)
        {
            SwitchTo(0);
        }

        private void RightMostBtn_Click(object sender, EventArgs e)
        {
            SwitchTo(cards.Length - 1);
        }

        private void FlashcardTester_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void FlashcardBtn_Click(object sender, EventArgs e)
        {
            Side ^= true;
        }

        private void FlashcardTester_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    RightBtn.PerformClick();
                    break;
                case Keys.A:
                    LeftBtn.PerformClick();
                    break;
                case Keys.F:
                    FlashcardBtn.PerformClick();
                    break;
            }
        }

        private void FlashcardBtn_TextChanged(object sender, EventArgs e)
        {
            //FitButtonToText();
            FlashcardBtn.ScaleFontToFit(4, 14);
        }

        private void FlashcardTester_FormClosing(object sender, FormClosingEventArgs e)
        {
            onFinish?.Invoke();
        }

        private void FlashcardBtn_SizeChanged(object sender, EventArgs e)
        {
            FlashcardBtn.ScaleFontToFit(4, 14);
        }
    }
}
