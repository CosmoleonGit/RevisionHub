namespace RevisionProgram2.packs
{
    partial class PacksForm
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
            this.PacksList = new System.Windows.Forms.ListBox();
            this.DescGroup = new System.Windows.Forms.GroupBox();
            this.DescPanel = new System.Windows.Forms.Panel();
            this.DescLbl = new System.Windows.Forms.Label();
            this.DownloadBtn = new System.Windows.Forms.Button();
            this.OverwriteBox = new System.Windows.Forms.PictureBox();
            this.OverwritePanel = new System.Windows.Forms.Panel();
            this.OverwriteLbl = new System.Windows.Forms.Label();
            this.SearchTxt = new System.Windows.Forms.TextBox();
            this.SearchLbl = new System.Windows.Forms.Label();
            this.DescGroup.SuspendLayout();
            this.DescPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverwriteBox)).BeginInit();
            this.OverwritePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PacksList
            // 
            this.PacksList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PacksList.BackColor = System.Drawing.SystemColors.Window;
            this.PacksList.FormattingEnabled = true;
            this.PacksList.HorizontalScrollbar = true;
            this.PacksList.ItemHeight = 20;
            this.PacksList.Location = new System.Drawing.Point(8, 55);
            this.PacksList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PacksList.Name = "PacksList";
            this.PacksList.Size = new System.Drawing.Size(288, 384);
            this.PacksList.TabIndex = 2;
            this.PacksList.SelectedIndexChanged += new System.EventHandler(this.PacksList_SelectedIndexChanged);
            // 
            // DescGroup
            // 
            this.DescGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescGroup.Controls.Add(this.DescPanel);
            this.DescGroup.Location = new System.Drawing.Point(304, 6);
            this.DescGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DescGroup.Name = "DescGroup";
            this.DescGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DescGroup.Size = new System.Drawing.Size(216, 436);
            this.DescGroup.TabIndex = 3;
            this.DescGroup.TabStop = false;
            this.DescGroup.Text = "Description";
            // 
            // DescPanel
            // 
            this.DescPanel.AutoScroll = true;
            this.DescPanel.Controls.Add(this.DescLbl);
            this.DescPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescPanel.Location = new System.Drawing.Point(3, 24);
            this.DescPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DescPanel.Name = "DescPanel";
            this.DescPanel.Size = new System.Drawing.Size(210, 408);
            this.DescPanel.TabIndex = 0;
            // 
            // DescLbl
            // 
            this.DescLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescLbl.Location = new System.Drawing.Point(0, 0);
            this.DescLbl.Name = "DescLbl";
            this.DescLbl.Size = new System.Drawing.Size(210, 408);
            this.DescLbl.TabIndex = 4;
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadBtn.BackColor = System.Drawing.Color.LightGray;
            this.DownloadBtn.Enabled = false;
            this.DownloadBtn.FlatAppearance.BorderSize = 0;
            this.DownloadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadBtn.Location = new System.Drawing.Point(8, 459);
            this.DownloadBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(289, 36);
            this.DownloadBtn.TabIndex = 5;
            this.DownloadBtn.Text = "Download Pack";
            this.DownloadBtn.UseVisualStyleBackColor = false;
            this.DownloadBtn.Click += new System.EventHandler(this.DownloadBtn_Click);
            // 
            // OverwriteBox
            // 
            this.OverwriteBox.Image = global::RevisionProgram2.Properties.Resources.SmallExcl;
            this.OverwriteBox.Location = new System.Drawing.Point(3, 9);
            this.OverwriteBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OverwriteBox.Name = "OverwriteBox";
            this.OverwriteBox.Size = new System.Drawing.Size(18, 21);
            this.OverwriteBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.OverwriteBox.TabIndex = 8;
            this.OverwriteBox.TabStop = false;
            // 
            // OverwritePanel
            // 
            this.OverwritePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OverwritePanel.Controls.Add(this.OverwriteLbl);
            this.OverwritePanel.Controls.Add(this.OverwriteBox);
            this.OverwritePanel.Location = new System.Drawing.Point(304, 459);
            this.OverwritePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OverwritePanel.Name = "OverwritePanel";
            this.OverwritePanel.Size = new System.Drawing.Size(216, 36);
            this.OverwritePanel.TabIndex = 6;
            this.OverwritePanel.Visible = false;
            // 
            // OverwriteLbl
            // 
            this.OverwriteLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.OverwriteLbl.Location = new System.Drawing.Point(27, 0);
            this.OverwriteLbl.Name = "OverwriteLbl";
            this.OverwriteLbl.Size = new System.Drawing.Size(189, 36);
            this.OverwriteLbl.TabIndex = 7;
            this.OverwriteLbl.Text = "Overwrite";
            this.OverwriteLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchTxt
            // 
            this.SearchTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTxt.Location = new System.Drawing.Point(72, 16);
            this.SearchTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SearchTxt.Name = "SearchTxt";
            this.SearchTxt.Size = new System.Drawing.Size(224, 27);
            this.SearchTxt.TabIndex = 1;
            this.SearchTxt.TextChanged += new System.EventHandler(this.SearchTxt_TextChanged);
            // 
            // SearchLbl
            // 
            this.SearchLbl.AutoSize = true;
            this.SearchLbl.Location = new System.Drawing.Point(14, 20);
            this.SearchLbl.Name = "SearchLbl";
            this.SearchLbl.Size = new System.Drawing.Size(56, 20);
            this.SearchLbl.TabIndex = 0;
            this.SearchLbl.Text = "Search:";
            // 
            // PacksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.SearchTxt);
            this.Controls.Add(this.SearchLbl);
            this.Controls.Add(this.OverwritePanel);
            this.Controls.Add(this.DownloadBtn);
            this.Controls.Add(this.DescGroup);
            this.Controls.Add(this.PacksList);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(477, 388);
            this.Name = "PacksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Packs";
            this.Load += new System.EventHandler(this.PacksForm_Load);
            this.DescGroup.ResumeLayout(false);
            this.DescPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OverwriteBox)).EndInit();
            this.OverwritePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ListBox PacksList;
        private System.Windows.Forms.GroupBox DescGroup;
        private System.Windows.Forms.Label DescLbl;
        private System.Windows.Forms.Panel DescPanel;
        private System.Windows.Forms.Button DownloadBtn;
        private System.Windows.Forms.PictureBox OverwriteBox;
        private System.Windows.Forms.Panel OverwritePanel;
        private System.Windows.Forms.Label OverwriteLbl;
        private System.Windows.Forms.TextBox SearchTxt;
        private System.Windows.Forms.Label SearchLbl;
    }
}