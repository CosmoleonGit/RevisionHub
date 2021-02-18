using RevisionProgram2.dialogs;
using RevisionProgram2.Themes;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RevisionProgram2.tools
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private abstract class Page : TabPage
        {
            public Page(TabControl control) : base()
            {
                this.control = control;
                Size = new Size(control.Width - 8, control.Height - 26);
            }

            protected readonly TabControl control;
        }

        private class NotePage : Page
        {
            protected readonly RichTextBox notes = new RichTextBox();

            public NotePage(TabControl control, string text = "") : base(control)
            {
                Text = "Page " + (control.TabCount);
                Font = Font;
                
                notes.Location = new Point(6, 6);
                notes.Dock = DockStyle.Fill;
                //notes.Size = new Size(Width - 12, Height - 12);
                notes.Font = control.Font;
                notes.Text = text;
                Controls.Add(notes);

                Theme.ChangeControl(this);
            }

            public void Save()
            {
                if (notes.Text == "") return;

                File.WriteAllText(Helper.directory + "Notes/" + Text, notes.Text);
            }
        }

        private class AddPage : Page
        {
            public AddPage(TabControl control) : base(control)
            {
                Text = "+";
                Font = control.Font;

                Button addBtn = new Button
                {
                    Size = new Size(100, 36),
                    Text = "Create Tab",
                    FlatStyle = FlatStyle.Flat,
                    Anchor = AnchorStyles.None
                };
                
                addBtn.Location = new Point(Width / 2 - addBtn.Width / 2,
                                           Height / 2 - addBtn.Height / 2);

                addBtn.Click += (s, e) =>
                {
                    int currentID = control.SelectedIndex;
                    control.TabPages.Insert(currentID, new NotePage(control));
                    control.SelectedIndex = currentID;
                };

                Controls.Add(addBtn);

                Theme.ChangeControl(this);
            }
        }

        private void Notepad_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;

            Directory.CreateDirectory(Helper.directory + "Notes");

            NotesTabs.TabPages.Add(new AddPage(NotesTabs));

            foreach (string deleteFile in Directory.GetFiles(Helper.directory + "Notes", "*.*", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    //NotesTabs.TabPages.Add(getNotePage(File.ReadAllText(deleteFile)));
                    NotesTabs.TabPages.Insert(NotesTabs.TabCount - 1, new NotePage(NotesTabs, File.ReadAllText(deleteFile)));
                    RemoveBtn.Enabled = true;
                } catch
                {
                    continue;
                }
            }

            NotesTabs.SelectedIndex = 0;
        }

        private void Notepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (string file in Directory.GetFiles(Helper.directory + "Notes", "*.*", SearchOption.TopDirectoryOnly))
            {
                File.Delete(file);
            }

            foreach (TabPage page in NotesTabs.TabPages)
            {
                if (page is NotePage np) np.Save();
            }
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowWait("Are you sure you want to delete this page?",
                                "Delete",
                                new string[] { "Yes", "No"},
                                MsgBox.MsgIcon.EXCL) == "Yes") {

                int selected = NotesTabs.SelectedIndex;
                NotesTabs.TabPages.RemoveAt(selected);

                for (int i = selected; i < NotesTabs.TabCount - 1; i++)
                {
                    NotesTabs.TabPages[i].Text = "Page " + (i + 1);
                }

                NotesTabs.SelectedIndex = selected;
            }
        }

        private void NotesTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveBtn.Enabled = NotesTabs.SelectedIndex < NotesTabs.TabCount - 1;
        }
    }
}
