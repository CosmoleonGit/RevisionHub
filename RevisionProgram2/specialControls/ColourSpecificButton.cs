using RevisionProgram2.themes;
using RevisionProgram2.Themes;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RevisionProgram2.specialControls
{
    public class ColourSpecificButton : Button, IColourSpecific
    {
        [Description("Backcolour name for label"), Category("Data")]
        public string BackColourName { get; set; }

        [Description("Forecolour name for label"), Category("Data")]
        public string ForeColourName { get; set; }

        [Description("Backcolour for label if it isn't in a theme."), Category("Data")]
        public Color GlobalBackColour { get; set; }

        public void UpdateTheme(Theme theme)
        {
            if (!string.IsNullOrEmpty(BackColourName)) BackColor = theme.GetColour(BackColourName);
            if (!string.IsNullOrEmpty(ForeColourName)) ForeColor = theme.GetColour(ForeColourName);
        }
    }
}
