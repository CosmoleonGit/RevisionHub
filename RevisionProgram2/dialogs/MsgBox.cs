using RevisionProgram2.Themes;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace RevisionProgram2.dialogs
{
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
        }

        private string result = "";

        public static void Show(string message, Action<string> onReturn, string title = "Title", string[] options = null, MsgIcon icon = 0)
        {
            var msgBox = GetMsgBox(message, title, options, icon);

            msgBox.FormClosing += (s, e) =>
            {
                onReturn(msgBox.result);
            };

            msgBox.Show();
        }

        public static string ShowWait(string message, string title = "Title", string[] options = null, MsgIcon icon = 0)
        {
            var msgBox = GetMsgBox(message, title, options, icon);

            // Show message box and return the result.
            msgBox.ShowDialog();
            return msgBox.result;
        }

        static MsgBox GetMsgBox(string message, string title = "Title", string[] options = null, MsgIcon icon = 0)
        {
            if (options == null || options.Length == 0) options = new string[] { "OK" };

            MsgBox msgBox = new MsgBox
            {
                MinimumSize = new Size(100, 0),
                Text = title
            };

            Label messageLbl = new Label
            {
                Top = 20,
                AutoSize = true,
                Left = 12,
                MaximumSize = new Size(350, 0),
                Text = message,
                Font = msgBox.Font
            };
            messageLbl.Size = messageLbl.PreferredSize;

            msgBox.Controls.Add(messageLbl);

            if (icon != 0)
            {
                PictureBox img = new PictureBox
                {
                    Location = new Point(12, Math.Max(12, (messageLbl.Top + messageLbl.Bottom) / 2 - messageLbl.Height / 2)),
                    Size = new Size(32, 32)
                };

                messageLbl.Left = img.Right + 6;

                // Assign message box icon and play sound
                if (icon == MsgIcon.ERROR)
                {
                    img.Image = Properties.Resources.Error;
                    SystemSounds.Hand.Play();
                }
                else if (icon == MsgIcon.EXCL)
                {
                    img.Image = Properties.Resources.Exclamation;
                    SystemSounds.Exclamation.Play();
                }
                else if (icon == MsgIcon.TICK)
                {
                    img.Image = Properties.Resources.Tick;
                    SystemSounds.Asterisk.Play();
                }
                else
                {
                    img.Image = Properties.Resources.Information;
                    SystemSounds.Asterisk.Play();
                }

                msgBox.Controls.Add(img);
            }

            //messageLbl.Left = msgBox.PreferredSize.Width + 6;

            int btnRight = msgBox.PreferredSize.Width + 6;
            //int btnTop = msgBox.PreferredSize.Height + 6;
            int btnTop = messageLbl.Bottom + 20;

            for (int i = 0; i < options.Length; i++)
            {
                Button btn = new Button
                {
                    FlatStyle = FlatStyle.Flat,
                    Top = btnTop,
                    Size = new Size(99, 36),
                    Left = btnRight - ((99 + 6) * (options.Length - i)),
                    Text = options[i]
                };

                btn.FlatAppearance.BorderSize = 0;

                btn.Click += (s, e) =>
                {
                    msgBox.result = btn.Text;
                    msgBox.Close();
                };

                msgBox.Controls.Add(btn);
            }

            // Fitting form to controls
            msgBox.Width = msgBox.PreferredSize.Width + 6;
            msgBox.Height = msgBox.PreferredSize.Height + 6;

            return msgBox;
        }

        public enum MsgIcon
        {
            NONE,
            ERROR,
            EXCL,
            INFO,
            TICK
        }

        public static class Options
        {
            public readonly static string[] ok = new string[] { "OK" };
            public readonly static string[] yesNo = new string[] { "Yes", "No" };
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
        }
    }
}
