using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.dialogs
{
    public partial class MultilineInput : Form
    {
        public MultilineInput()
        {
            InitializeComponent();
        }

        private Predicate<string> validate = x => true;

        public static void GetInput(string message, 
                                    string title,
                                    Action<string> onReturn,
                                    string current = "", 
                                    Predicate<string> validFunc = null)
        {
            var inputDialog = new MultilineInput();

            inputDialog.StartPosition = FormStartPosition.CenterScreen;

            inputDialog.MessageLbl.Text = message;
            inputDialog.Text = title;

            inputDialog.InputTxt.Text = current;

            if (validFunc != null)
                inputDialog.validate = validFunc;

            inputDialog.InputTxt.Enabled = inputDialog.validate(current);

            inputDialog.FormClosing += (s, e) =>
            {
                if (inputDialog.DialogResult == DialogResult.OK)
                {
                    onReturn(inputDialog.InputTxt.Text);
                } else
                {
                    onReturn("");
                }
            };

            inputDialog.Show();
        }

        public static string GetInputWait(string message, 
                                          string title, 
                                          string current = "", 
                                          Predicate<string> validFunc = null)
        {
            var inputDialog = new MultilineInput();

            inputDialog.MessageLbl.Text = message;
            inputDialog.Text = title;

            inputDialog.InputTxt.Text = current;

            if (validFunc != null)
                inputDialog.validate = validFunc;

            inputDialog.InputTxt.Enabled = inputDialog.validate(current);

            return (inputDialog.ShowDialog() == DialogResult.OK) ?
                   inputDialog.InputTxt.Text : "";
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void MultilineInput_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
            ActiveControl = InputTxt;
        }

        private void InputTxt_TextChanged(object sender, EventArgs e)
        {
            InputTxt.Enabled = validate(InputTxt.Text);
        }
    }
}
