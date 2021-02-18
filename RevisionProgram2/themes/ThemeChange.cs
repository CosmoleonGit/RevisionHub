using RevisionProgram2.dialogs;
using RevisionProgram2.themes;
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

namespace RevisionProgram2.Themes
{
    public partial class ThemeChange : Form
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

        public ThemeChange()
        {
            InitializeComponent();
        }

        private void ThemeChange_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;

            RefreshList();
        }

        private void RefreshList()
        {
            ThemesList.Items.Clear();

            Theme.themes.ForEach(x => ThemesList.Items.Add(x.name));
        }

        private void SwitchBtn_Click(object sender, EventArgs e)
        {
            Theme.ChangeGlobalTheme((ushort)ThemesList.SelectedIndex);
            Close();
        }

        private void ThemesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DuplicateBtn.Enabled = ThemesList.SelectedIndex > -1;
            EditBtn.Enabled = DuplicateBtn.Enabled && Theme.themes[ThemesList.SelectedIndex].CanModify;
            DeleteBtn.Enabled = EditBtn.Enabled;
            RenameBtn.Enabled = EditBtn.Enabled;
            SwitchBtn.Enabled = DuplicateBtn.Enabled && ThemesList.SelectedIndex != Theme.ThemeID;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            CreateTheme();
        }

        private void CreateTheme(Dictionary<string, Color> currentColours = null)
        {
            SetNativeEnabled(false);

            // Asks for the name of the theme.
            TextInput.GetInput("Enter a name for your theme",
                "New Theme",
                themeName =>
                {
                    SetNativeEnabled(true);

                    // Checks if it isn't empty
                    if (themeName == "") return;

                    Theme oldTheme = new Theme(themeName);

                    if (currentColours != null)
                    {
                        var newColours = new Dictionary<string, Color>();

                        foreach (KeyValuePair<string, Color> keyValue in currentColours)
                        {
                            newColours.Add(keyValue.Key, keyValue.Value);
                        }

                        oldTheme.cColours = newColours;
                    }


                    ChangeTheme(oldTheme, newTheme =>
                    {
                        if (newTheme != null)
                        {
                            Theme.CreateTheme(newTheme);
                            ThemesList.Items.Add(newTheme.name);
                        }
                    });

                    
                },
                "",
                s =>
                {
                    // Allows if the name is valid and doesn't already exist.
                    return TextInput.dirNameValid(s) && !Theme.themes.Exists(x => s == x.name);
                });
        }

        private void ChangeTheme(Theme theme, Action<Theme> onReturn)
        {
            ModifyTheme themeForm = new ModifyTheme();

            themeForm.LoadInfo(theme);

            SetNativeEnabled(false);

            themeForm.FormClosing += (s, e) =>
            {
                SetNativeEnabled(true);

                if (themeForm.DialogResult == DialogResult.OK)
                {
                    onReturn(themeForm.GetTheme);
                }
                else
                {
                    onReturn(null);
                }
            };

            themeForm.Show();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            // Modify theme
            ChangeTheme(Theme.themes[ThemesList.SelectedIndex], theme =>
            {
                if (theme != null) Theme.ReplaceTheme((ushort)ThemesList.SelectedIndex, theme);
            });
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            // Prompts the user for confirmation to delete
            if (MsgBox.ShowWait("Are you sure you want to delete this theme?",
                "Delete",
                MsgBox.Options.yesNo,
                MsgBox.MsgIcon.EXCL) == "Yes")
            {
                // Deletes the theme
                Theme.DeleteTheme((ushort)ThemesList.SelectedIndex);
                ThemesList.Items.RemoveAt(ThemesList.SelectedIndex);
            }
        }

        private void DuplicateBtn_Click(object sender, EventArgs e)
        {
            // Creates a new theme identical to the selected theme.
            CreateTheme(Theme.themes[ThemesList.SelectedIndex].cColours);
        }

        private void RenameBtn_Click(object sender, EventArgs e)
        {
            // Prompts the user for a new name.
            string themeName = TextInput.GetInputWait(
                "Enter a name for your theme.",
                "New Theme",
                ThemesList.SelectedItem.ToString(),
                TextInput.dirNameValid);

            // Check if the new name isn't empty and is not the previous one.
            if (themeName == "" || themeName == ThemesList.SelectedItem.ToString()) return;

            try
            {
                Theme.RenameTheme((ushort)ThemesList.SelectedIndex, themeName);
                ThemesList.Items[ThemesList.SelectedIndex] = themeName;
            } catch (Exception ex)
            {
                Helper.Error("Error renaming file.", $"Reason: {ex.Message}");
            }
        }
    }
}
