
namespace RevisionProgram2.revision.explorer.panels
{
    partial class FolderPanel
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
            this.MoveStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsContext
            // 
            this.OptionsContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MoveStrip,
            this.DeleteStrip,
            this.RenameStrip});
            this.OptionsContext.Name = "OptionsContext";
            this.OptionsContext.Size = new System.Drawing.Size(181, 92);
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
            // FolderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FolderPanel";
            this.OptionsContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip OptionsContext;
        private System.Windows.Forms.ToolStripMenuItem MoveStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteStrip;
        private System.Windows.Forms.ToolStripMenuItem RenameStrip;
    }
}
