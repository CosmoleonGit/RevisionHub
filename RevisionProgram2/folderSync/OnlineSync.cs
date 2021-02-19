﻿using System;
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

        public override void Finish()
        {
            socket.Close();
            stream.Close();
        }

        protected bool WaitForResponse()
        {
            ReadByte();
            return true;
        }

        protected int ReadByte()
        {
            int b;
            while ((b = stream.ReadByte()) == -1) { }
            return b;
        }

        protected int ReadBytes(byte[] buffer, int offset, int size)
        {
            int i;
            while ((i = stream.Read(buffer, offset, size)) == 0) { }
            return i;
        }

        protected string ReadString()
        {
            byte[] buffer = new byte[socket.ReceiveBufferSize];
            int i;

            while ((i = stream.Read(buffer, 0, buffer.Length)) == 0) { }

            return Encoding.ASCII.GetString(buffer, 0, i);
        }

        protected void SendString(string s)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            stream.Write(bytes, 0, bytes.Length);
        }

        protected virtual string WriteDirectory => Helper.LocalDirectory;

        public override Queue<string> FilesToPush(IProgress<float> progress)
        {
            var queue = new Queue<string>();

            var allFiles = AllFilesQueue(WriteDirectory);
            ushort amount = (ushort)allFiles.Count;

            stream.Write(BitConverter.GetBytes(amount), 0, 2);
            
            for (int i = 0; i < amount; i++)
            {
                var filePath = allFiles.Dequeue();

                SendString(filePath);
                
                if (ReadByte() == 1)
                {
                    queue.Enqueue(filePath);
                }

                progress.Report((float)i / amount);
            }

            SendString("E");

            return queue;
        }

        public override Queue<string> FilesToPull(IProgress<float> progress)
        {
            var queue = new Queue<string>();

            ushort amount;
            byte[] buffer = new byte[2];

            ReadBytes(buffer, 0, 2);
            amount = BitConverter.ToUInt16(buffer, 0);
            
            int i = 0;

            string receive;
            while ((receive = ReadString()).Length > 1)
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
        }

        const int bufferSize = 1024;

        public override void PushFile(string from)
        {
            byte[] buffer = new byte[bufferSize];

            using (var source = File.OpenRead($"{WriteDirectory}{from}"))
            {
                int i;
                while ((i = source.Read(buffer, 0, bufferSize)) > 0)
                {
                    stream.WriteByte(0);
                    WaitForResponse();

                    stream.Write(BitConverter.GetBytes((ushort)i), 0, 2);
                    WaitForResponse();

                    stream.Write(buffer, 0, i);
                    WaitForResponse();
                }

                stream.WriteByte(1);
            }
        }

        public override void PullFile(string to)
        {
            byte[] buffer;

            using (var source = File.OpenWrite($"{WriteDirectory}{to}"))
            {
                while (true)
                {
                    if (ReadByte() == 1) break;
                    stream.WriteByte(0);

                    byte[] buffer2 = new byte[2];
                    ReadBytes(buffer2, 0, 2);
                    int length = BitConverter.ToUInt16(buffer2, 0);

                    stream.WriteByte(0);

                    buffer = new byte[length];
                    ReadBytes(buffer, 0, length);
                    source.Write(buffer, 0, length);

                    stream.WriteByte(0);
                }
            }
        }
    }
}