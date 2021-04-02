using RevisionProgram2.dialogs;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.news
{
    public partial class NewsForm : Form
    {
        public NewsForm(string news)
        {
            InitializeComponent();
            
            NewsTxt.Rtf = news;
        }

        public static void LoadNews()
        {
            string savePath = $"{Helper.directory}temp/news.txt";

            string news = null;

            WaitingForm.BeginWait("Downloading notices...", ev =>
            {
                try
                {
                    using (var wc = new WebClient())
                    {
                        wc.DownloadFile($"https://github.com/CosmoleonGit/RevisionHub/raw/master/News.rtf", savePath);
                    }

                    news = File.ReadAllText(savePath);

                    File.Delete(savePath);
                }
                catch (WebException ex)
                {
                    Helper.Error("Failed to load pack data.", ex.Message);
                }
            });

            if (news != null)
            {
                var newsForm = new NewsForm(news);
                newsForm.Show();
            }
        }

        private void NewsForm_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
        }

        private void NewsTxt_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            LaunchWeblink(e.LinkText);
        }

        // Performs the actual browser launch to follow link:
        private void LaunchWeblink(string url)
        {
            if (IsHttpURL(url)) Process.Start(url);
        }

        // Simple check to make sure link is valid.
        private bool IsHttpURL(string url)
        {
            return
                (!string.IsNullOrWhiteSpace(url)) &&
                (url.ToLower().StartsWith("http") || url.ToLower().StartsWith("https"));
        }
    }
}
