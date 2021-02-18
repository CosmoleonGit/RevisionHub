namespace RevisionProgram2.news
{
    partial class NewsForm
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
            this.ColourPanel = new System.Windows.Forms.Panel();
            this.NewsTxt = new System.Windows.Forms.RichTextBox();
            this.ColourPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColourPanel
            // 
            this.ColourPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColourPanel.AutoScroll = true;
            this.ColourPanel.Controls.Add(this.NewsTxt);
            this.ColourPanel.Location = new System.Drawing.Point(12, 12);
            this.ColourPanel.Name = "ColourPanel";
            this.ColourPanel.Size = new System.Drawing.Size(400, 400);
            this.ColourPanel.TabIndex = 4;
            // 
            // NewsTxt
            // 
            this.NewsTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewsTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewsTxt.Location = new System.Drawing.Point(0, 0);
            this.NewsTxt.Name = "NewsTxt";
            this.NewsTxt.ReadOnly = true;
            this.NewsTxt.Size = new System.Drawing.Size(400, 400);
            this.NewsTxt.TabIndex = 0;
            this.NewsTxt.TabStop = false;
            this.NewsTxt.Text = "";
            this.NewsTxt.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.NewsTxt_LinkClicked);
            // 
            // NewsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 424);
            this.Controls.Add(this.ColourPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(390, 413);
            this.Name = "NewsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notices";
            this.Load += new System.EventHandler(this.NewsForm_Load);
            this.ColourPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel ColourPanel;
        private System.Windows.Forms.RichTextBox NewsTxt;
    }
}