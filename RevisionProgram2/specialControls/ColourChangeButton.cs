using RevisionProgram2.themes;
using RevisionProgram2.Themes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RevisionProgram2.specialControls
{
    public class ColourButton : Button
    {
        public ColourButton()
        {
            Click += Clicked;
            //FlatStyle = FlatStyle.Flat;
            //FlatAppearance.BorderSize = 0;
        }

        private void Clicked(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog
            {
                Color = BackColor,
                FullOpen = true
            };

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BackColor = colorDialog.Color;
            }
        }
    }

    
}
