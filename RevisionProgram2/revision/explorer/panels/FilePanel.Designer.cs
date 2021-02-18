
namespace RevisionProgram2.revision.explorer.panels
{
    partial class FilePanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OptionsContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MoveStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DuplicateStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsContext
            // 
            this.OptionsContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditStrip,
            this.toolStripSeparator1,
            this.MoveStrip,
            this.DeleteStrip,
            this.DuplicateStrip,
            this.RenameStrip});
            this.OptionsContext.Name = "OptionsContext";
            this.OptionsContext.Size = new System.Drawing.Size(181, 142);
            // 
            // EditStrip
            // 
            this.EditStrip.Name = "EditStrip";
            this.EditStrip.Size = new System.Drawing.Size(180, 22);
            this.EditStrip.Text = "Edit";
            this.EditStrip.Click += new System.EventHandler(this.EditStrip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // MoveStrip
            // 
            this.MoveStrip.Name = "MoveStrip";
            this.MoveStrip.Size = new System.Drawing.Size(180, 22);
            this.MoveStrip.Text = "Move";
            this.MoveStrip.Click += new System.EventHandler(this.MoveStrip_Click);
            // 
            // DeleteStrip
            // 
            this.DeleteStrip.Name = "DeleteStrip";
            this.DeleteStrip.Size = new System.Drawing.Size(180, 22);
            this.DeleteStrip.Text = "Delete";
            this.DeleteStrip.Click += new System.EventHandler(this.DeleteStrip_Click);
            // 
            // RenameStrip
            // 
            this.RenameStrip.Name = "RenameStrip";
            this.RenameStrip.Size = new System.Drawing.Size(180, 22);
            this.RenameStrip.Text = "Rename";
            this.RenameStrip.Click += new System.EventHandler(this.RenameStrip_Click);
            // 
            // DuplicateStrip
            // 
            this.DuplicateStrip.Name = "DuplicateStrip";
            this.DuplicateStrip.Size = new System.Drawing.Size(180, 22);
            this.DuplicateStrip.Text = "Duplicate";
            this.DuplicateStrip.Click += new System.EventHandler(this.DuplicateStrip_Click);
            // 
            // FilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FilePanel";
            this.OptionsContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip OptionsContext;
        private System.Windows.Forms.ToolStripMenuItem EditStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MoveStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteStrip;
        private System.Windows.Forms.ToolStripMenuItem RenameStrip;
        private System.Windows.Forms.ToolStripMenuItem DuplicateStrip;
    }
}
