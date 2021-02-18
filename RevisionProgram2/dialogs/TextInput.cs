using RevisionProgram2.Themes;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RevisionProgram2.dialogs
{
    public partial class TextInput : Form
    {
        public TextInput()
        {
            InitializeComponent();
        }

        private Predicate<string> validate = x => true;

        private void TextInput_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
            ActiveControl = InputTxt;
            //InputTxt.Focus();
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

        private void InputTxt_TextChanged(object sender, EventArgs e)
        {
            OKBtn.Enabled = InputTxt.Text != "";

            if (InputTxt.Text == "")
            {
                OKBtn.Enabled = false;
                return;
            }

            OKBtn.Enabled = validate(InputTxt.Text);
        }

        public static void GetInput(string message, 
                                    string title,
                                    Action<string> onReceive,
                                    string current = "",
                                    Predicate<string> validate = null, 
                                    bool allowSpecialChars = false)
        {
            var inputForm = new TextInput();

            inputForm.StartPosition = FormStartPosition.CenterScreen;
            inputForm.MessageLbl.MaximumSize = new Size(inputForm.InputTxt.Width, 0);
            inputForm.MessageLbl.Text = message;
            inputForm.InputTxt.Top = inputForm.MessageLbl.Bottom + 5;
            inputForm.InputTxt.AllowSpecialCharacters = allowSpecialChars;
            inputForm.OKBtn.Top = inputForm.InputTxt.Bottom + 5;
            inputForm.CancelBtn.Top = inputForm.InputTxt.Bottom + 5;
            inputForm.Height = inputForm.PreferredSize.Height + 5;
            inputForm.Text = title;

            if (validate != null) { inputForm.validate = validate; }

            inputForm.InputTxt.Text = current;

            inputForm.FormClosing += (s, e) =>
            {
                if (inputForm.DialogResult == DialogResult.OK)
                {
                    onReceive(inputForm.InputTxt.Text);
                } else
                {
                    onReceive("");
                }
            };

            inputForm.Show();
        }

        public static string GetInputWait(string message, string title, string current = "", Predicate<string> validate = null, bool allowSpecialChars = false)
        {
            TextInput inputForm = new TextInput();

            inputForm.MessageLbl.MaximumSize = new Size(inputForm.InputTxt.Width, 0);
            inputForm.MessageLbl.Text = message;
            inputForm.InputTxt.Top = inputForm.MessageLbl.Bottom + 5;
            inputForm.InputTxt.AllowSpecialCharacters = allowSpecialChars;
            inputForm.OKBtn.Top = inputForm.InputTxt.Bottom + 5;
            inputForm.CancelBtn.Top = inputForm.InputTxt.Bottom + 5;
            inputForm.Height = inputForm.PreferredSize.Height + 5;
            inputForm.Text = title;

            if (validate != null) { inputForm.validate = validate; }

            inputForm.InputTxt.Text = current;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                return inputForm.InputTxt.Text;
            } else
            {
                return "";
            }
        }

        private static readonly char[] illegalChars = { (char)60, (char)61, ':', (char)34, '/', (char)92, '|', '?', '*' };
        public static Predicate<string> dirNameValid = s =>
        {
            if (Array.Exists(illegalChars, x => s.Contains(x))) return false;

            return true;
        };
    }
}
