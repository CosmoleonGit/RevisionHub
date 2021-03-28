using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.onlineFeatures.netRoom
{
    public class ClientMember
    {
        public ClientMember(string _name, NetworkStream _stream)
        {
            name = _name;
            stream = _stream;
        }

        public readonly string name;
        public readonly NetworkStream stream;
    }
}
