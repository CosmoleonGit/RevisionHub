namespace RevisionProgram2.revision.assessments.tests
{
    partial class TestTester
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
            this.TypedPanel = new System.Windows.Forms.Panel();
            this.InputTxt = new RevisionProgram2.specialControls.SpecialTextBox();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.MultiplePanel = new System.Windows.Forms.Panel();
            this.TestProgress = new System.Windows.Forms.ProgressBar();
            this.CorrectPanel = new System.Windows.Forms.Panel();
            this.NextBtn = new System.Windows.Forms.Button();
            this.CorrectLbl = new RevisionProgram2.specialControls.ColourSpecificLabel();
            this.AnswersLbl = new System.Windows.Forms.Label();
            this.QuestionLbl = new RevisionProgram2.specialControls.ColourSpecificLabel();
            this.NumLbl = new System.Windows.Forms.Label();
            this.TypedPanel.SuspendLayout();
            this.CorrectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TypedPanel
            // 
            this.TypedPanel.Controls.Add(this.InputTxt);
            this.TypedPanel.Controls.Add(this.CheckBtn);
            this.TypedPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TypedPanel.Location = new System.Drawing.Point(0, 225);
            this.TypedPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TypedPanel.Name = "TypedPanel";
            this.TypedPanel.Size = new System.Drawing.Size(446, 71);
            this.TypedPanel.TabIndex = 3;
            // 
            // InputTxt
            // 
            this.InputTxt.AllowSpecialCharacters = true;
            this.InputTxt.Location = new System.Drawing.Point(14, 21);
            this.InputTxt.Name = "InputTxt";
            this.InputTxt.Size = new System.Drawing.Size(308, 27);
            this.InputTxt.TabIndex = 4;
            this.InputTxt.TextChanged += new System.EventHandler(this.InputTxt_TextChanged);
            // 
            // CheckBtn
            // 
            this.CheckBtn.BackColor = System.Drawing.Color.LightGray;
            this.CheckBtn.Enabled = false;
            this.CheckBtn.FlatAppearance.BorderSize = 0;
            this.CheckBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBtn.Location = new System.Drawing.Point(329, 19);
            this.CheckBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(99, 33);
            this.CheckBtn.TabIndex = 5;
            this.CheckBtn.Text = "Check";
            this.CheckBtn.UseVisualStyleBackColor = false;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // MultiplePanel
            // 
            this.MultiplePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MultiplePanel.Location = new System.Drawing.Point(0, 296);
            this.MultiplePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MultiplePanel.Name = "MultiplePanel";
            this.MultiplePanel.Size = new System.Drawing.Size(446, 153);
            this.MultiplePanel.TabIndex = 6;
            this.MultiplePanel.Visible = false;
            // 
            // TestProgress
            // 
            this.TestProgress.BackColor = System.Drawing.SystemColors.Control;
            this.TestProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.TestProgress.Location = new System.Drawing.Point(0, 0);
            this.TestProgress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TestProgress.Name = "TestProgress";
            this.TestProgress.Size = new System.Drawing.Size(446, 36);
            this.TestProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.TestProgress.TabIndex = 0;
            // 
            // CorrectPanel
            // 
            this.CorrectPanel.Controls.Add(this.NextBtn);
            this.CorrectPanel.Controls.Add(this.CorrectLbl);
            this.CorrectPanel.Controls.Add(this.AnswersLbl);
            this.CorrectPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CorrectPanel.Location = new System.Drawing.Point(0, 449);
            this.CorrectPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CorrectPanel.Name = "CorrectPanel";
            this.CorrectPanel.Size = new System.Drawing.Size(446, 153);
            this.CorrectPanel.TabIndex = 7;
            this.CorrectPanel.Visible = false;
            // 
            // NextBtn
            // 
            this.NextBtn.BackColor = System.Drawing.Color.LightGray;
            this.NextBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NextBtn.FlatAppearance.BorderSize = 0;
            this.NextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextBtn.Location = new System.Drawing.Point(0, 117);
            this.NextBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(446, 36);
            this.NextBtn.TabIndex = 10;
            this.NextBtn.Text = "Next Question";
            this.NextBtn.UseVisualStyleBackColor = false;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // CorrectLbl
            // 
            this.CorrectLbl.BackColourName = null;
            this.CorrectLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.CorrectLbl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CorrectLbl.ForeColourName = null;
            this.CorrectLbl.Location = new System.Drawing.Point(0, 0);
            this.CorrectLbl.Name = "CorrectLbl";
            this.CorrectLbl.Size = new System.Drawing.Size(446, 47);
            this.CorrectLbl.TabIndex = 8;
            this.CorrectLbl.Text = "Correct!";
            this.CorrectLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AnswersLbl
            // 
            this.AnswersLbl.AutoSize = true;
            this.AnswersLbl.Location = new System.Drawing.Point(16, 64);
            this.AnswersLbl.MaximumSize = new System.Drawing.Size(414, 0);
            this.AnswersLbl.Name = "AnswersLbl";
            this.AnswersLbl.Size = new System.Drawing.Size(110, 20);
            this.AnswersLbl.TabIndex = 9;
            this.AnswersLbl.Text = "Correct answer:";
            // 
            // QuestionLbl
            // 
            this.QuestionLbl.BackColourName = "QuestionBackcolour";
            this.QuestionLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.QuestionLbl.ForeColourName = "QuestionForecolour";
            this.QuestionLbl.Location = new System.Drawing.Point(0, 72);
            this.QuestionLbl.Name = "QuestionLbl";
            this.QuestionLbl.Size = new System.Drawing.Size(446, 153);
            this.QuestionLbl.TabIndex = 2;
            this.QuestionLbl.Text = "(Question)";
            this.QuestionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumLbl
            // 
            this.NumLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.NumLbl.Location = new System.Drawing.Point(0, 36);
            this.NumLbl.Name = "NumLbl";
            this.NumLbl.Size = new System.Drawing.Size(446, 36);
            this.NumLbl.TabIndex = 1;
            this.NumLbl.Text = "Question 0 of 0";
            this.NumLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 603);
            this.Controls.Add(this.CorrectPanel);
            this.Controls.Add(this.MultiplePanel);
            this.Controls.Add(this.TypedPanel);
            this.Controls.Add(this.QuestionLbl);
            this.Controls.Add(this.NumLbl);
            this.Controls.Add(this.TestProgress);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TestTester";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestTester_FormClosing);
            this.Load += new System.EventHandler(this.TestTester_Load);
            this.TypedPanel.ResumeLayout(false);
            this.TypedPanel.PerformLayout();
            this.CorrectPanel.ResumeLayout(false);
            this.CorrectPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel TypedPanel;
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Panel MultiplePanel;
        private System.Windows.Forms.ProgressBar TestProgress;
        private System.Windows.Forms.Panel CorrectPanel;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Label AnswersLbl;
        private specialControls.ColourSpecificLabel CorrectLbl;
        private specialControls.SpecialTextBox InputTxt;
        private specialControls.ColourSpecificLabel QuestionLbl;
        private System.Windows.Forms.Label NumLbl;
    }
}