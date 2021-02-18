using RevisionProgram2.revision.flashcards;
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
    public partial class FlashcardsPanel : FilePanel
    {
        public FlashcardsPanel(Panel owner, string name, string path) : base(owner, name, path) { }

        protected override Image GetIcon()
        {
            return Properties.Resources.Flashcards;
        }

        public override void StartAssessment(Action onFinish)
        {
            GetForm.BeginEditing($"{Dir}{PanelName}");
            new Flashcards(PanelName, Dir).Start(() =>
            {
                GetForm.StopEditing($"{Dir}{PanelName}");
                onFinish?.Invoke();
            });
        }

        public override void Edit()
        {
            GetForm.BeginEditing($"{Dir}{PanelName}");

            Flashcards.Edit(PanelName, Dir, (n, d) =>
            {
                GetForm.StopEditing($"{Dir}{PanelName}");
            });
        }
    }
}
