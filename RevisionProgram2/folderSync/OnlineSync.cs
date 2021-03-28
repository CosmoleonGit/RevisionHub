using RevisionProgram2.dialogs;
using RevisionProgram2.onlineFeatures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.folderSync
{
    public abstract class OnlineSync : FolderSyncInterface
    {
        protected Socket socket;
        protected NetworkStream stream;

        protected bool ConnectionFailure() => MsgBox.ShowWait($"Could not connect to recipient." +
                                                              $"{Helper.twoLines}" +
                                                              $"Would you like to try again?",
                                                              "Connection timeout.",
                                                              MsgBox.Options.yesNo,
                                                              MsgBox.MsgIcon.ERROR) == "Yes";

        protected const int timeout = 10000;

        public override void Finish()
        {
            socket?.Close();
            stream?.Close();
        }

        protected virtual string WriteDirectory => Helper.LocalDirectory;

        void SyncError(string reason)
        {
            Helper.Error("An error occured during online sync.", reason);
        }

        public override Queue<string> FilesToPush(IProgress<float> progress)
        {
            var queue = new Queue<string>();

            var allFiles = AllFilesQueue(WriteDirectory);
            ushort amount = (ushort)allFiles.Count;

            stream.Write(BitConverter.GetBytes(amount), 0, 2);

            try
            {
                for (int i = 0; i < amount; i++)
                {
                    var filePath = allFiles.Dequeue();

                    stream.SendString(filePath);

                    if (stream.ReadByte() == 1)
                    {
                        queue.Enqueue(filePath);
                    }

                    progress.Report((float)i / amount);
                }

                stream.SendString("E");

                return queue;
            } catch (IOException ex)
            {
                SyncError(ex.Message);
                return null;
            }
        }

        public override Queue<string> FilesToPull(IProgress<float> progress)
        {
            var queue = new Queue<string>();

            ushort amount;
            byte[] buffer = new byte[2];

            try
            {
                stream.WaitForBytes(buffer, 0, 2);
                amount = BitConverter.ToUInt16(buffer, 0);

                int i = 0;

                string receive;
                while ((receive = stream.WaitForString(socket.ReceiveBufferSize)).Length > 1)
                {
                    string writePath = $"{WriteDirectory}{receive}";
                    if (!File.Exists(writePath))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(writePath));
                        queue.Enqueue(receive);

                        stream.WriteByte(1);
                    }
                    else
                    {
                        stream.WriteByte(0);
                    }

                    i++;
                    progress.Report((float)i / amount);
                }

                return queue;
            } catch (IOException ex)
            {
                SyncError(ex.Message);
                return null;
            }
        }

        protected const int bufferSize = 8192;

        public override bool PushFile(string from)
        {
            byte[] buffer = new byte[bufferSize];

            using (var source = File.OpenRead($"{WriteDirectory}{from}"))
            {
                int i;
                
                try
                {
                    while ((i = source.Read(buffer, 0, bufferSize)) > 0)
                    {
                        stream.WriteByte(0);
                        stream.WaitForResponse();

                        stream.Write(BitConverter.GetBytes((ushort)i), 0, 2);
                        stream.WaitForResponse();

                        stream.Write(buffer, 0, i);
                        stream.WaitForResponse();
                    }

                    stream.WriteByte(1);
                } catch (IOException ex)
                {
                    SyncError(ex.Message);
                    return false;
                }
                
            }

            return true;
        }

        public override bool PullFile(string to)
        {
            byte[] buffer;

            string writeDir = $"{WriteDirectory}{to}";
            try
            {
                using (var source = File.OpenWrite(writeDir))
                {
                    while (true)
                    {
                        if (stream.ReadByte() == 1) break;
                        stream.WriteByte(0);

                        byte[] buffer2 = new byte[2];
                        stream.WaitForBytes(buffer2, 0, 2);
                        int length = BitConverter.ToUInt16(buffer2, 0);

                        stream.WriteByte(0);

                        buffer = new byte[length];
                        stream.WaitForBytes(buffer, 0, length);
                        source.Write(buffer, 0, length);

                        stream.WriteByte(0);
                    }
                }
            } catch (IOException ex)
            {
                File.Delete(writeDir);
                SyncError(ex.Message);
                return false;
            }

            return true;
        }
    }
}
