using RevisionProgram2.revision.flashcards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.revision.assessments.flashcards
{
    public enum FaceMode
    {
        Front,
        Back,
        Random
    }

    public partial class FlashcardsSettings : UserControl
    {
        public FlashcardsSettings()
        {
            InitializeComponent();
        }

        public FlashcardsSettings(Flashcards _flashcards)
        {
            InitializeComponent();

            flashcards = _flashcards;
        }

        readonly Flashcards flashcards;

        private void FlashcardsSettings_Load(object sender, EventArgs e)
        {
            switch ((SortMode)Properties.Settings.Default.flashcardSort)
            {
                case SortMode.Normal:
                    SortNormalRadio.Checked = true;
                    break;
                case SortMode.Reverse:
                    SortReverseRadio.Checked = true;
                    break;
                case SortMode.Shuffle:
                    SortShuffleRadio.Checked = true;
                    break;
            }

            switch ((FaceMode)Properties.Settings.Default.flashcardFlip)
            {
                case FaceMode.Front:
                    FaceFrontRadio.Checked = true;
                    break;
                case FaceMode.Back:
                    FaceBackRadio.Checked = true;
                    break;
                case FaceMode.Random:
                    FaceRandomRadio.Checked = true;
                    break;
            }
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            flashcards.AsTest();
        }

        private void CsvBtn_Click(object sender, EventArgs e)
        {
            flashcards.SaveAsCSV();
        }

        public SortMode GetSortMode()
        {
            if (SortNormalRadio.Checked)
                return SortMode.Normal;
            else if (SortReverseRadio.Checked)
                return SortMode.Reverse;
            else
                return SortMode.Shuffle;
        }

        public FaceMode GetFaceMode()
        {
            if (FaceFrontRadio.Checked)
                return FaceMode.Front;
            else if (FaceBackRadio.Checked)
                return FaceMode.Back;
            else
                return FaceMode.Random;
        }

        public void SaveSettings()
        {
            if (SortNormalRadio.Checked)
                Properties.Settings.Default.flashcardSort = 0;
            else if (SortReverseRadio.Checked)
                Properties.Settings.Default.flashcardSort = 1;
            else
                Properties.Settings.Default.flashcardSort = 2;

            if (FaceFrontRadio.Checked)
                Properties.Settings.Default.flashcardFlip = 0;
            else if (FaceBackRadio.Checked)
                Properties.Settings.Default.flashcardFlip = 1;
            else
                Properties.Settings.Default.flashcardFlip = 2;

            Properties.Settings.Default.Save();
        }
    }
}
