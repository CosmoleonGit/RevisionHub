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

namespace RevisionProgram2.alerts
{
    public partial class ModifyAlert : Form
    {
        readonly Func<string, string, DateTime, bool> validate = (string x, string y, DateTime z) => true;

        public ModifyAlert(Func<string, string, DateTime, bool> _validate = null)
        {
            InitializeComponent();

            if (_validate != null)
            {
                validate = _validate;
            }
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

        private void ModifyAlert_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;

            DatePicker.Format = DateTimePickerFormat.Custom;
            DatePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            CanOK();
        }

        private void CanOK()
        {
            OKBtn.Enabled = (TitleTxt.Text != "" && 
                             MessageTxt.Text != "" && 
                             validate(TitleTxt.Text, MessageTxt.Text, DatePicker.Value));
        }

        private void TitleTxt_TextChanged(object sender, EventArgs e)
        {
            CanOK();
        }

        private void MessageTxt_TextChanged(object sender, EventArgs e)
        {
            CanOK();
        }

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            CanOK();
        }

        public Alert GetValue() => new Alert(TitleTxt.Text, MessageTxt.Text, DatePicker.Value);

        public void SetValue(string title, string message, DateTime dateTime)
        {
            TitleTxt.Text = title;
            MessageTxt.Text = message;
            DatePicker.Value = dateTime;
        }
    }
}
