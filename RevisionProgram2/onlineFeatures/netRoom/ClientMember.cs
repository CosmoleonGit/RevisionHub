using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.onlineFeatures.netRoom
{
    public enum ChallengeState
    {
        DECIDING,
        ACCEPTED,
        PENDING_DATA,
        READING_DATA
    }

    public class ClientMember
    {
        public ClientMember(string _name, NetworkStream _stream)
        {
            name = _name;
            stream = _stream;
        }

        public readonly string name;
        public readonly NetworkStream stream;

        public bool Finished { get; private set; }

        public void SendBlankMsg(ServerMessageType type)
        {
            stream.Write(new[] { (byte)type }, 0, 1);
        }

        public void SendBytes(ServerMessageType type, byte[] msg)
        {
            byte[] buffer = new byte[msg.Length + 1];
            buffer[0] = (byte)type;
            msg.CopyTo(buffer, 1);

            try
            {
                stream.Write(buffer, 0, buffer.Length);
            } catch (IOException)
            {
                Finished = true;
            }
        }

        public void SendString(ServerMessageType type, string msg)
        {
            SendBytes(type, Encoding.ASCII.GetBytes(msg));
        }

        public int Read(byte[] buffer, int offset, int size)
        {
            try
            {
                return stream.Read(buffer, offset, size);
            } catch
            {
                Finished = true;
                return 0;
            }
        }

        public void Stop() => Finished = true;

        public ChallengeState ChallengeState { get; set; }
    }
}
