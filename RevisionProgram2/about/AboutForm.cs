using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.about
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);

            // Load icon and version data.
            IconBox.Image = Properties.Resources.Revision_Program.ToBitmap();
            VersionLbl.Text = "Version: " + ProductVersion;
        }

        bool moving;
        Point offset;

        const float gravity = 1f, velCap = 15f;
        float yVel = 0f;

        private void IconBox_MouseDown(object sender, MouseEventArgs e)
        {
            offset = IconBox.PointToClient(MousePosition);
            moving = true;
            TimerMain.Enabled = true;
        }

        private void IconBox_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            yVel = 0;
        }

        private void IconBox_MouseLeave(object sender, EventArgs e)
        {
            moving = false;
            yVel = 0;
        }

        private void GitLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(GitLink.Text);
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            if (moving)
            {
                Point point = PointToClient(MousePosition);
                
                IconBox.Left = (int)Helper.Clamp(point.X - offset.X, 0, ClientRectangle.Width - IconBox.Width);
                IconBox.Top = (int)Helper.Clamp(point.Y - offset.Y, 0, ClientRectangle.Height - IconBox.Height);
            } else if (IconBox.Bottom != ClientRectangle.Height)
            {
                yVel += gravity;
                yVel = Math.Min(velCap, yVel);

                IconBox.Top += (int)Math.Min(yVel, velCap);
            }

            if (IconBox.Bottom > ClientRectangle.Height)
            {
                IconBox.Top = ClientRectangle.Height - IconBox.Height;
                yVel = 0;
            }

            Refresh();
        }
    }
}
