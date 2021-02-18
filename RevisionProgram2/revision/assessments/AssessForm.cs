using RevisionProgram2.dialogs;
using RevisionProgram2.Properties;
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

namespace RevisionProgram2.revision.assessments
{
    public partial class AssessForm : Form
    {
        readonly Assess assess;
        public AssessForm(Assess _assess)
        {
            InitializeComponent();
            
            assess = _assess;

            Text = $"{assess.name} - Assessment";

            DescLbl.Text = assess.description != "" ? 
                           assess.description : "(No description has been entered.)";
        }

        public Action onFinish;

        private void BeginBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        bool settingsShown = false;
        bool settingsCreated = false;

        private void OptionsBtn_Click(object sender, EventArgs e)
        {
            settingsShown ^= true;

            OptionsBtn.Text = "Options " + (settingsShown ? "<<<" : ">>>");

            SettingsGroup.Visible = settingsShown;

            if (!settingsCreated)
            {
                settingsCreated = true;
                assess.CreateSettingsPanel(SettingsPanel);
                SettingsGroup.Width = SettingsGroup.PreferredSize.Width;
                Theme.ChangeControl(SettingsPanel);
            }
            
            Width = PreferredSize.Width + 9;
        }

        private void AssessForm_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Resources.Revision_Program;
        }

        private void AssessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            onFinish?.Invoke();
        }
    }
}
