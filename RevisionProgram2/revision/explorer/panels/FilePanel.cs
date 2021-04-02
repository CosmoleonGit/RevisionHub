using RevisionProgram2.dialogs;
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
    public partial class FilePanel : ItemPanel
    {
        public FilePanel()
        {
            InitializeComponent();
        }

        public FilePanel(Panel owner, string name, string path) : base(owner, name, path)
        {
            InitializeComponent();
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

        protected override bool InEditingMode()
        {
            return RevisionExplorer.EditingList.Contains(Dir + PanelName);
        }

        protected ContextMenuStrip GetContext => OptionsContext;

        protected override void EditingChanges(bool editing)
        {
            Enabled = !editing;
        }

        private void EditStrip_Click(object sender, EventArgs e)
        {
            Edit();
        }

        public override void OnClick()
        {
            StartAssessment(null);
        }

        public virtual void StartAssessment(Action onFinish) { }
        public virtual void Edit() { }

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
                try
                {
                    File.Delete($"{Dir}/{PanelName}");
                    Delete();
                }
                catch (Exception ex)
                {
                    Helper.Error("Error moving file.", ex.Message);
                }
            }
        }

        private void RenameStrip_Click(object sender, EventArgs e)
        {
            GetForm.SetNativeEnabled(false);

            TextInput.GetInput("Enter a new name for your file.",
                               "Rename",
                               newName =>
                               {
                                   GetForm.SetNativeEnabled(true);

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
                                           Helper.Error("Error renaming file.", ex.Message);
                                       }
                                   }
                               },
                               PanelName,
                               x => TextInput.dirNameValid(x) && !Exists(Dir + x));
        }

        private void DuplicateStrip_Click(object sender, EventArgs e)
        {
            Duplicate();
        }

        public virtual void Duplicate() { }
    }
}
