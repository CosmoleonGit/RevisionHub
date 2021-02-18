using RevisionProgram2.specialControls;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.themes
{
    public partial class ModifyTheme : Form
    {
        public ModifyTheme()
        {
            InitializeComponent();
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

        public void LoadInfo(Theme theme)
        {
            GetTheme = new Theme(theme.name, true)
            {
                cColours = theme.cColours
            };

            Font lblFont = new Font("Segoe UI", 12.0f);

            for (int i = 0; i < theme.ColourCount; i++)
            {
                string key = theme.ColourAt(i).Key;

                Label label = new Label
                {
                    Location = new Point(3, 10 + i * 30),
                    AutoSize = true,

                    Font = lblFont,
                    Text = key + ":"
                };

                ColourPanel.Controls.Add(label);
            }

            int buttonLeft = ColourPanel.PreferredSize.Width + 6;
            
            for (int i = 0; i < theme.ColourCount; i++)
            {
                //MessageBox.Show(theme.cColours.Keys.ElementAt(i));
                ColourButton button = new ColourButton
                {
                    Location = new Point(buttonLeft, 10 + i * 30),
                    Text = "",
                    Size = new Size(100, 23),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = theme.ColourAt(i).Value,
                    Tag = theme.ColourAt(i).Key
                };
                
                button.FlatAppearance.BorderSize = 1;
                button.FlatAppearance.BorderColor = Color.Black;
                button.FlatAppearance.CheckedBackColor = Color.Black;

                button.Click += (s, e) => {
                    //getTheme.cColours[((Button)sender).Tag.ToString()] = button.BackColor;
                    GetTheme.SetColour(((Button)s).Tag.ToString(), button.BackColor);
                };

                ColourPanel.Controls.Add(button);
            }

            ColourPanel.Width = ColourPanel.PreferredSize.Width + 22;
            CancelBtn.Left = ColourPanel.Right - CancelBtn.Width;
            OKBtn.Left = CancelBtn.Left - OKBtn.Width - 6;
            Width = PreferredSize.Width + 6;
        }

        public Theme GetTheme { get; private set; }

        private void ModifyTheme_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Revision_Program;
        }
    }
}
