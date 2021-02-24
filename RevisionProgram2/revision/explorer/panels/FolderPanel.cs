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
    public partial class FolderPanel : ItemPanel
    {
        public static void Create(string dir, Action<string> onCreate)
        {
            TextInput.GetInput("Enter a name for your folder.", "Folder", name =>
            {
                onCreate(name);
            }, "", s =>
            {
                return TextInput.dirNameValid(s) && !Helper.Exists(dir + s);
            });
        }

        public FolderPanel(Panel owner, string name, string path) : base(owner, name, path)
        {
            InitializeComponent();
        }

        protected override bool InEditingMode()
        {
            return RevisionExplorer.EditingList.Any(x => x.StartsWith($"{Dir}{PanelName}"));
        }

        private void MoveStrip_Click(object sender, EventArgs e)
        {
            GetForm.BeginMove(this);
        }

        private void DeleteStrip_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowWait("Are you sure you want to delete this folder?", "Delete", MsgBox.Options.yesNo, MsgBox.MsgIcon.EXCL) == "Yes")
            {
                Directory.Delete(Dir + PanelName, true);

                Delete();
            }
        }

        private void RenameStrip_Click(object sender, EventArgs e)
        {
            GetForm.SetNativeEnabled(false);

            TextInput.GetInput("Enter a new name for your folder.",
                               "Rename",
                               newName =>
                               {
                                   GetForm.SetNativeEnabled(true);

                                   if (newName != "")
                                   {
                                       try
                                       {
                                           Directory.Move(Dir + PanelName, Dir + newName);

                                           ChangeName(newName);
                                       }
                                       catch (Exception ex)
                                       {
                                           Helper.Error("Error renaming file.", $"Reason: {ex.Message}");
                                       }
                                   }
                               },
                               PanelName,
                               x => TextInput.dirNameValid(x) && !Directory.Exists(Dir + x));
        }

        protected override void OnChange()
        {
            OptionsContext.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        public override void OnClick()
        {
            string s = GetForm.CurrentDirectory;
            GetForm.OpenDir(s + ((s != "") ? "/" : "") + PanelName);
        }

        protected override Image GetIcon()
        {
            return Properties.Resources.Folder;
        }

        public override void MoveItem(string path)
        {
            Directory.Move(Dir + PanelName, path + PanelName);
            Dir = path;
        }
    }
}
