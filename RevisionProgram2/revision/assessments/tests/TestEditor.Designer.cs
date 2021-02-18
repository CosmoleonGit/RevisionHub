namespace RevisionProgram2.revision.assessments.tests
{
    partial class TestEditor
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
            this.QuestionPanel = new System.Windows.Forms.Panel();
            this.AddBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.DescBtn = new System.Windows.Forms.Button();
            this.DescGroup = new System.Windows.Forms.GroupBox();
            this.DescTxt = new RevisionProgram2.specialControls.SpecialTextBox();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.NumLbl = new System.Windows.Forms.Label();
            this.DescGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuestionPanel
            // 
            this.QuestionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionPanel.AutoScroll = true;
            this.QuestionPanel.Location = new System.Drawing.Point(14, 54);
            this.QuestionPanel.Name = "QuestionPanel";
            this.QuestionPanel.Size = new System.Drawing.Size(369, 345);
            this.QuestionPanel.TabIndex = 3;
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.LightGray;
            this.AddBtn.FlatAppearance.BorderSize = 0;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Location = new System.Drawing.Point(14, 16);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(107, 31);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Add Question";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.BackColor = System.Drawing.Color.LightGray;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Location = new System.Drawing.Point(297, 406);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(87, 31);
            this.CancelBtn.TabIndex = 8;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.BackColor = System.Drawing.Color.LightGray;
            this.OKBtn.Enabled = false;
            this.OKBtn.FlatAppearance.BorderSize = 0;
            this.OKBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKBtn.Location = new System.Drawing.Point(201, 406);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(87, 31);
            this.OKBtn.TabIndex = 7;
            this.OKBtn.Text = "Save";
            this.OKBtn.UseVisualStyleBackColor = false;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // DescBtn
            // 
            this.DescBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DescBtn.BackColor = System.Drawing.Color.LightGray;
            this.DescBtn.FlatAppearance.BorderSize = 0;
            this.DescBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DescBtn.Location = new System.Drawing.Point(263, 16);
            this.DescBtn.Name = "DescBtn";
            this.DescBtn.Size = new System.Drawing.Size(120, 31);
            this.DescBtn.TabIndex = 2;
            this.DescBtn.Text = "Description >>>";
            this.DescBtn.UseVisualStyleBackColor = false;
            this.DescBtn.Click += new System.EventHandler(this.DescBtn_Click);
            // 
            // DescGroup
            // 
            this.DescGroup.Controls.Add(this.DescTxt);
            this.DescGroup.Location = new System.Drawing.Point(388, 16);
            this.DescGroup.Name = "DescGroup";
            this.DescGroup.Size = new System.Drawing.Size(233, 421);
            this.DescGroup.TabIndex = 4;
            this.DescGroup.TabStop = false;
            this.DescGroup.Text = "Description";
            this.DescGroup.Visible = false;
            // 
            // DescTxt
            // 
            this.DescTxt.AllowSpecialCharacters = false;
            this.DescTxt.Location = new System.Drawing.Point(7, 27);
            this.DescTxt.Multiline = true;
            this.DescTxt.Name = "DescTxt";
            this.DescTxt.Size = new System.Drawing.Size(219, 387);
            this.DescTxt.TabIndex = 5;
            this.DescTxt.TextChanged += new System.EventHandler(this.DescTxt_TextChanged);
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PreviewBtn.BackColor = System.Drawing.Color.LightGray;
            this.PreviewBtn.FlatAppearance.BorderSize = 0;
            this.PreviewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBtn.Location = new System.Drawing.Point(12, 406);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(87, 31);
            this.PreviewBtn.TabIndex = 6;
            this.PreviewBtn.Text = "Preview";
            this.PreviewBtn.UseVisualStyleBackColor = false;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // NumLbl
            // 
            this.NumLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumLbl.Location = new System.Drawing.Point(126, 16);
            this.NumLbl.Name = "NumLbl";
            this.NumLbl.Size = new System.Drawing.Size(132, 31);
            this.NumLbl.TabIndex = 1;
            this.NumLbl.Text = "0 questions";
            this.NumLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(397, 451);
            this.Controls.Add(this.NumLbl);
            this.Controls.Add(this.PreviewBtn);
            this.Controls.Add(this.DescGroup);
            this.Controls.Add(this.DescBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.QuestionPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(413, 4096);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(413, 490);
            this.Name = "TestEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestEditor_FormClosing);
            this.Load += new System.EventHandler(this.TestEditor_Load);
            this.DescGroup.ResumeLayout(false);
            this.DescGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel QuestionPanel;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        internal System.Windows.Forms.Button DescBtn;
        internal System.Windows.Forms.GroupBox DescGroup;
        private specialControls.SpecialTextBox DescTxt;
        private System.Windows.Forms.Button PreviewBtn;
        private System.Windows.Forms.Label NumLbl;
    }
}