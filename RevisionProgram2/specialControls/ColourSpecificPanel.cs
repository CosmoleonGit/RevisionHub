using RevisionProgram2.themes;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.specialControls
{
    class ColourSpecificPanel : Panel, IColourSpecific
    {
        [Description("Backcolour name for panel"), Category("Data")]
        public string BackColourName { get; set; }

        [Description("Backcolour for panel if it isn't in a theme."), Category("Data")]
        public Color GlobalBackColour { get; set; }

        public void UpdateTheme(Theme theme)
        {
            if (!string.IsNullOrEmpty(BackColourName)) BackColor = theme.GetColour(BackColourName);
            else BackColor = GlobalBackColour;
        }
    }
}
