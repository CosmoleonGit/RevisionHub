using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.folderSync
{
    public class DriveSync : FolderSyncInterface
    {
        public DriveSync(string externalDir)
        {
            externalDirectory = externalDir;
            Directory.CreateDirectory(externalDirectory);
        }

        public override bool Setup()
        {
            /*
            var chooseDrive = new ChooseDrive();

            if (chooseDrive.ShowDialog() == DialogResult.OK)
            {
                externalDirectory = $"{chooseDrive.GetDrive}Revision/";

                Directory.CreateDirectory(externalDirectory);

                return true;
            }
            */

            return true;
        }

        readonly string externalDirectory;

        public override bool PullFile(string filePath)
        {
            try
            {
                File.Copy($"{externalDirectory}{filePath}", $"{Helper.LocalDirectory}{filePath}");
                return true;
            } catch { return false; }
            
        }

        public override bool PushFile(string filePath)
        {
            try
            {
                File.Copy($"{Helper.LocalDirectory}{filePath}", $"{externalDirectory}{filePath}");
                return true;
            } catch { return false; }
            
        }

        public override Queue<string> FilesToPush(IProgress<float> progress) =>
            FileSyncQueue(progress, Helper.LocalDirectory, externalDirectory);

        public override Queue<string> FilesToPull(IProgress<float> progress) =>
            FileSyncQueue(progress, externalDirectory, Helper.LocalDirectory);

        public Queue<string> FileSyncQueue(IProgress<float> progress, string from, string to)
        {
            var queue = new Queue<string>();

            var allFiles = AllFilesQueue(from);
            int amount = allFiles.Count;

            for (int i = 0; i < amount; i++)
            {
                var filePath = allFiles.Dequeue();
                string writePath = $"{to}{filePath}";
                if (!File.Exists(writePath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(writePath));
                    queue.Enqueue(filePath);
                }

                progress.Report((float)i / amount);
            }

            return queue;
        }
    }
}
