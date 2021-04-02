namespace RevisionProgram2.revision.assessments.tests
{
    partial class ResultsForm
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
            this.ScoreLbl = new System.Windows.Forms.Label();
            this.ResultsPanel = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.TestIncorrectBtn = new System.Windows.Forms.Button();
            this.TryAgainBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScoreLbl
            // 
            this.ScoreLbl.BackColor = System.Drawing.Color.Transparent;
            this.ScoreLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScoreLbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLbl.Location = new System.Drawing.Point(0, 0);
            this.ScoreLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ScoreLbl.Name = "ScoreLbl";
            this.ScoreLbl.Size = new System.Drawing.Size(521, 60);
            this.ScoreLbl.TabIndex = 0;
            this.ScoreLbl.Text = "You scored ";
            this.ScoreLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ResultsPanel
            // 
            this.ResultsPanel.AutoScroll = true;
            this.ResultsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ResultsPanel.Location = new System.Drawing.Point(0, 60);
            this.ResultsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ResultsPanel.Name = "ResultsPanel";
            this.ResultsPanel.Size = new System.Drawing.Size(521, 435);
            this.ResultsPanel.TabIndex = 1;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.TestIncorrectBtn);
            this.BottomPanel.Controls.Add(this.TryAgainBtn);
            this.BottomPanel.Controls.Add(this.ExitBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(0, 495);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(4);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(521, 66);
            this.BottomPanel.TabIndex = 2;
            // 
            // TestIncorrectBtn
            // 
            this.TestIncorrectBtn.BackColor = System.Drawing.Color.LightGray;
            this.TestIncorrectBtn.FlatAppearance.BorderSize = 0;
            this.TestIncorrectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestIncorrectBtn.Location = new System.Drawing.Point(13, 10);
            this.TestIncorrectBtn.Margin = new System.Windows.Forms.Padding(4);
            this.TestIncorrectBtn.Name = "TestIncorrectBtn";
            this.TestIncorrectBtn.Size = new System.Drawing.Size(177, 38);
            this.TestIncorrectBtn.TabIndex = 2;
            this.TestIncorrectBtn.Text = "Test Incorrect Answers";
            this.TestIncorrectBtn.UseVisualStyleBackColor = false;
            this.TestIncorrectBtn.Click += new System.EventHandler(this.TestIncorrectBtn_Click);
            // 
            // TryAgainBtn
            // 
            this.TryAgainBtn.BackColor = System.Drawing.Color.LightGray;
            this.TryAgainBtn.FlatAppearance.BorderSize = 0;
            this.TryAgainBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TryAgainBtn.Location = new System.Drawing.Point(269, 10);
            this.TryAgainBtn.Margin = new System.Windows.Forms.Padding(4);
            this.TryAgainBtn.Name = "TryAgainBtn";
            this.TryAgainBtn.Size = new System.Drawing.Size(112, 38);
            this.TryAgainBtn.TabIndex = 3;
            this.TryAgainBtn.Text = "Try again";
            this.TryAgainBtn.UseVisualStyleBackColor = false;
            this.TryAgainBtn.Click += new System.EventHandler(this.TryAgainBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.LightGray;
            this.ExitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Location = new System.Drawing.Point(389, 10);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(112, 38);
            this.ExitBtn.TabIndex = 4;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ExitBtn;
            this.ClientSize = new System.Drawing.Size(521, 561);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.ResultsPanel);
            this.Controls.Add(this.ScoreLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Results";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ScoreLbl;
        private System.Windows.Forms.Panel ResultsPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button TryAgainBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button TestIncorrectBtn;
    }
}