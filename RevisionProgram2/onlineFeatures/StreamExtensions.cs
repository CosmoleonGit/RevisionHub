using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.onlineFeatures
{
    public static class StreamExtensions
    {
        public static bool WaitForResponse(this Stream stream)
        {
            stream.ReadByte();
            return true;
        }

        public static int ReadByte(this Stream stream)
        {
            int b;
            while ((b = stream.ReadByte()) == -1) { }
            return b;
        }

        public static int ReadBytes(this Stream stream, byte[] buffer, int offset, int size)
        {
            int i;
            while ((i = stream.Read(buffer, offset, size)) == 0) { }
            return i;
        }

        public static string ReadString(this Stream stream, int size)
        {
            byte[] buffer = new byte[size];
            int i;
            
            while ((i = stream.Read(buffer, 0, buffer.Length)) == 0) { }

            return Encoding.ASCII.GetString(buffer, 0, i);
        }

        public static void SendString(this Stream stream, string s)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
