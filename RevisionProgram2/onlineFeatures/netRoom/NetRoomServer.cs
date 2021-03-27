using RevisionProgram2.onlineFeatures.netRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.netRoom
{
    public class NetRoomServer : NetRoomPeer
    {
        public NetRoomServer(List<ClientMember> members) : base(members) { }

        protected override void AddEvents(ChatRoom room)
        {
            
        }
    }
}
