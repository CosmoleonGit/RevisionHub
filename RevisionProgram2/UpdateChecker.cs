using RevisionProgram2.dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2
{
    public static class UpdateChecker
    {
        public static void Check()
        {
            Do();
        }

        public static void SilentCheck()
        {
            Do(true);
        }

        static void Do(bool quiet = false)
        {
            string savePath = $"{Helper.directory}temp/info.txt";

            string newVer = null;

            WaitingForm.BeginWait("Checking for updates...", ev =>
            {
                try
                {
                    using (var wc = new WebClient())
                    {
                        wc.DownloadFile($"https://github.com/CosmoleonGit/RevisionHub/raw/master/info.txt", savePath);
                    }

                    using (var sr = new StreamReader(savePath))
                    {
                        newVer = sr.ReadLine();
                    }
                }
                catch (WebException ex)
                {
                    if (!quiet) Helper.Error("Failed to load pack data.", "Reason: " + ex.Message);
                } finally
                {
                    File.Delete(savePath);
                }


            });

            if (newVer != null)
            {
                var ver = Assembly.GetEntryAssembly().GetName().Version;

                string curVer = Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf('.'));

                if (curVer != newVer)
                {
                    if (MsgBox.ShowWait($"There is a new version of Revision Hub (v{newVer})." + Helper.twoLines + "Would you like to go to the download page?",
                                    "Check for Updates",
                                    MsgBox.Options.yesNo,
                                    MsgBox.MsgIcon.INFO) == "Yes")
                    {
                        Process.Start("https://github.com/CosmoleonGit/RevisionHub/releases/tag/" + newVer);
                    }
                }
                else if (!quiet)
                {
                    MsgBox.ShowWait("You are running the latest version of Revision Hub.",
                            "Check for Updates",
                            null,
                            MsgBox.MsgIcon.TICK);
                }
            }
        }
    }
}
