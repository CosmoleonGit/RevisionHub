using RevisionProgram2.dialogs;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.alerts
{
    public partial class AlertForm : Form
    {
        #region Simulate Show Dialog

        const int GWL_STYLE = -16;
        const int WS_DISABLED = 0x08000000;

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public bool IsEnabled { get; private set; }

        internal void SetNativeEnabled(bool enabled)
        {
            IsEnabled = enabled;

            SetWindowLong(Handle, GWL_STYLE, GetWindowLong(Handle, GWL_STYLE) &
                ~WS_DISABLED | (enabled ? 0 : WS_DISABLED));
        }

        #endregion

        public bool Loaded { get; private set; }

        public AlertForm()
        {
            InitializeComponent();
            
        }

        private Alert SelectedAlert => Alert.alerts[AlertsList.SelectedIndex];

        private void ToggleEditing(bool editing)
        {
            Alert alert = SelectedAlert;
            alert.editing = editing;
            Alert.alerts[AlertsList.SelectedIndex] = alert;
        }

        private void AlertList_Load(object sender, EventArgs e)
        {
            Loaded = true;

            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
        }

        private static readonly Func<string, string, DateTime, bool> validFunc = 
            (string x, string y, DateTime dateTime) => TextInput.dirNameValid(x) && !Alert.alerts.Exists(item => item.title == x);

        private void AddBtn_Click(object sender, EventArgs e)
        {
            var modifyAlert = new ModifyAlert(validFunc);

            SetNativeEnabled(false);

            modifyAlert.FormClosing += (s, ev) =>
            {
                SetNativeEnabled(true);

                if (modifyAlert.DialogResult == DialogResult.OK)
                {
                    Alert.CreateAlert(modifyAlert.GetValue());
                }
            };

            modifyAlert.Show();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            string s = AlertsList.SelectedItem.ToString();

            ToggleEditing(true);

            var modifyAlert = new ModifyAlert(new Func<string, string, DateTime, bool>((string x, string y, DateTime dateTime) 
                => x == s || validFunc(x, y, dateTime)));

            Alert thisAlert = SelectedAlert;

            modifyAlert.SetValue(thisAlert.title, thisAlert.message, thisAlert.alertTime);

            SetNativeEnabled(false);

            modifyAlert.FormClosing += (se, ev) =>
            {
                SetNativeEnabled(true);

                if (modifyAlert.DialogResult == DialogResult.OK)
                {
                    Alert.EditToList(Alert.alerts.FindIndex(x => s == x.title), modifyAlert.GetValue());
                }

                ToggleEditing(false);
            };

            modifyAlert.Show();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            string s = AlertsList.SelectedItem.ToString();

            ToggleEditing(true);

            if (MsgBox.ShowWait("Are you sure you want to delete this reminder?",
                            "Delete",
                            MsgBox.Options.yesNo,
                            MsgBox.MsgIcon.EXCL) == "Yes")
            {
                Alert.RemoveFromList(Alert.alerts.FindIndex(x => s == x.title));
            } else
            {
                ToggleEditing(false);
            }
        }

        private void AlertsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditBtn.Enabled = AlertsList.SelectedIndex != -1;
            DeleteBtn.Enabled = EditBtn.Enabled;
        }

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
