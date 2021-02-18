using RevisionProgram2.Properties;
using RevisionProgram2.themes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RevisionProgram2.Themes
{

    public class Theme
    {
        public static List<Theme> themes;

        public static Theme GetTheme {get { return themes[ThemeID]; }}

        public static ushort ThemeID { get; private set; } = 0;

        public static void LoadThemes()
        {
            themes = new List<Theme>
            {
                // Load default themes
                new Theme("Default Light", false),                                                                  // Default Light
                GetThemeFromStrings("Default Dark", Helper.SplitIntoLines(Resources.Default_Dark), false)     // Default Dark
            };

            // Add themes from directory

            // Get theme directory info or create it if it doesn't exist
            DirectoryInfo di = Directory.CreateDirectory(Helper.directory + "Themes");
            
            // Add all the themes from the directory
            foreach (FileInfo foundFile in di.GetFiles("*", SearchOption.AllDirectories)){
                Theme theme = GetThemeFromStrings(foundFile.Name, File.ReadAllLines(Helper.directory + "Themes/" + foundFile.Name));
                themes.Add(theme);
            }

            ThemeID = (ushort)Math.Max(0, themes.FindIndex(x => x.name == Settings.Default.curTheme));
            ChangeGlobalTheme(ThemeID);
        }

        public static Theme GetThemeFromStrings(string name, string[] lines, bool modifiable = true)    // Converts an array of strings into a theme.
        {
            Theme theme = new Theme(name, modifiable);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                if (parts.Length != 2) continue;

                if (!theme.cColours.ContainsKey(parts[0])) continue;

                Color c;
                
                try
                {
                    c = Color.FromArgb(int.Parse(parts[1]));
                } catch
                {
                    continue;
                }

                theme.cColours[parts[0]] = c;
            }

            return theme;
        }

        public static void ChangeGlobalTheme(ushort id)     // Change theme
        {
            ThemeID = id;
            Settings.Default.curTheme = themes[id].name;
            Settings.Default.Save();

            foreach (Form f in Application.OpenForms)
            {
                ChangeFormTheme(f);
            }
        }
        
        public static void ChangeFormTheme(Form f)      // Change form to theme
        {
            ChangeControl(f);
        }

        public static void ChangeControl(Control c)       // Change control to theme
        {
            Theme newTheme = GetTheme;

            if (!(c is RichTextBox)) c.ForeColor = newTheme.cColours["TextColour"];

            if (c is Form || c is GroupBox || c is Panel || c is TabPage || c is ProgressBar)
            {
                c.BackColor = GetTheme.cColours["FormColour"];
            }

            else if (c is Button)
            {
                c.BackColor = newTheme.cColours["ButtonColour"];
            }

            else if (c is TextBox)
            {
                c.BackColor = newTheme.cColours["TextBoxColour"];
                c.ForeColor = newTheme.cColours["TypedTextColour"];
            }
            
            else if (c is ListBox || c is ComboBox)
            {
                c.BackColor = newTheme.cColours["ListBoxColour"];
            }

            else if (c is LinkLabel ll)
            {
                //LinkLabel link = (LinkLabel)c;
                ll.LinkColor = newTheme.cColours["LinkColour"];
                ll.ActiveLinkColor = newTheme.cColours["LinkClickColour"];
            }

            else if (c is TabControl tc)
            {
                tc.BackColor = newTheme.cColours["FormColour"];
                foreach (TabPage page in tc.TabPages) { ChangeControl(page); }
            }

            if (c is IColourSpecific ics) ics.UpdateTheme(newTheme);

            foreach (Control child in c.Controls)
            {
                ChangeControl(child);
            }
        }

        public static void CreateTheme(Theme theme)     // Create new theme
        {
            List<string> data = new List<string>();

            foreach (KeyValuePair<string, Color> item in theme.cColours)
            {
                data.Add(item.Key + ":" + item.Value.ToArgb().ToString());
            }

            File.WriteAllLines(Helper.directory + "Themes/" + theme.name, data.ToArray());

            themes.Add(theme);
        }

        public static void ReplaceTheme(ushort id, Theme theme)     // Replace existing theme
        {
            if (!theme.CanModify)
            {
                throw new InvalidOperationException("Cannot overwrite a default theme.");
            }

            List<string> data = new List<string>();

            foreach (KeyValuePair<string, Color> item in theme.cColours)
            {
                data.Add(item.Key + ":" + item.Value.ToArgb().ToString());
            }

            File.WriteAllLines(Helper.directory + "Themes/" + theme.name, data.ToArray());

            themes[id] = theme;

            if (id == ThemeID)
            {
                ChangeGlobalTheme(ThemeID);
            }
        }

        public static void DeleteTheme(ushort id)       // Delete existing theme
        {
            if (!themes[id].CanModify)
            {
                throw new InvalidOperationException("Cannot delete a default theme.");
            }

            if (ThemeID == id)
            {
                ChangeGlobalTheme(0);
            } else if (ThemeID > id)
            {
                ThemeID--;
                //id--;
            }

            File.Delete(Helper.directory + "Themes/" + themes[id].name);
            themes.RemoveAt(id);
        }

        public static void RenameTheme(ushort id, string newName)       // Rename existing theme
        {
            File.Move(Helper.directory + "Themes/" + themes[id].name,
                      Helper.directory + "Themes/" + newName);

            themes[id].name = newName;

            if (ThemeID == id)
            {
                Settings.Default.curTheme = newName;
                Settings.Default.Save();
            }
        }

        public string name;

        public Dictionary<string, Color> cColours;

        public Color GetColour(string colourName) => cColours[colourName];
        public void SetColour(string colourName, Color newColour) => cColours[colourName] = newColour;
        public int ColourCount => cColours.Count;
        public KeyValuePair<string, Color> ColourAt(int id) => cColours.ElementAt(id);

        public bool CanModify { get; }

        public Theme(string name, bool modifiable = true)
        {
            this.name = name;

            cColours = new Dictionary<string, Color>
            {
                { "FormColour", SystemColors.Control },
                { "TextColour", SystemColors.ControlText },
                { "TypedTextColour", SystemColors.ControlText },
                { "ButtonColour", Color.LightGray },
                { "TextBoxColour", SystemColors.Window },
                { "ListBoxColour", SystemColors.Control },
                { "LinkColour", Color.Blue },
                { "LinkClickColour", Color.Red },
                { "RevisionItem", Color.White },
                { "ChangeButtonBack", Color.LightGray },
                { "ChangeButtonFore", Color.Black },
                { "CardLeftBack", Color.FromArgb(26, 189, 183) },
                { "CardRightBack", Color.FromArgb(26,189,91) },
                { "CardLeftFore", Color.Black },
                { "CardRightFore", Color.Black },
                { "ChoiceColourBack", Color.LightGray },
                { "ChoiceColourFore", SystemColors.ControlText },
                { "CorrectBackcolour", Color.Lime },
                { "CorrectForecolour", Color.DarkGreen },
                { "IncorrectBackcolour", Color.Red },
                { "IncorrectForecolour", Color.Maroon },
                { "QuestionBackcolour", Color.White },
                { "QuestionForecolour", Color.Black },
                { "StopwatchFlash", Color.Red }
            };
            
            CanModify = modifiable;
        }
    }
}
