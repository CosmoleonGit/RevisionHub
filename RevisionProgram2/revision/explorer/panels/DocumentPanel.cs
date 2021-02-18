using RevisionProgram2.dialogs;
using RevisionProgram2.revision.documents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.revision.explorer.panels
{
    public partial class DocumentPanel : ItemPanel
    {
        public DocumentPanel(Panel owner, string name, string path) : base(owner, name, path)
        {
            InitializeComponent();
        }

        public DocumentPanel()
        {
            InitializeComponent();
        }

        public override void OnClick()
        {
            GetForm.BeginEditing($"{Dir}{PanelName}");
            new Document(PanelName, Dir).Start(() =>
            {
                GetForm.StopEditing($"{Dir}{PanelName}");
            });
        }

        public override void MoveItem(string path)
        {
            File.Move(Dir + PanelName, path + PanelName);
            Dir = path;
        }

        protected override void OnChange()
        {
            OptionsContext.Show(Cursor.Position);
        }

        protected override Image GetIcon()
        {
            return Properties.Resources.Document;
        }

        private void MoveStrip_Click(object sender, EventArgs e)
        {
            GetForm.BeginMove(this);
        }

        private void DeleteStrip_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowWait("Are you sure you want to delete '" + PanelName + "'?",
                        "Delete",
                        MsgBox.Options.yesNo,
                        MsgBox.MsgIcon.EXCL) == "Yes")
            {
                File.Delete(Dir + "/" + PanelName);
                Delete();
            }
        }

        private void RenameStrip_Click(object sender, EventArgs e)
        {
            string newName = TextInput.GetInputWait("Enter a new name for your file.",
                        "Rename",
                        PanelName,
                        x => TextInput.dirNameValid(x) && !Exists(Dir + x));

            if (newName != "")
            {
                try
                {
                    File.Move(Dir + PanelName,
                              Dir + newName);

                    ChangeName(newName);
                }
                catch (Exception ex)
                {
                    MsgBox.ShowWait("Error renaming file." + Helper.twoLines + "Reason: " + ex.Message,
                        "Error",
                        MsgBox.Options.ok,
                        MsgBox.MsgIcon.ERROR);
                }
            }
        }

        protected override bool InEditingMode()
        {
            return RevisionExplorer.EditingList.Contains(Dir + PanelName);
        }

        protected override void EditingChanges(bool editing)
        {
            Enabled = !editing;
        }
    }
}
