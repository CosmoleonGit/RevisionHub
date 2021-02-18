using RevisionProgram2.about;
using RevisionProgram2.alerts;
using RevisionProgram2.dialogs;
using RevisionProgram2.folderSync;
using RevisionProgram2.news;
using RevisionProgram2.packs;
using RevisionProgram2.Properties;
using RevisionProgram2.revision;
using RevisionProgram2.Themes;
using RevisionProgram2.tools;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace RevisionProgram2
{
    public partial class RevisionHub : Form
    {
        #region Simulate Show Dialog

        const int GWL_STYLE = -16;
        const int WS_DISABLED = 0x08000000;

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public bool IsEnabled { get; private set; }

        internal void SetNativeEnabled(bool enabled)
        {
            IsEnabled = enabled;

            SetWindowLong(Handle, GWL_STYLE, GetWindowLong(Handle, GWL_STYLE) &
                ~WS_DISABLED | (enabled ? 0 : WS_DISABLED));
        }

        #endregion

        public RevisionHub()
        {
            InitializeComponent();
        }

        ContextMenuStrip barIconContext;
        bool closing;

        private void RevisionHub_Load(object sender, EventArgs e)
        {
            // Set icon
            Icon = Resources.Revision_Program;

            // Create the directory for Revision Program data.
            Directory.CreateDirectory(Helper.directory);
            Theme.LoadThemes();

            InitBarContext();

            // Load alerts and set notify icon click event.
            Alert.LoadAlerts();
            Alert.NotifyIcon.MouseClick += NotifyClick;

            
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

#if DEBUG
            Debug();
#endif
        }

        void InitBarContext()
        {
            barIconContext = new ContextMenuStrip();

#region Add explorer strip

            var explorerStrip = new ToolStripMenuItem()
            {
                Text = "Revision Explorer",
            };

            explorerStrip.Font = Font;

            explorerStrip.Click += (s, ev) =>
            {
                OpenExplorer();
            };

            barIconContext.Items.Add(explorerStrip);

#endregion

            barIconContext.Items.Add(new ToolStripSeparator());

#region Add notepad strip

            var notepadStrip = new ToolStripMenuItem()
            {
                Text = "Notepad",
            };

            notepadStrip.Font = Font;

            notepadStrip.Click += (s, ev) =>
            {
                OpenNotepad();
            };

            barIconContext.Items.Add(notepadStrip);

#endregion

#region Add stopwatch/timer strip

            var timerStopStrip = new ToolStripMenuItem()
            {
                Text = "Stopwatch/Timer"
            };

            timerStopStrip.Font = Font;

            timerStopStrip.Click += (s, ev) =>
            {
                OpenTimer();
            };

            barIconContext.Items.Add(timerStopStrip);

#endregion

            barIconContext.Items.Add(new ToolStripSeparator());

#region Add alerts strip

            var alertsStrip = new ToolStripMenuItem()
            {
                Text = "Show Reminders"
            };

            alertsStrip.Font = Font;

            alertsStrip.Click += (s, ev) =>
            {
                Alert.ShowForm();
            };

            barIconContext.Items.Add(alertsStrip);

#endregion

            barIconContext.Items.Add(new ToolStripSeparator());

#region Add exit strip

            var exitStrip = new ToolStripMenuItem()
            {
                Text = "Exit"
            };

            exitStrip.Font = Font;

            exitStrip.Click += (s, ev) =>
            {
                if (MsgBox.ShowWait("Are you sure you want to close the Revision Hub?",
                                "Close",
                                MsgBox.Options.yesNo,
                                MsgBox.MsgIcon.EXCL) == "Yes")
                {
                    closing = true;
                    Close();
                }
            };

            barIconContext.Items.Add(exitStrip);

#endregion
        }

        private void NotifyClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // If left clicked, show all open forms.

                foreach (Form form in Application.OpenForms) { form.Show(); }
            }
            else if (e.Button == MouseButtons.Right)
            {
                // If right clicked, display bar icon context.
                barIconContext.Show(MousePosition);
                barIconContext.BringToFront();
            }
        }

        private void Debug()
        {
            // Debug code here
        }

        private void RevisionHub_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing && e.CloseReason == CloseReason.UserClosing)
            {
                FormCollection openForms = Application.OpenForms;
                
                if (openForms.Count < 2)
                {
                    Hide();
                }
                else if (MsgBox.ShowWait("This will hide all windows in the Revision Hub" + Helper.twoLines + "Do you want to proceed?",
                                     "Closure",
                                     MsgBox.Options.yesNo, MsgBox.MsgIcon.EXCL) == "Yes")
                {
                    foreach (Form f in openForms) { f.Hide(); }
                }

                e.Cancel = true;
            }
            else
            {
                // Hides the alert icon because Windows won't do it itself for some reason
                
                Alert.NotifyIcon.Visible = false;
                Alert.NotifyIcon.Dispose();
            }
        }

        ThemeChange themeChange;
        private void ThemeChangeBtn_Click(object sender, EventArgs e)
        {
            if (themeChange == null || themeChange.IsDisposed)
            {
                themeChange = new ThemeChange();
            }

            themeChange.Show();
            themeChange.BringToFront();
        }

        Notepad notepad;

        private void NotepadBtn_Click(object sender, EventArgs e)
        {
            
            OpenNotepad();
            //notepad.BringToFront();
        }

        void OpenNotepad()
        {
            if (notepad == null || notepad.IsDisposed)
            {
                notepad = new Notepad();
            }

            notepad.Show();
        }

        public static RevisionExplorer explorer;
        private void ReviseBtn_Click(object sender, EventArgs e)
        {
            OpenExplorer();
        }

        public static void OpenExplorer()
        {
            if (explorer == null || explorer.IsDisposed)
            {
                explorer = new RevisionExplorer();
            }

            explorer.Show();
            explorer.BringToFront();
        }

        private void AlertsBtn_Click(object sender, EventArgs e)
        {
            Alert.ShowForm();
        }

        private void RevisionHub_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.L)
                {
                    Theme.ChangeGlobalTheme(0);
                }
                else if (e.KeyCode == Keys.D)
                {
                    Theme.ChangeGlobalTheme(1);
                }
            }

        }

        static TimerStopwatch timerStopwatch = new TimerStopwatch();

        private void TimerBtn_Click(object sender, EventArgs e)
        {
            OpenTimer();
        }

        static void OpenTimer()
        {
            if (timerStopwatch.IsDisposed)
            {
                timerStopwatch = new TimerStopwatch();
            }

            timerStopwatch.Show();
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            // TODO Add settings menu
        }

        static AboutForm aboutForm = new AboutForm();

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            if (aboutForm.IsDisposed)
            {
                aboutForm = new AboutForm();
            }

            aboutForm.Show();
            aboutForm.BringToFront();
        }

        private void NewsBtn_Click(object sender, EventArgs e)
        {
            NewsForm.LoadNews();
        }

        private void PacksBtn_Click(object sender, EventArgs e)
        {
            Pack.ShowPacks();
        }

        private void UpdatesBtn_Click(object sender, EventArgs e)
        {
            UpdateChecker.Check();
        }

        private void SyncDriveBtn_Click(object sender, EventArgs e)
        {
            var chooseDrive = new ChooseDrive();

            SetNativeEnabled(false);

            chooseDrive.FormClosing += (s, ev) =>
            {
                SetNativeEnabled(true);

                if (chooseDrive.DialogResult == DialogResult.OK)
                {
                    ReadySync(() => FolderSync.Sync(new DriveSync($"{chooseDrive.GetDrive}Revision/")));
                }
            };

            chooseDrive.Show();
        }

        private void SyncOnlineBtn_Click(object sender, EventArgs e)
        {
            var onlineChoose = new OnlineChoose();

            SetNativeEnabled(false);

            onlineChoose.FormClosing += (s, ev) =>
            {
                SetNativeEnabled(true);

                if (onlineChoose.DialogResult == DialogResult.OK)
                {
                    if (onlineChoose.Host)
                    {
                        ReadySync(() => FolderSync.Sync(new ServerSync(onlineChoose.Port)));
                    }
                    else
                    {
                        ReadySync(() => FolderSync.Sync(new ClientSync(onlineChoose.IP, onlineChoose.Port)));
                    }
                }
            };

            onlineChoose.Show();
        }

        void ReadySync(Action action)
        {
            bool changeEnabled = explorer != null && !explorer.IsDisposed && explorer.IsEnabled;

            if (changeEnabled)
            {
                explorer.SetNativeEnabled(false);
            }

            action();

            if (changeEnabled)
            {
                explorer.SetNativeEnabled(true);
                explorer.RefreshPanels();
            }
        }
    }
}
