using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.specialControls
{
    class SpecialTextBox : TextBox
    {
        public SpecialTextBox()
        {
            KeyDown += SpecialTextBox_KeyDown;
        }

        [Description("Whether the text box allows special character input."), Category("Data")]
        public bool AllowSpecialCharacters { get; set; } = true;

        private void SpecialTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (AllowSpecialCharacters && e.Alt)
            {
                e.Handled = e.SuppressKeyPress = true;

                string insertText = "";

                switch (e.KeyCode)
                {
                    case Keys.A:
                        if (e.Shift)
                        {
                            insertText = "Á";
                        }
                        else
                        {
                            insertText = "á";
                        }
                        break;
                    case Keys.E:
                        if (e.Shift)
                        {
                            insertText = "É";
                        }
                        else
                        {
                            insertText = "é";
                        }
                        break;
                    case Keys.I:
                        if (e.Shift)
                        {
                            insertText = "Í";
                        }
                        else
                        {
                            insertText = "í";
                        }
                        break;
                    case Keys.O:
                        if (e.Shift)
                        {
                            insertText = "Ó";
                        }
                        else
                        {
                            insertText = "ó";
                        }
                        break;
                    case Keys.U:
                        if (e.Shift)
                        {
                            insertText = "Ú";
                        }
                        else
                        {
                            insertText = "ú";
                        }
                        break;
                    case Keys.N:
                        if (e.Shift)
                        {
                            insertText = "Ñ";
                        }
                        else
                        {
                            insertText = "ñ";
                        }
                        break;
                    case Keys.OemQuestion:
                        if (e.Shift)
                        {
                            insertText = "¿";
                        }
                        break;
                }

                if (insertText != "")
                {
                    int selectionIndex = SelectionStart;
                    Text = Text.Insert(selectionIndex, insertText);
                    SelectionStart = selectionIndex + 1;
                }
            }
        }
    }
}
