using RevisionProgram2.revision.tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.revision.assessments.tests
{
    public partial class TestSettings : UserControl
    {
        public TestSettings()
        {
            InitializeComponent();
        }

        public TestSettings(Test _test)
        {
            InitializeComponent();

            test = _test;
        }

        readonly Test test;

        private void TestSettings_Load(object sender, EventArgs e)
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

            SkipBox.Enabled = Properties.Settings.Default.testSkippable;

        }

        private void FlashcardsBtn_Click(object sender, EventArgs e)
        {
            test.AsFlashcards();
        }

        private void CsvBtn_Click(object sender, EventArgs e)
        {
            test.SaveAsCSV();
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

        public bool CanSkip => SkipBox.Checked;

        public void SaveSettings()
        {
            if (SortNormalRadio.Checked)
            {
                Properties.Settings.Default.testSort = (int)SortMode.Normal;
            }
            else if (SortReverseRadio.Checked)
            {
                Properties.Settings.Default.testSort = (int)SortMode.Reverse;
            }
            else
            {
                Properties.Settings.Default.testSort = (int)SortMode.Shuffle;
            }

            Properties.Settings.Default.testSkippable = SkipBox.Checked;

            Properties.Settings.Default.Save();
        }
    }
}
