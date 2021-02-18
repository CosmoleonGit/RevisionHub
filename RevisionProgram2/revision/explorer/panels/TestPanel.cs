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

        public TestPanel(Panel owner, string name, string path) : base(owner, name, path) { }

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

            Test.Duplicate(PanelName, Dir, (n, d) =>
            {
                GetForm.StopEditing(Dir);
                if (n != "" && d == Dir) GetForm.AddPanel(new TestPanel(owner, n, Dir), true);
            });
        }
    }
}
