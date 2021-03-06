﻿using RevisionProgram2.dialogs;
using RevisionProgram2.onlineFeatures.netRoom;
using RevisionProgram2.revision.assessments.tests;
using RevisionProgram2.revision.tests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.revision.explorer.panels
{
    public partial class TestPanel : FilePanel
    {

        public TestPanel(Panel owner, string name, string path) : base(owner, name, path)
        {
            if (NetRoomPeer.CurrentRoom != null &&
                NetRoomPeer.CurrentRoom is NetRoomServer)
            {
                GetContext.Items.Add(new ToolStripSeparator());

                var challengeStrip = new ToolStripMenuItem()
                {
                    Text = "Challenge"
                };

                challengeStrip.Click += ChallengeStrip_Click;

                GetContext.Items.Add(challengeStrip);
            }
        }

        protected override Image GetIcon()
        {
            return Properties.Resources.Test;
        }

        public override void StartAssessment(Action onFinish)
        {
            GetForm.BeginEditing($"{Dir}{PanelName}");
            new Test(PanelName, Dir).Start(() =>
            {
                GetForm.StopEditing($"{Dir}{PanelName}");
                onFinish?.Invoke();
            });
        }

        public override void Edit()
        {
            GetForm.BeginEditing($"{Dir}{PanelName}");

            Test.Edit(PanelName, Dir, (n, d) =>
            {
                GetForm.StopEditing($"{Dir}{PanelName}");
            });
        }

        public override void Duplicate()
        {
            GetForm.BeginEditing(Dir);
            GetForm.SetNativeEnabled(false);

            Test.Duplicate(PanelName, Dir,
                () => GetForm.SetNativeEnabled(true),
                (n, d) =>
                {
                    GetForm.StopEditing(Dir);
                    if (n != "" && d == Dir) GetForm.AddPanel(new TestPanel(owner, n, Dir), true);
                });
        }

        private void ChallengeStrip_Click(object sender, EventArgs e)
        {
            if (NetRoomPeer.CurrentRoom != null)
            {
                NetRoomPeer.CurrentRoom.Challenge($"{Dir}{PanelName}");
            }
            else
            {
                MsgBox.ShowWait("A friend room is not currently open.",
                                "Challenge",
                                null,
                                MsgBox.MsgIcon.ERROR);
            }
        }
    }
}
