using RevisionProgram2.dialogs;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RevisionProgram2.revision.documents.Document;

namespace RevisionProgram2.revision.documents
{
    public partial class DocumentForm : Form
    {
        public DocumentForm(string name, string text = "")
        {
            InitializeComponent();

            Text = name + " - Document";
            DocumentTxt.Rtf = text;

            changes = false;

            if (text == "") ActiveControl = DocumentTxt;
        }

        public Action onFinish;
        bool changes = false;

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            closing = true;
            onFinish?.Invoke();
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Cancellation();
        }

        bool closing = false;

        private void DocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closing && e.CloseReason == CloseReason.UserClosing)
            {
                Cancellation();
                if (!closing) e.Cancel = true;
            }

            if (!e.Cancel)
            {
                onFinish.Invoke();
            }
        }

        private void Cancellation()
        {
            if (changes)
            {
                if (MsgBox.ShowWait("All saved changes will be lost. Proceed?",
                                       "Cancel",
                                       MsgBox.Options.yesNo,
                                       MsgBox.MsgIcon.EXCL) == "Yes")
                {
                    DialogResult = DialogResult.Cancel;
                    closing = true;
                    Close();
                }
            }
            else
            {
                closing = true;
                Close();
            }
        }

        private void DocumentTxt_TextChanged(object sender, EventArgs e)
        {
            changes = true;
        }

        internal string GetText => DocumentTxt.Rtf;

        private void DocumentForm_Load(object sender, EventArgs e)
        {
            Theme.ChangeFormTheme(this);
            Icon = Properties.Resources.Revision_Program;
        }

        private void DocumentTxt_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            LaunchWeblink(e.LinkText);
        }

        // Performs the actual browser launch to follow link:
        private void LaunchWeblink(string url)
        {
            if (IsHttpURL(url)) Process.Start(url);
        }

        private bool IsHttpURL(string url)
        {
            return
                (!string.IsNullOrWhiteSpace(url)) &&
                (url.ToLower().StartsWith("http") || url.ToLower().StartsWith("https"));
        }

        private void ChangeFontBtn_Click(object sender, EventArgs e)
        {
            if (ChangeFontDialog.ShowDialog() == DialogResult.OK)
            {
                DocumentTxt.SelectionFont = ChangeFontDialog.Font;
                DocumentTxt.SelectionColor = ChangeFontDialog.Color;
            }
        }

        private void ColourBtn_Click(object sender, EventArgs e)
        {
            DocumentTxt.SelectionColor = ColourBtn.BackColor;
        }

        private void DocumentTxt_SelectionChanged(object sender, EventArgs e)
        {
            ColourBtn.BackColor = DocumentTxt.SelectionColor;

            ChangeFontDialog.Font = DocumentTxt.SelectionFont;
        }

        private void BulletPointBtn_Click(object sender, EventArgs e)
        {
            DocumentTxt.SelectionBullet = !DocumentTxt.SelectionBullet;
        }

        public bool Save(string path)
        {
            try
            {
                File.Delete(path);
                File.WriteAllText(path, "DOCUMENT" + Environment.NewLine + documentVersion + Environment.NewLine + GetText);
                return true;
            }
            catch (IOException ex)
            {
                Helper.Error("Error saving document.", ex.Message);

                return false;
            }
        }
    }
}
