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

            bool QueuePushes()
            {
                bool success = false;
                ProgressForm.BeginWait("Queueing file pushes...", progress =>
                {
                    success = (filePushQueue = fsi.FilesToPush(progress)) != null;
                });
                return success;
            };

            bool QueuePulls()
            {
                bool success = false;
                ProgressForm.BeginWait("Queueing file pulls...", progress =>
                {
                    success = (filePullQueue = fsi.FilesToPull(progress)) != null;
                });
                return success;
            }

            bool PushFiles()
            {
                bool success = true;
                ProgressForm.BeginWait("Pushing files...", progress =>
                {
                    int amount = filePushQueue.Count;
                    for (int i = 0; i < amount; i++)
                    {
                        if (fsi.PushFile(filePushQueue.Dequeue()))
                            progress.Report((float)i / amount);
                        else
                        {
                            success = false;
                            break;
                        }
                    }
                });
                return success;
            }

            bool PullFiles()
            {
                bool success = true;
                ProgressForm.BeginWait("Pulling files...", progress =>
                {
                    int amount = filePullQueue.Count;
                    for (int i = 0; i < amount; i++)
                    {
                        if (fsi.PullFile(filePullQueue.Dequeue()))
                            progress.Report((float)i / amount);
                        else
                        {
                            success = false;
                            break;
                        }
                    }
                });
                return success;
            };

            if (fsi.PushFirst)
            {
                if (!QueuePushes()) goto error;
                if (!QueuePulls())  goto error;
            } else
            {
                if (!QueuePulls())  goto error;
                if (!QueuePushes()) goto error;
            }

            if (fsi.PushFirst)
            {
                if (!PushFiles()) goto error;
                if (!PullFiles()) goto error;
            }
            else
            {
                if (!PullFiles()) goto error;
                if (!PushFiles()) goto error;
            }

            fsi.Finish();

            MsgBox.ShowWait("Successfully synchronized all files.", "Sync", null, MsgBox.MsgIcon.TICK);
            return;

        error:
            fsi.Finish();

            MsgBox.ShowWait("File sync was not completed successfully.", "Sync", null, MsgBox.MsgIcon.EXCL);
            return;
        }
    }
}
