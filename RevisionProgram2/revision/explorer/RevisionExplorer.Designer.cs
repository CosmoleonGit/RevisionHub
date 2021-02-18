namespace RevisionProgram2.revision
{
    partial class RevisionExplorer
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
            this.CreateGroup = new System.Windows.Forms.GroupBox();
            this.DocumentBtn = new System.Windows.Forms.Button();
            this.AddFlashcardsBtn = new System.Windows.Forms.Button();
            this.AddTestBtn = new System.Windows.Forms.Button();
            this.AddFolderBtn = new System.Windows.Forms.Button();
            this.UpToBtn = new System.Windows.Forms.Button();
            this.ListPanel = new System.Windows.Forms.Panel();
            this.PathLbl = new System.Windows.Forms.Label();
            this.searchLbl = new System.Windows.Forms.Label();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.MoveGroup = new System.Windows.Forms.GroupBox();
            this.MoveHereBtn = new System.Windows.Forms.Button();
            this.CancelMoveBtn = new System.Windows.Forms.Button();
            this.MovePathLbl = new System.Windows.Forms.Label();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.MarathonBtn = new System.Windows.Forms.Button();
            this.CreateGroup.SuspendLayout();
            this.MoveGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateGroup
            // 
            this.CreateGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateGroup.Controls.Add(this.DocumentBtn);
            this.CreateGroup.Controls.Add(this.AddFlashcardsBtn);
            this.CreateGroup.Controls.Add(this.AddTestBtn);
            this.CreateGroup.Controls.Add(this.AddFolderBtn);
            this.CreateGroup.Location = new System.Drawing.Point(429, 53);
            this.CreateGroup.Name = "CreateGroup";
            this.CreateGroup.Size = new System.Drawing.Size(131, 473);
            this.CreateGroup.TabIndex = 10;
            this.CreateGroup.TabStop = false;
            this.CreateGroup.Text = "Create New";
            // 
            // DocumentBtn
            // 
            this.DocumentBtn.BackColor = System.Drawing.Color.LightGray;
            this.DocumentBtn.FlatAppearance.BorderSize = 0;
            this.DocumentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DocumentBtn.Location = new System.Drawing.Point(7, 140);
            this.DocumentBtn.Name = "DocumentBtn";
            this.DocumentBtn.Size = new System.Drawing.Size(117, 31);
            this.DocumentBtn.TabIndex = 14;
            this.DocumentBtn.Text = "Document";
            this.DocumentBtn.UseVisualStyleBackColor = false;
            this.DocumentBtn.Click += new System.EventHandler(this.DocumentBtn_Click);
            // 
            // AddFlashcardsBtn
            // 
            this.AddFlashcardsBtn.BackColor = System.Drawing.Color.LightGray;
            this.AddFlashcardsBtn.FlatAppearance.BorderSize = 0;
            this.AddFlashcardsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFlashcardsBtn.Location = new System.Drawing.Point(7, 103);
            this.AddFlashcardsBtn.Name = "AddFlashcardsBtn";
            this.AddFlashcardsBtn.Size = new System.Drawing.Size(117, 31);
            this.AddFlashcardsBtn.TabIndex = 13;
            this.AddFlashcardsBtn.Text = "Flashcards";
            this.AddFlashcardsBtn.UseVisualStyleBackColor = false;
            this.AddFlashcardsBtn.Click += new System.EventHandler(this.AddFlashcardsBtn_Click);
            // 
            // AddTestBtn
            // 
            this.AddTestBtn.BackColor = System.Drawing.Color.LightGray;
            this.AddTestBtn.FlatAppearance.BorderSize = 0;
            this.AddTestBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTestBtn.Location = new System.Drawing.Point(7, 66);
            this.AddTestBtn.Name = "AddTestBtn";
            this.AddTestBtn.Size = new System.Drawing.Size(117, 31);
            this.AddTestBtn.TabIndex = 12;
            this.AddTestBtn.Text = "Test";
            this.AddTestBtn.UseVisualStyleBackColor = false;
            this.AddTestBtn.Click += new System.EventHandler(this.AddTestBtn_Click);
            // 
            // AddFolderBtn
            // 
            this.AddFolderBtn.BackColor = System.Drawing.Color.LightGray;
            this.AddFolderBtn.FlatAppearance.BorderSize = 0;
            this.AddFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddFolderBtn.Location = new System.Drawing.Point(7, 27);
            this.AddFolderBtn.Name = "AddFolderBtn";
            this.AddFolderBtn.Size = new System.Drawing.Size(117, 31);
            this.AddFolderBtn.TabIndex = 11;
            this.AddFolderBtn.Text = "Folder";
            this.AddFolderBtn.UseVisualStyleBackColor = false;
            this.AddFolderBtn.Click += new System.EventHandler(this.AddFolderBtn_Click);
            // 
            // UpToBtn
            // 
            this.UpToBtn.BackColor = System.Drawing.Color.LightGray;
            this.UpToBtn.Enabled = false;
            this.UpToBtn.FlatAppearance.BorderSize = 0;
            this.UpToBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpToBtn.Location = new System.Drawing.Point(14, 16);
            this.UpToBtn.Name = "UpToBtn";
            this.UpToBtn.Size = new System.Drawing.Size(27, 31);
            this.UpToBtn.TabIndex = 0;
            this.UpToBtn.Text = "↑";
            this.UpToBtn.UseVisualStyleBackColor = false;
            this.UpToBtn.Click += new System.EventHandler(this.UpToBtn_Click);
            // 
            // ListPanel
            // 
            this.ListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListPanel.AutoScroll = true;
            this.ListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListPanel.Location = new System.Drawing.Point(14, 53);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Size = new System.Drawing.Size(409, 510);
            this.ListPanel.TabIndex = 5;
            // 
            // PathLbl
            // 
            this.PathLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathLbl.AutoEllipsis = true;
            this.PathLbl.Location = new System.Drawing.Point(80, 20);
            this.PathLbl.Name = "PathLbl";
            this.PathLbl.Size = new System.Drawing.Size(283, 23);
            this.PathLbl.TabIndex = 2;
            this.PathLbl.Text = "Revision/";
            this.PathLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // searchLbl
            // 
            this.searchLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLbl.AutoSize = true;
            this.searchLbl.Location = new System.Drawing.Point(371, 21);
            this.searchLbl.Name = "searchLbl";
            this.searchLbl.Size = new System.Drawing.Size(52, 19);
            this.searchLbl.TabIndex = 3;
            this.searchLbl.Text = "Search:";
            // 
            // searchTxt
            // 
            this.searchTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTxt.Location = new System.Drawing.Point(429, 18);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(130, 25);
            this.searchTxt.TabIndex = 4;
            this.searchTxt.TextChanged += new System.EventHandler(this.SearchTxt_TextChanged);
            // 
            // MoveGroup
            // 
            this.MoveGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveGroup.Controls.Add(this.MoveHereBtn);
            this.MoveGroup.Controls.Add(this.CancelMoveBtn);
            this.MoveGroup.Controls.Add(this.MovePathLbl);
            this.MoveGroup.Location = new System.Drawing.Point(14, 497);
            this.MoveGroup.Name = "MoveGroup";
            this.MoveGroup.Size = new System.Drawing.Size(408, 66);
            this.MoveGroup.TabIndex = 6;
            this.MoveGroup.TabStop = false;
            this.MoveGroup.Text = "Move";
            this.MoveGroup.Visible = false;
            this.MoveGroup.VisibleChanged += new System.EventHandler(this.MoveGroup_VisibleChanged);
            // 
            // MoveHereBtn
            // 
            this.MoveHereBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MoveHereBtn.BackColor = System.Drawing.Color.LightGray;
            this.MoveHereBtn.FlatAppearance.BorderSize = 0;
            this.MoveHereBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveHereBtn.Location = new System.Drawing.Point(219, 27);
            this.MoveHereBtn.Name = "MoveHereBtn";
            this.MoveHereBtn.Size = new System.Drawing.Size(87, 31);
            this.MoveHereBtn.TabIndex = 8;
            this.MoveHereBtn.Text = "Move Here";
            this.MoveHereBtn.UseVisualStyleBackColor = false;
            this.MoveHereBtn.Click += new System.EventHandler(this.MoveHereBtn_Click);
            // 
            // CancelMoveBtn
            // 
            this.CancelMoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelMoveBtn.BackColor = System.Drawing.Color.LightGray;
            this.CancelMoveBtn.FlatAppearance.BorderSize = 0;
            this.CancelMoveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelMoveBtn.Location = new System.Drawing.Point(314, 27);
            this.CancelMoveBtn.Name = "CancelMoveBtn";
            this.CancelMoveBtn.Size = new System.Drawing.Size(87, 31);
            this.CancelMoveBtn.TabIndex = 9;
            this.CancelMoveBtn.Text = "Cancel";
            this.CancelMoveBtn.UseVisualStyleBackColor = false;
            this.CancelMoveBtn.Click += new System.EventHandler(this.CancelMoveBtn_Click);
            // 
            // MovePathLbl
            // 
            this.MovePathLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MovePathLbl.Location = new System.Drawing.Point(7, 27);
            this.MovePathLbl.Name = "MovePathLbl";
            this.MovePathLbl.Size = new System.Drawing.Size(205, 31);
            this.MovePathLbl.TabIndex = 7;
            this.MovePathLbl.Text = "(Path)";
            this.MovePathLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.BackColor = System.Drawing.Color.LightGray;
            this.RefreshBtn.FlatAppearance.BorderSize = 0;
            this.RefreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshBtn.Location = new System.Drawing.Point(47, 16);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(27, 31);
            this.RefreshBtn.TabIndex = 1;
            this.RefreshBtn.Text = "⟳";
            this.RefreshBtn.UseVisualStyleBackColor = false;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // MarathonBtn
            // 
            this.MarathonBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MarathonBtn.BackColor = System.Drawing.Color.LightGray;
            this.MarathonBtn.FlatAppearance.BorderSize = 0;
            this.MarathonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MarathonBtn.Location = new System.Drawing.Point(428, 532);
            this.MarathonBtn.Name = "MarathonBtn";
            this.MarathonBtn.Size = new System.Drawing.Size(134, 31);
            this.MarathonBtn.TabIndex = 10;
            this.MarathonBtn.Text = "Marathon";
            this.MarathonBtn.UseVisualStyleBackColor = false;
            this.MarathonBtn.Click += new System.EventHandler(this.MarathonBtn_Click);
            // 
            // RevisionExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 581);
            this.Controls.Add(this.MarathonBtn);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.MoveGroup);
            this.Controls.Add(this.searchTxt);
            this.Controls.Add(this.searchLbl);
            this.Controls.Add(this.CreateGroup);
            this.Controls.Add(this.UpToBtn);
            this.Controls.Add(this.ListPanel);
            this.Controls.Add(this.PathLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(400, 448);
            this.Name = "RevisionExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Revision Explorer";
            this.Load += new System.EventHandler(this.RevisionExplorer_Load);
            this.CreateGroup.ResumeLayout(false);
            this.MoveGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox CreateGroup;
        internal System.Windows.Forms.Button AddFlashcardsBtn;
        internal System.Windows.Forms.Button AddTestBtn;
        internal System.Windows.Forms.Button AddFolderBtn;
        internal System.Windows.Forms.Button UpToBtn;
        internal System.Windows.Forms.Panel ListPanel;
        internal System.Windows.Forms.Label PathLbl;
        private System.Windows.Forms.Label searchLbl;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.GroupBox MoveGroup;
        private System.Windows.Forms.Button MoveHereBtn;
        private System.Windows.Forms.Button CancelMoveBtn;
        private System.Windows.Forms.Label MovePathLbl;
        internal System.Windows.Forms.Button RefreshBtn;
        internal System.Windows.Forms.Button DocumentBtn;
        private System.Windows.Forms.Button MarathonBtn;
    }
}