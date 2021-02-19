using RevisionProgram2.themes;
using RevisionProgram2.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram2.revision.explorer.panels
{
    public partial class ItemPanel : UserControl, IColourSpecific
    {
        public ItemPanel()
        {
            InitializeComponent();
        }

        public ItemPanel(Panel _owner, string name, string _dir)
        {
            Left = 10;
            owner = _owner;
            PanelName = name;
            
            Dir = _dir;

            InitializeComponent();

            NameLink.Text = name;
            IconBox.Image = GetIcon();
            Theme.ChangeControl(this);
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            CheckEditing();
        }

        protected readonly Panel owner;

        public string PanelName { get; private set; }
        public string Dir { get; protected set; }

        public bool EditMode { get; private set; }

        public virtual void OnClick() { }
        protected RevisionExplorer GetForm => (RevisionExplorer)owner.Parent;
        protected void Delete()
        {
            int scroll = owner.VerticalScroll.Value;

            int index = owner.Controls.IndexOf(this);
            owner.Controls.RemoveAt(index);
            for (int i = index; i < owner.Controls.Count; i++)
            {
                owner.Controls[i].Top -= Height + RevisionExplorer.itemSpacing - 2;
            }

            owner.VerticalScroll.Value = scroll;
        }

        protected void ChangeName(string newName)
        {
            PanelName = newName;
            NameLink.Text = newName;
            GetForm.ResetSearch();
        }

        protected bool Exists(string fullPath)
        {
            return File.Exists(fullPath) || Directory.Exists(fullPath);
        }

        public void UpdateTheme(Theme theme)
        {
            BackColor = theme.GetColour("RevisionItem");
        }

        private void NameLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OnClick();
        }

        private void ChangeBtn_Click(object sender, EventArgs e)
        {
            OnChange();
        }

        public void CheckEditing()
        {
            bool lastEditing = EditMode;
            EditMode = InEditingMode();

            if (lastEditing != EditMode)
            {
                if (!EditMode)
                {
                    NameLink.Width = EditingIcon.Right - NameLink.Left;
                }
                else
                {
                    NameLink.Width = EditingIcon.Left - NameLink.Left - 6;
                }

                EditingIcon.Visible = EditMode;

                EditingChanges(EditMode);
            }
        }

        protected virtual void EditingChanges(bool editing)
        {
            ChangeBtn.Enabled = !editing;
        }

        protected virtual void OnChange() { }

        public virtual bool SuitsCondition(string s)
        {
            return PanelName.ToLower().Contains(s.ToLower());
        }

        public virtual void MoveItem(string s) { }
        protected virtual bool InEditingMode() => false;
        protected virtual Image GetIcon() => null;

    }
}
