using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.folderSync
{
    public abstract class FolderSyncInterface
    {
        public abstract bool Setup();
        public virtual void Finish() { }
        public virtual bool PushFirst => true;
        public abstract Queue<string> FilesToPush(IProgress<float> progress);
        public abstract Queue<string> FilesToPull(IProgress<float> progress);
        public abstract void PushFile(string to);
        public abstract void PullFile(string from);

        public Queue<string> AllFilesQueue(string from)
        {
            var queue = new Queue<string>();

            var di = new DirectoryInfo(from);

            foreach (var file in di.GetFiles("*", SearchOption.AllDirectories))
            {
                string filePath = file.FullName.Remove(0, from.Length);

                queue.Enqueue(filePath);
            }

            return queue;
        }
    }
}
