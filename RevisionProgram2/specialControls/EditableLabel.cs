using RevisionProgram2.Themes;
using System;
using System.Windows.Forms;

namespace RevisionProgram2.specialControls
{
    public class EditableLabel : Label
    {
        public EditableLabel()
        {
            DoubleClick += DoubleClicked;
        }

        private void LoadTextbox()
        {
            
            void changeControl(Control c)
            {
                if (this != c && box != c)
                {
                    c.Click += (s, ev) =>
                    {
                        if (box == null) return;
                        Text = correct(Text, box.Text);
                        box.Dispose();
                        Parent.Controls.Remove(box);
                        Show();
                    };
                }
            }

            changeControl(Parent.Parent);

            foreach (Control c in Parent.Parent.Controls)
            {
                changeControl(c);
            }

            foreach (Control c in Parent.Controls)
            {
                changeControl(c);
            }


            //box.Leave += EditableLabel_Leave;
        }

        private void EditableLabel_Leave(object sender, EventArgs e)
        {
            if (box == null) return;
            Text = correct(Text, box.Text);
            box.Dispose();
            Parent.Controls.Remove(box);
            Show();
        }

        TextBox box;

        private void DoubleClicked(object sender, EventArgs e)
        {
            if (!canChange()) return;

            Hide();

            if (box == null) LoadTextbox();
            //if (box != null) box.Dispose();

            Parent.Controls.Add(box = new TextBox
            {
                Left = Left,
                Font = Font,
                Text = Text,
                Location = Location,
                AutoSize = false,
                Size = Size
            });

            Theme.ChangeControl(box);
            
            //LoadTextbox();
        }

        public Func<bool> canChange = () => true;
        public Func<string, string, string> correct = (string x, string y) => y;
    }
}
