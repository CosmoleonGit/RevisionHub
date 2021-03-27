using RevisionProgram2.onlineFeatures.netRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.netRoom
{
    public class NetRoomClient : NetRoomPeer
    {
        public NetRoomClient(List<ClientMember> members) : base(members) { }

        protected override void AddEvents(ChatRoom room)
        {

        }
    }
}
