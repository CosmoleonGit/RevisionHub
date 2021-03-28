using RevisionProgram2.folderSync;
using RevisionProgram2.onlineFeatures.netRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.netRoom
{
    public abstract class NetRoomPeer
    {
        public static NetRoomPeer CurrentRoom;

        public NetRoomPeer(string username)
        {
            room = new ChatRoom(username);
        }

        protected readonly ChatRoom room;

        public void Begin()
        {
            AddEvents(room);

            room.Show();
        }

        protected abstract void AddEvents(ChatRoom room);
    }
}
