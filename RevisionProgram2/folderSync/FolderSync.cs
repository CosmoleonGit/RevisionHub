using RevisionProgram2.dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.folderSync
{
    public static class FolderSync
    {
        public static void Sync(FolderSyncInterface fsi)
        {
            if (!fsi.Setup()) return;

            var dir = $"{Helper.directory}Revision/";
            var di = new DirectoryInfo(dir);

            Queue<string> filePushQueue = null;
            Queue<string> filePullQueue = null;

            void QueuePushes()
            {
                try
                {
                    ProgressForm.BeginWait("Queueing file pushes...", progress =>
                    {
                        filePushQueue = fsi.FilesToPush(progress);
                    });
                } catch (Exception e)
                {
                    Helper.Error("Failed to sync files.", e.Message);
                }
            };

            void QueuePulls()
            {
                try
                {
                    ProgressForm.BeginWait("Queueing file pulls...", progress =>
                    {
                        filePullQueue = fsi.FilesToPull(progress);
                    });
                } catch (Exception e)
                {
                    Helper.Error("Failed to sync files.", e.Message);
                }
            }

            void PushFiles()
            {
                ProgressForm.BeginWait("Pushing files...", progress =>
                {
                    try
                    {
                        int amount = filePushQueue.Count;
                        for (int i = 0; i < amount; i++)
                        {
                            fsi.PushFile(filePushQueue.Dequeue());
                            progress.Report((float)i / amount);
                        }
                    }
                    catch (Exception e)
                    {
                        Helper.Error("Failed to copy file.", e.Message);
                    }
                });
            }

            void PullFiles()
            {
                ProgressForm.BeginWait("Pulling files...", progress =>
                {
                    try
                    {
                        int amount = filePullQueue.Count;
                        for (int i = 0; i < amount; i++)
                        {
                            fsi.PullFile(filePullQueue.Dequeue());
                            progress.Report((float)i / amount);
                        }
                    }
                    catch (Exception e)
                    {
                        Helper.Error("Failed to copy file.", e.Message);
                    }
                });
            };

            if (fsi.PushFirst)
            {
                QueuePushes();
                QueuePulls();
            } else
            {
                QueuePulls();
                QueuePushes();
            }

            if (fsi.PushFirst)
            {
                PushFiles();
                PullFiles();
            }
            else
            {
                PullFiles();
                PushFiles();
            }

            fsi.Finish();

            MsgBox.ShowWait("Successfully synchronized all files.", "Sync", null, MsgBox.MsgIcon.TICK);
        }
    }
}
