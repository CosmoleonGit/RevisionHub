using RevisionProgram2.dialogs;
using RevisionProgram2.revision.documents;
using RevisionProgram2.revision.explorer;
using RevisionProgram2.revision.flashcards;
using RevisionProgram2.revision.tests;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using RevisionProgram2.revision.explorer.panels;
using System.Runtime.InteropServices;

namespace RevisionProgram2.revision
{
    public partial class RevisionExplorer : Form
    {
        #region Simulate Show Dialog

        const int GWL_STYLE = -16;
        const int WS_DISABLED = 0x08000000;

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public bool IsEnabled { get; private set; } = true;

        internal void SetNativeEnabled(bool enabled)
        {
            IsEnabled = enabled;

            SetWindowLong(Handle, GWL_STYLE, GetWindowLong(Handle, GWL_STYLE) &
                ~WS_DISABLED | (enabled ? 0 : WS_DISABLED));
        }

        #endregion

        public RevisionExplorer()
        {
            InitializeComponent();
        }

        public const int itemSpacing = 10;
        static readonly List<string> editingPaths = new List<string>();

        public static IEnumerable<string> EditingList => editingPaths.AsEnumerable();

        public void BeginEditing(string s)
        {
            editingPaths.Add(s);
            UpdatePanelEditing();
            UpdateMarathonEnabled();
        }

        public void StopEditing(string s)
        {
            editingPaths.Remove(s);
            UpdatePanelEditing();
            UpdateMarathonEnabled();
        }



        void UpdatePanelEditing()
        {
            foreach (ItemPanel panel in ListPanel.Controls)
            {
                panel.CheckEditing();
            }
        }
        public void AddPanel(ItemPanel panel, bool scrollToEnd = false)
        {
            panel.Top = ((ListPanel.Controls.Count != 0) ?
                        ListPanel.Controls[ListPanel.Controls.Count - 1].Bottom : 0)
                        + itemSpacing - 2;

            if (ListPanel.Controls.Count == 0)
                panel.Width = ListPanel.Width - 20;
            else
                panel.Width = ListPanel.Controls[0].Width;

            ListPanel.Controls.Add(panel);

            if (scrollToEnd)
            {
                ListPanel.VerticalScroll.Value = 0;
                ListPanel.ScrollControlIntoView(panel);
            }
        }

        public string CurrentDirectory { get; private set; }

        public void OpenDir(string value)
        {
            // Resets the search text.
            searchTxt.Text = "";

            // Set directory variable.
            CurrentDirectory = value;

            // Sets control properties on the form
            PathLbl.Text = "Revision/" + value;
            UpToBtn.Enabled = value != "";

            if (moveItem != null) MoveHereBtn.Enabled = !(CurrentDirectory + "/" + moveItem.PanelName).StartsWith(MovePathLbl.Text);

            #region Load Item Panels
            ListPanel.Controls.Clear();

            DirectoryInfo di = new DirectoryInfo(GetFullDir);

            if (!di.Exists)
            {
                Helper.Error("Failed to open folder.", "The folder does not exist.");
                return;
            }

            ListPanel.AutoScroll = false;

            // Add folders

            foreach (DirectoryInfo foundDir in di.GetDirectories("*", SearchOption.TopDirectoryOnly))
            {
                AddPanel(new FolderPanel(ListPanel, foundDir.Name, GetFullDir));
            }

            foreach (FileInfo foundFile in di.GetFiles("*", SearchOption.TopDirectoryOnly))
            {
                using (StreamReader reader = new StreamReader(foundFile.FullName))
                {
                    switch (reader.ReadLine() ?? "")
                    {
                        case "TEST":
                            // Add tests
                            AddPanel(new TestPanel(ListPanel, foundFile.Name, GetFullDir));
                            break;
                        case "FLASHCARDS":
                            // Add flashcards
                            AddPanel(new FlashcardsPanel(ListPanel, foundFile.Name, GetFullDir));
                            break;
                        case "DOCUMENT":
                            // Add document
                            AddPanel(new DocumentPanel(ListPanel, foundFile.Name, GetFullDir));
                            break;
                    }
                }
            }

            ListPanel.AutoScroll = true;
            #endregion

            UpdateMarathonEnabled();
        }

        private string GetDirNoSlash => Helper.LocalDirectory + CurrentDirectory;
        private string GetFullDir => GetDirNoSlash + ((CurrentDirectory != "") ? "/" : "");

        private void RevisionExplorer_Load(object sender, EventArgs e)
        {
            // Create the revision directory.
            //Directory.CreateDirectory(Helper.directory + "Revision");

            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;

            // Load item panels.
            //CurDir = "";
            OpenDir("");
        }

        private void AddFolderBtn_Click(object sender, EventArgs e)
        {
            SetNativeEnabled(false);

            FolderPanel.Create(GetFullDir, folderName =>
            {
                SetNativeEnabled(true);

                if (folderName != "" && Directory.CreateDirectory(GetFullDir + folderName).Exists)
                {
                    AddPanel(new FolderPanel(ListPanel, folderName, GetFullDir), true);
                };
            });
        }

        private void AddTestBtn_Click(object sender, EventArgs e)
        {
            SetNativeEnabled(false);
            BeginEditing(GetFullDir);
            Test.Create(GetFullDir, 
                () =>
                {
                    SetNativeEnabled(true);
                },
                (n, d) =>
                {
                    if (n != "" && d == GetFullDir) AddPanel(new TestPanel(ListPanel, n, GetFullDir), true);
                    StopEditing(d);
                });
        }

        private void AddFlashcardsBtn_Click(object sender, EventArgs e)
        {
            SetNativeEnabled(false);
            BeginEditing(GetFullDir);
            Flashcards.Create(GetFullDir,
                () =>
                {
                    SetNativeEnabled(true);
                },
                (n, d) =>
                {
                    if (n != "" && d == GetFullDir) AddPanel(new FlashcardsPanel(ListPanel, n, GetFullDir), true);
                    StopEditing(d);
                });
        }

        private void DocumentBtn_Click(object sender, EventArgs e)
        {
            SetNativeEnabled(false);
            BeginEditing(GetFullDir);
            Document.Create(GetFullDir,
                () =>
                {
                    SetNativeEnabled(true);
                },
                (n, d) =>
                {
                    if (n != "" && d == GetFullDir) AddPanel(new DocumentPanel(ListPanel, n, GetFullDir), true);
                    StopEditing(d);
                });
        }

        public void ResetSearch() => searchTxt.Text = "";

        private void UpToBtn_Click(object sender, EventArgs e)
        {
            int last = CurrentDirectory.Substring(0, CurrentDirectory.Length - 1).LastIndexOf("/");
            //CurDir = (last != -1) ? CurDir.Substring(0, last) : "";
            OpenDir((last != -1) ? CurrentDirectory.Substring(0, last) : "");
         }

        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            ListPanel.VerticalScroll.Value = 0;

            int num = 0;
            foreach (ItemPanel panel in ListPanel.Controls)
            {
                panel.Visible = panel.SuitsCondition(searchTxt.Text);
                if (panel.Visible)
                {
                    panel.Top = (panel.Height - 2) * num;
                    panel.Top += ((num + 1) * (itemSpacing)) - 2;
                    num++;
                }
            }
        }

        void UpdateMarathonEnabled()
        {
            MarathonBtn.Enabled = false;

            foreach (ItemPanel c in ListPanel.Controls)
            {
                if (!c.EditMode && (c is FlashcardsPanel || c is TestPanel))
                {
                    MarathonBtn.Enabled = true;
                }
            }
        }

        ItemPanel moveItem;

        private void MoveHereBtn_Click(object sender, EventArgs e)
        {
            try
            {
                moveItem.MoveItem(GetFullDir);
                AddPanel(moveItem, true);
            } catch (Exception ex)
            {
                Helper.Error("Failed to move item.", ex.Message);
            }

            moveItem = null;

            MoveGroup.Visible = false;
        }

        private void CancelMoveBtn_Click(object sender, EventArgs e)
        {
            moveItem = null;
            MoveGroup.Visible = false;
        }

        public void BeginMove(ItemPanel item)
        {
            moveItem = item;
            MovePathLbl.Text = CurrentDirectory + (CurrentDirectory != "" ? "/" : "") + item.PanelName;
            
            MoveHereBtn.Enabled = false;
            MoveGroup.Visible = true;
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            RefreshPanels();
        }

        public void RefreshPanels() =>
            OpenDir(CurrentDirectory);

        private void MoveGroup_VisibleChanged(object sender, EventArgs e)
        {
            if (MoveGroup.Visible)
            {
                ListPanel.Height = MoveGroup.Top - ListPanel.Top - 6;
            } else
            {
                ListPanel.Height = MoveGroup.Bottom - ListPanel.Top;
            }
        }

        private void MarathonBtn_Click(object sender, EventArgs e)
        {
            var list = new List<FilePanel>();

            foreach (ItemPanel c in ListPanel.Controls)
            {
                if (!c.EditMode && (c is FlashcardsPanel || c is TestPanel))
                {
                    list.Add(c as FilePanel);
                }
            }
            
            SetNativeEnabled(false);

            var mf = new MarathonForm(list.ToArray());

            mf.FormClosing += (s, ev) => 
            {
                SetNativeEnabled(true);
            };

            mf.Show();
        }
    }
}
