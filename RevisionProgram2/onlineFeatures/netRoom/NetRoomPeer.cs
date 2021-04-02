using RevisionProgram2.dialogs;
using RevisionProgram2.folderSync;
using RevisionProgram2.onlineFeatures.netRoom;
using RevisionProgram2.revision.assessments.tests;
using RevisionProgram2.revision.tests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.onlineFeatures.netRoom
{
    public abstract class NetRoomPeer
    {
        public static bool IsUsernameValid(string name)
        {
            return name.Length >= 3 && name.Length <= 20;
        }

        public static NetRoomPeer CurrentRoom;

        public NetRoomPeer(string _username)
        {
            username = _username;
            room = new ChatRoom(username);
        }

        protected readonly string username;
        protected readonly ChatRoom room;

        protected bool Closed { get; private set; }

        static readonly string defaultPath = $"{Helper.directory}temp/";
        string challengePath = null;

        protected string ChallengePath => challengePath ?? defaultPath;

        protected string ChallengeName { get; set; }

        public void Begin()
        {
            room.FormClosing += Room_FormClosing;

            AddEvents(room);

            room.Show();
        }

        protected void ResetChallenge() => challengePath = null;

        private void Room_FormClosing(object sender, FormClosingEventArgs e)
        {
            Closed = true;
        }

        protected abstract void AddEvents(ChatRoom room);

        public virtual void Challenge(string path)
        {
            challengePath = path;
        }

        protected void BeginTest()
        {
            new Test($"{ChallengePath}{ChallengeName}").LoadAndStart(OnTestFinish, OnResults, true);
            //new Test($"{ChallengePath}{ChallengeName}").Start(null);
        }

        protected abstract void OnResults(TestResults obj);

        protected virtual void OnTestFinish() { }
    }
}
