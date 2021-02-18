using RevisionProgram2.dialogs;
using RevisionProgram2.revision.explorer.panels;
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
using static RevisionProgram2.revision.RevisionExplorer;

namespace RevisionProgram2.revision.explorer
{
    internal partial class MarathonForm : Form
    {
        internal MarathonForm(FilePanel[] _panels)
        {
            InitializeComponent();

            panels = _panels;
        }

        FilePanel[] panels;

        private void MarathonForm_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
            
            RefreshItems();
        }

        private void RefreshItems()
        {
            MarathonList.Items.Clear();
            foreach (FilePanel panel in panels)
            {
                MarathonList.Items.Add(panel.PanelName, true);
            }

            ShuffleBtn.Enabled = MarathonList.Items.Count > 1;
        }

        private void MoveUpBtn_Click(object sender, EventArgs e)
        {
            Swap(MarathonList.SelectedIndex, MarathonList.SelectedIndex - 1);

            MarathonList.SelectedIndex--;
        }

        private void MoveDownBtn_Click(object sender, EventArgs e)
        {
            Swap(MarathonList.SelectedIndex, MarathonList.SelectedIndex + 1);

            MarathonList.SelectedIndex++;
        }

        void Swap(int id1, int id2)
        {
            bool check1 = MarathonList.GetItemChecked(id1);
            bool check2 = MarathonList.GetItemChecked(id2);

            var temp = panels[id2];
            panels[id2] = panels[id1];
            panels[id1] = temp;

            MarathonList.Items[id2] = panels[id2].PanelName;
            MarathonList.Items[id1] = panels[id1].PanelName;

            MarathonList.SetItemChecked(id1, check2);
            MarathonList.SetItemChecked(id2, check1);
        }

        private void MarathonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MoveUpBtn.Enabled = MarathonList.SelectedIndex > 0;
            MoveDownBtn.Enabled = MarathonList.SelectedIndex != -1 && MarathonList.SelectedIndex != MarathonList.Items.Count - 1;
        }

        private void ShuffleBtn_Click(object sender, EventArgs e)
        {
            var panelCheckArr = new (FilePanel, bool)[panels.Length];

            for (int i = 0; i < panelCheckArr.Length; i++)
            {
                panelCheckArr[i] = (panels[i], MarathonList.GetItemChecked(i));
            }

            Helper.ShuffleArray(ref panelCheckArr);

            for (int i = 0; i < panelCheckArr.Length; i++)
            {
                panels[i] = panelCheckArr[i].Item1;

                MarathonList.Items[i] = panelCheckArr[i].Item1.PanelName;
                MarathonList.SetItemChecked(i, panelCheckArr[i].Item2);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BeginBtn_Click(object sender, EventArgs e)
        {
            var checkedList = new List<FilePanel>();
            for (int i = 0; i < panels.Length; i++)
            {
                if (MarathonList.GetItemChecked(i)) checkedList.Add(panels[i]);
            }

            /*
            for (int i = 0; i < checkedList.Count; i++)
            {
                if (i != 0)
                {
                    if (MsgBox.Show($"You have passed {i} of {checkedList.Count} assessments.{Helper.twoLines}" +
                                    $"The next assessment is {checkedList[i].PanelName}.{Helper.twoLines}" +
                                    $"Do you wish to continue?", $"{i} of {checkedList.Count}", MsgBox.Options.yesNo, MsgBox.MsgIcon.INFO) == "No")
                    {
                        return;
                    }
                }

                panels[i].OnClick();
            }
            */

            int num = 0;

            Action afterAssess = null;

            afterAssess = () =>
            {
                num++;
                if (num != checkedList.Count)
                {
                    if (MsgBox.ShowWait($"You have passed {num} of {checkedList.Count} assessments.{Helper.twoLines}" +
                                    $"The next assessment is {checkedList[num].PanelName}.{Helper.twoLines}" +
                                    $"Do you wish to continue?", $"{num} of {checkedList.Count}", MsgBox.Options.yesNo, MsgBox.MsgIcon.INFO) == "No")
                    {
                        return;
                    }

                    checkedList[num].StartAssessment(afterAssess);
                }
                else
                {
                    MsgBox.ShowWait("You have reached the end of the marathon.", "Marathon", null, MsgBox.MsgIcon.INFO);
                    return;
                }
            };

            checkedList[0].StartAssessment(afterAssess);
        }

        private void MarathonList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            BeginInvoke((MethodInvoker)(() => BeginBtn.Enabled = MarathonList.CheckedItems.Count > 0));
        }
    }
}