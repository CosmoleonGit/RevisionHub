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
    public class ColourSpecificLabel : Label, IColourSpecific
    {
        [Description("Backcolour name for label"), Category("Data")]
        public string BackColourName { get; set; }

        [Description("Forecolour name for label"), Category("Data")]
        public string ForeColourName { get; set; }

        public void UpdateTheme(Theme theme)
        {
            //if (GlobalBackColour != null) BackColor = GlobalBackColour;
            if (!string.IsNullOrEmpty(BackColourName)) BackColor = theme.GetColour(BackColourName);
            
            if (!string.IsNullOrEmpty(ForeColourName)) ForeColor = theme.GetColour(ForeColourName);
        }
    }
}
