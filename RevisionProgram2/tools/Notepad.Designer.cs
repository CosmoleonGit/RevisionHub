namespace RevisionProgram2.tools
{
    partial class Notepad
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.NotesTabs = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveBtn.BackColor = System.Drawing.Color.LightGray;
            this.RemoveBtn.Enabled = false;
            this.RemoveBtn.FlatAppearance.BorderSize = 0;
            this.RemoveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveBtn.Location = new System.Drawing.Point(383, 19);
            this.RemoveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(100, 36);
            this.RemoveBtn.TabIndex = 0;
            this.RemoveBtn.Text = "Remove";
            this.RemoveBtn.UseVisualStyleBackColor = false;
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // NotesTabs
            // 
            this.NotesTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotesTabs.Location = new System.Drawing.Point(16, 63);
            this.NotesTabs.Margin = new System.Windows.Forms.Padding(4);
            this.NotesTabs.Name = "NotesTabs";
            this.NotesTabs.SelectedIndex = 0;
            this.NotesTabs.Size = new System.Drawing.Size(467, 539);
            this.NotesTabs.TabIndex = 1;
            this.NotesTabs.SelectedIndexChanged += new System.EventHandler(this.NotesTabs_SelectedIndexChanged);
            // 
            // Notepad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 620);
            this.Controls.Add(this.RemoveBtn);
            this.Controls.Add(this.NotesTabs);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Notepad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notepad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Notepad_FormClosing);
            this.Load += new System.EventHandler(this.Notepad_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button RemoveBtn;
        internal System.Windows.Forms.TabControl NotesTabs;
    }
}