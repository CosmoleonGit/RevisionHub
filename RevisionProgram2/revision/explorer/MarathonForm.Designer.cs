namespace RevisionProgram2.revision.explorer
{
    partial class MarathonForm
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
            this.ListLbl = new System.Windows.Forms.Label();
            this.ShuffleBtn = new System.Windows.Forms.Button();
            this.MoveUpBtn = new System.Windows.Forms.Button();
            this.MoveDownBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.BeginBtn = new System.Windows.Forms.Button();
            this.MarathonList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // ListLbl
            // 
            this.ListLbl.AutoSize = true;
            this.ListLbl.Location = new System.Drawing.Point(14, 12);
            this.ListLbl.Name = "ListLbl";
            this.ListLbl.Size = new System.Drawing.Size(95, 19);
            this.ListLbl.TabIndex = 0;
            this.ListLbl.Text = "Marathon List";
            // 
            // ShuffleBtn
            // 
            this.ShuffleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ShuffleBtn.BackColor = System.Drawing.Color.LightGray;
            this.ShuffleBtn.FlatAppearance.BorderSize = 0;
            this.ShuffleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShuffleBtn.Location = new System.Drawing.Point(288, 305);
            this.ShuffleBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShuffleBtn.Name = "ShuffleBtn";
            this.ShuffleBtn.Size = new System.Drawing.Size(87, 30);
            this.ShuffleBtn.TabIndex = 2;
            this.ShuffleBtn.Text = "Shuffle";
            this.ShuffleBtn.UseVisualStyleBackColor = false;
            this.ShuffleBtn.Click += new System.EventHandler(this.ShuffleBtn_Click);
            // 
            // MoveUpBtn
            // 
            this.MoveUpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MoveUpBtn.BackColor = System.Drawing.Color.LightGray;
            this.MoveUpBtn.Enabled = false;
            this.MoveUpBtn.FlatAppearance.BorderSize = 0;
            this.MoveUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveUpBtn.Location = new System.Drawing.Point(14, 305);
            this.MoveUpBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MoveUpBtn.Name = "MoveUpBtn";
            this.MoveUpBtn.Size = new System.Drawing.Size(93, 30);
            this.MoveUpBtn.TabIndex = 3;
            this.MoveUpBtn.Text = "Move Up";
            this.MoveUpBtn.UseVisualStyleBackColor = false;
            this.MoveUpBtn.Click += new System.EventHandler(this.MoveUpBtn_Click);
            // 
            // MoveDownBtn
            // 
            this.MoveDownBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MoveDownBtn.BackColor = System.Drawing.Color.LightGray;
            this.MoveDownBtn.Enabled = false;
            this.MoveDownBtn.FlatAppearance.BorderSize = 0;
            this.MoveDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MoveDownBtn.Location = new System.Drawing.Point(113, 305);
            this.MoveDownBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MoveDownBtn.Name = "MoveDownBtn";
            this.MoveDownBtn.Size = new System.Drawing.Size(93, 30);
            this.MoveDownBtn.TabIndex = 4;
            this.MoveDownBtn.Text = "Move Down";
            this.MoveDownBtn.UseVisualStyleBackColor = false;
            this.MoveDownBtn.Click += new System.EventHandler(this.MoveDownBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.BackColor = System.Drawing.Color.LightGray;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Location = new System.Drawing.Point(288, 362);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(87, 30);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // BeginBtn
            // 
            this.BeginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BeginBtn.BackColor = System.Drawing.Color.LightGray;
            this.BeginBtn.FlatAppearance.BorderSize = 0;
            this.BeginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BeginBtn.Location = new System.Drawing.Point(194, 362);
            this.BeginBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BeginBtn.Name = "BeginBtn";
            this.BeginBtn.Size = new System.Drawing.Size(87, 30);
            this.BeginBtn.TabIndex = 6;
            this.BeginBtn.Text = "Begin";
            this.BeginBtn.UseVisualStyleBackColor = false;
            this.BeginBtn.Click += new System.EventHandler(this.BeginBtn_Click);
            // 
            // MarathonList
            // 
            this.MarathonList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MarathonList.FormattingEnabled = true;
            this.MarathonList.Location = new System.Drawing.Point(18, 34);
            this.MarathonList.Name = "MarathonList";
            this.MarathonList.Size = new System.Drawing.Size(357, 264);
            this.MarathonList.TabIndex = 7;
            this.MarathonList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.MarathonList_ItemCheck);
            this.MarathonList.SelectedIndexChanged += new System.EventHandler(this.MarathonList_SelectedIndexChanged);
            // 
            // MarathonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 408);
            this.Controls.Add(this.MarathonList);
            this.Controls.Add(this.BeginBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.MoveDownBtn);
            this.Controls.Add(this.MoveUpBtn);
            this.Controls.Add(this.ShuffleBtn);
            this.Controls.Add(this.ListLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(406, 447);
            this.Name = "MarathonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marathon";
            this.Load += new System.EventHandler(this.MarathonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ListLbl;
        private System.Windows.Forms.Button ShuffleBtn;
        private System.Windows.Forms.Button MoveUpBtn;
        private System.Windows.Forms.Button MoveDownBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button BeginBtn;
        private System.Windows.Forms.CheckedListBox MarathonList;
    }
}