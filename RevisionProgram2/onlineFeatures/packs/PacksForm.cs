using RevisionProgram2.dialogs;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.packs
{
    public partial class PacksForm : Form
    {
        public PacksForm(Pack[] _packs)
        {
            InitializeComponent();

            packs = _packs;
        }

        readonly Pack[] packs;

        private void PacksForm_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;

            RefreshPackList();
        }

        void RefreshPackList()
        {
            PacksList.Items.Clear();

            foreach (Pack pack in packs)
            {
                if (pack.packName.ToLower().Contains(SearchTxt.Text.ToLower()))
                    PacksList.Items.Add(pack.packName);
            }
        }

        private void PacksList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PacksList.SelectedIndex != -1)
            {
                DescLbl.Text = packs[PacksList.SelectedIndex].description;
                OverwritePanel.Visible = Directory.Exists($"{Helper.directory}Revision/Downloaded Packs/{PacksList.SelectedItem}");
            }

            DownloadBtn.Enabled = PacksList.SelectedIndex != -1;
        }

        private void DownloadBtn_Click(object sender, EventArgs e)
        {
            string packName = PacksList.SelectedItem.ToString();

            string savePath = $"{Helper.directory}temp/{packName}.zip";

            string moveToPath = $"{Helper.directory}Revision/Downloaded Packs/{packName}";

            // Check if a folder with that name already exists.
            if (OverwritePanel.Visible)
            {
                if (MsgBox.ShowWait($"A folder with this name already exists." +
                                    $"\n\n" +
                                    $"Do you want to overwrite it?",
                    "Overwrite File",
                    MsgBox.Options.yesNo,
                    MsgBox.MsgIcon.EXCL) == "Yes")
                {
                    Directory.Delete(moveToPath, true);
                } else { return; }
            }

            // Download the pack from GitHub.
            bool worked = false;

            WaitingForm.BeginWait("Downloading and extracting pack...", ev =>
            {
                try
                {
                    using (var wc = new WebClient())
                    {
                        wc.DownloadFile($"https://github.com/CosmoleonGit/RevisionProgram/raw/master/Packs/{packName}.zip", savePath);
                    }
                    
                    worked = true;
                }
                catch (WebException ex)
                {
                    Helper.Error("Failed to download pack.", ex.Message);
                }

                if (worked)
                {
                    worked = false;

                    try
                    {
                        Directory.CreateDirectory($"{Helper.directory}Revision/Downloaded Packs");
                        
                        ZipFile.ExtractToDirectory(savePath,
                                                   moveToPath);

                        File.Delete(savePath);
                        worked = true;
                    }
                    catch (Exception ex)
                    {
                        Helper.Error("Failed to download pack.", ex.Message);
                    }
                }
            });

            // If downloading was successful, extract the file.
            if (worked)
            {
                if (MsgBox.ShowWait($"Successfully downloaded {packName}! You will find it in your Revision folder." +
                                    $"\n\n" +
                                    $"Would you like to go to it now?",
                            "Finished",
                            MsgBox.Options.yesNo,
                            MsgBox.MsgIcon.TICK) == "Yes")
                {
                    RevisionHub.OpenExplorer();
                    RevisionHub.explorer.OpenDir($"Downloaded Packs/{packName}");
                    Close();
                } else
                {
                    PacksList.SelectedIndex = -1;
                }

                
            }
        }

        private void SearchTxt_TextChanged(object sender, EventArgs e)
        {
            RefreshPackList();
        }
    }
}
