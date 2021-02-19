using RevisionProgram2.dialogs;
using RevisionProgram2.revision.flashcards;
using RevisionProgram2.themes;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RevisionProgram2.revision.flashcards.Flashcards;

namespace RevisionProgram2.revision.assessments.flashcards
{
    public partial class FlashcardsEditor : Form
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

        public FlashcardsEditor(string flashcardsName, string description = "", Card[] cardArray = null)
        {
            InitializeComponent();

            Text = flashcardsName + " - Flashcards Editor";
            DescTxt.Text = description;
            if (cardArray != null) cards = cardArray.ToList();
        }

        public Action onFinish;
        public List<Card> cards = new List<Card>();

        bool changes = false;

        int currentID;
        private void SwitchTo(int newID)
        {
            currentID = newID;

            Side1Btn.Text = cards[newID].side1;
            Side2Btn.Text = cards[newID].side2;

            RefreshInfo();
        }

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

        private void FlashcardsEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing && e.CloseReason == CloseReason.UserClosing)
            {
                Cancellation();
                if (!closing) e.Cancel = true;
            }

            if (!e.Cancel)
            {
                onFinish?.Invoke();
            }
        }

        private void Cancellation()
        {
            if (changes)
            {
                if(MsgBox.ShowWait("All saved changes will be lost. Proceed?",
                                       "Cancel",
                                       MsgBox.Options.yesNo,
                                       MsgBox.MsgIcon.EXCL) == "Yes")
                {
                    DialogResult = DialogResult.Cancel;
                    closing = true;
                    Close();
                }
            } else
            {
                closing = true;
                Close();
            }
        }

        private void DescBtn_Click(object sender, EventArgs e)
        {
            DescBtn.Text = "Description " + (RightPanel.Visible ? ">>>" : "<<<");
            
            RightPanel.Visible ^= true;

            if (RightPanel.Visible)
            {
                MinimumSize += new Size(RightPanel.Width, 0);
            }
            else
            {
                MinimumSize -= new Size(RightPanel.Width, 0);
            }

            Width = MainPanel.Width + (RightPanel.Visible ? (RightPanel.Width + 16) : 0);

            if (RightPanel.Visible)
                MainPanel.Width = RightPanel.Left;
            else
                MainPanel.Width = ClientSize.Width;
        }

        private void RefreshInfo()
        {
            CurrentLbl.Text = "Card " + (currentID + 1).ToString() + " of " + cards.Count.ToString();

            LeftBtn.Enabled = currentID != 0;
            RightBtn.Enabled = currentID < cards.Count - 1;

            LeftMostBtn.Enabled = LeftBtn.Enabled;
            RightMostBtn.Enabled = RightBtn.Enabled;

            LShiftBtn.Enabled = LeftBtn.Enabled;
            RShiftBtn.Enabled = RightBtn.Enabled;

            DeleteBtn.Enabled = cards.Count > 1;
        }

        public string Description
        {
            get { return DescTxt.Text; }
            set { DescTxt.Text = value; }
        }

        void ChangeSide(Button button, bool right, string title)
        {
            SetNativeEnabled(false);

            MultilineInput.GetInput("Enter the new text for this side.",
                                    title,
            s =>
            {
                SetNativeEnabled(true);

                if (s == "" || s == cards[currentID].GetSide(right)) return;

                var card = cards[currentID];
                card.SetSide(right, s);
                cards[currentID] = card;

                button.Text = s;
                changes = true;
            }, button.Text);
        }

        private void Side1Btn_Click(object sender, EventArgs e)
        {
            ChangeSide(Side1Btn, false, "Side 1");
        }

        private void Side2Btn_Click(object sender, EventArgs e)
        {
            ChangeSide(Side2Btn, true, "Side 2");
        }

        private void FlashcardsEditor_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
            Width = MainPanel.Width;

            CenterToScreen();

            if (cards.Count == 0)
            {
                cards.Add(Card.DefaultCard);
            }

            SwitchTo(0);
            changes = false;
        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            SwitchTo(currentID - 1);
        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            SwitchTo(currentID + 1);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            cards.Add(Card.DefaultCard);
            SwitchTo(cards.Count - 1);
        }

        private void DuplicateBtn_Click(object sender, EventArgs e)
        {
            cards.Add(cards[currentID]);
            SwitchTo(cards.Count - 1);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (!cards[currentID].IsDefault)
            {
                if (MsgBox.ShowWait("Are you sure you want to delete this flashcard?",
                                "Delete",
                                MsgBox.Options.yesNo,
                                MsgBox.MsgIcon.EXCL) == "No"){
                    return;
                }
            }

            cards.RemoveAt(currentID);
            if (currentID != 0) SwitchTo(currentID - 1);
            else { SwitchTo(0); }
        }

        private void FlashcardsEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DescTxt.Visible && DescTxt.Focused) return;

            switch (char.ToUpper(e.KeyChar))
            {
                case 'D':
                    RightBtn.PerformClick();
                    break;
                case 'A':
                    LeftBtn.PerformClick();
                    break;
            }
        }

        public bool Save(string path)
        {
            List<string> list = new List<string>
                {
                    "FLASHCARDS",
                    flashcardsVersion
                };

            list.AddRange(Helper.SplitIntoLines(Description));

            foreach (Card card in cards)
            {
                list.Add(char.MaxValue.ToString());
                list.AddRange(Helper.SplitIntoLines(card.side1));

                list.Add(char.MaxValue.ToString());
                list.AddRange(Helper.SplitIntoLines(card.side2));
            }

            try
            {
                File.Delete(path);
                File.WriteAllLines(path, list.ToArray());

                return true;
            }
            catch (IOException ex)
            {
                Helper.Error("Error saving flashcards.", ex.Message);

                return false;
            }
        }

        private void LeftMostBtn_Click(object sender, EventArgs e)
        {
            SwitchTo(0);
        }

        private void RightMostBtn_Click(object sender, EventArgs e)
        {
            SwitchTo(cards.Count - 1);
        }

        private void LShiftBtn_Click(object sender, EventArgs e)
        {
            Swap(currentID - 1);
        }

        private void RShiftBtn_Click(object sender, EventArgs e)
        {
            Swap(currentID + 1);
        }

        private void Swap(int to)
        {
            var current = cards[currentID];

            cards[currentID] = cards[to];
            cards[to] = current;

            SwitchTo(to);
        }

        private void DescTxt_TextChanged(object sender, EventArgs e)
        {
            changes = true;
        }

        private void Side1Btn_TextChanged(object sender, EventArgs e)
        {
            Side1Btn.ScaleFontToFit(4, 14.25f);
        }

        private void Side2Btn_TextChanged(object sender, EventArgs e)
        {
            Side2Btn.ScaleFontToFit(4, 14.25f);
        }

        private void FlashcardsEditor_SizeChanged(object sender, EventArgs e)
        {
            if (RightPanel.Visible)
            {
                MainPanel.Width = RightPanel.Left;
            } else
            {
                MainPanel.Width = ClientSize.Width;
            }
        }

        private void Side1Btn_SizeChanged(object sender, EventArgs e)
        {
            Side1Btn.ScaleFontToFit(4, 14.25f);
        }

        private void Side2Btn_SizeChanged(object sender, EventArgs e)
        {
            Side2Btn.ScaleFontToFit(4, 14.25f);
        }

        private void MiddlePanel_SizeChanged(object sender, EventArgs e)
        {
            int w = MainPanel.ClientSize.Width / 2 - 15;

            Side1Btn.Width = w;
            Side2Btn.Width = w;

            Side2Btn.Left = MainPanel.Right - Side2Btn.Width - 12;
        }
    }
}
