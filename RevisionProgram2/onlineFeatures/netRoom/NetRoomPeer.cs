using RevisionProgram2.folderSync;
using RevisionProgram2.onlineFeatures.netRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionProgram2.netRoom
{
    public abstract class NetRoomPeer
    {
        public NetRoomPeer(List<ClientMember> members)
        {
            room = new ChatRoom(members);
        }

        readonly ChatRoom room;

        public void Begin()
        {
            AddEvents(room);

            room.Show();
        }

        protected abstract void AddEvents(ChatRoom room);
    }
}
