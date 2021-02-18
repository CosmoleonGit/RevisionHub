namespace RevisionProgram2.revision.assessments
{
    partial class AssessForm
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.BeginBtn = new System.Windows.Forms.Button();
            this.OptionsBtn = new System.Windows.Forms.Button();
            this.DescGroup = new System.Windows.Forms.GroupBox();
            this.DescPanel = new System.Windows.Forms.Panel();
            this.DescLbl = new System.Windows.Forms.Label();
            this.SettingsGroup = new System.Windows.Forms.GroupBox();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.DescGroup.SuspendLayout();
            this.DescPanel.SuspendLayout();
            this.SettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.LightGray;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Location = new System.Drawing.Point(139, 433);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(112, 38);
            this.CancelBtn.TabIndex = 6;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // BeginBtn
            // 
            this.BeginBtn.BackColor = System.Drawing.Color.LightGray;
            this.BeginBtn.FlatAppearance.BorderSize = 0;
            this.BeginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BeginBtn.Location = new System.Drawing.Point(18, 433);
            this.BeginBtn.Margin = new System.Windows.Forms.Padding(4);
            this.BeginBtn.Name = "BeginBtn";
            this.BeginBtn.Size = new System.Drawing.Size(112, 38);
            this.BeginBtn.TabIndex = 5;
            this.BeginBtn.Text = "Begin";
            this.BeginBtn.UseVisualStyleBackColor = false;
            this.BeginBtn.Click += new System.EventHandler(this.BeginBtn_Click);
            // 
            // OptionsBtn
            // 
            this.OptionsBtn.BackColor = System.Drawing.Color.LightGray;
            this.OptionsBtn.FlatAppearance.BorderSize = 0;
            this.OptionsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionsBtn.Location = new System.Drawing.Point(261, 433);
            this.OptionsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.OptionsBtn.Name = "OptionsBtn";
            this.OptionsBtn.Size = new System.Drawing.Size(134, 38);
            this.OptionsBtn.TabIndex = 7;
            this.OptionsBtn.Text = "Options >>>";
            this.OptionsBtn.UseVisualStyleBackColor = false;
            this.OptionsBtn.Click += new System.EventHandler(this.OptionsBtn_Click);
            // 
            // DescGroup
            // 
            this.DescGroup.Controls.Add(this.DescPanel);
            this.DescGroup.Location = new System.Drawing.Point(18, 20);
            this.DescGroup.Margin = new System.Windows.Forms.Padding(4);
            this.DescGroup.Name = "DescGroup";
            this.DescGroup.Padding = new System.Windows.Forms.Padding(4);
            this.DescGroup.Size = new System.Drawing.Size(377, 403);
            this.DescGroup.TabIndex = 0;
            this.DescGroup.TabStop = false;
            this.DescGroup.Text = "Description";
            // 
            // DescPanel
            // 
            this.DescPanel.AutoScroll = true;
            this.DescPanel.Controls.Add(this.DescLbl);
            this.DescPanel.Location = new System.Drawing.Point(9, 34);
            this.DescPanel.Margin = new System.Windows.Forms.Padding(4);
            this.DescPanel.Name = "DescPanel";
            this.DescPanel.Size = new System.Drawing.Size(359, 360);
            this.DescPanel.TabIndex = 1;
            // 
            // DescLbl
            // 
            this.DescLbl.AutoSize = true;
            this.DescLbl.Location = new System.Drawing.Point(4, 0);
            this.DescLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DescLbl.MaximumSize = new System.Drawing.Size(334, 0);
            this.DescLbl.Name = "DescLbl";
            this.DescLbl.Size = new System.Drawing.Size(99, 21);
            this.DescLbl.TabIndex = 2;
            this.DescLbl.Text = "(Description)";
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.Controls.Add(this.SettingsPanel);
            this.SettingsGroup.Location = new System.Drawing.Point(414, 20);
            this.SettingsGroup.Margin = new System.Windows.Forms.Padding(4);
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.Padding = new System.Windows.Forms.Padding(4);
            this.SettingsGroup.Size = new System.Drawing.Size(377, 451);
            this.SettingsGroup.TabIndex = 3;
            this.SettingsGroup.TabStop = false;
            this.SettingsGroup.Text = "Settings";
            this.SettingsGroup.Visible = false;
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.AutoScroll = true;
            this.SettingsPanel.Location = new System.Drawing.Point(9, 34);
            this.SettingsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(359, 407);
            this.SettingsPanel.TabIndex = 4;
            // 
            // AssessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(413, 490);
            this.Controls.Add(this.SettingsGroup);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.BeginBtn);
            this.Controls.Add(this.OptionsBtn);
            this.Controls.Add(this.DescGroup);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assessment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AssessForm_FormClosing);
            this.Load += new System.EventHandler(this.AssessForm_Load);
            this.DescGroup.ResumeLayout(false);
            this.DescPanel.ResumeLayout(false);
            this.DescPanel.PerformLayout();
            this.SettingsGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button CancelBtn;
        internal System.Windows.Forms.Button BeginBtn;
        internal System.Windows.Forms.Button OptionsBtn;
        internal System.Windows.Forms.GroupBox DescGroup;
        internal System.Windows.Forms.Label DescLbl;
        internal System.Windows.Forms.GroupBox SettingsGroup;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.Panel DescPanel;
    }
}