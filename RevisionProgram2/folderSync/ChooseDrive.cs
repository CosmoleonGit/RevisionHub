using RevisionProgram2.Themes;
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

namespace RevisionProgram2.folderSync
{
    public partial class ChooseDrive : Form
    {
        public ChooseDrive()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ChooseDrive_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            RefreshDrives();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            RefreshDrives();
        }

        void RefreshDrives()
        {
            var drives = DriveInfo.GetDrives();

            DriveCombo.Items.Clear();
            
            foreach (var drive in drives)
            {
                if (drive.IsReady)
                    DriveCombo.Items.Add(drive.Name);
            }

            if (DriveCombo.Items.Count > 0)
            {
                DriveCombo.SelectedIndex = 0;
            }
        }

        private void DriveCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            OKBtn.Enabled = DriveCombo.SelectedIndex != -1;
        }

        public string GetDrive => DriveCombo.SelectedItem.ToString();
    }
}
