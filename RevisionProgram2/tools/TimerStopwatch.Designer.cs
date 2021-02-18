using RevisionProgram2.specialControls;

namespace RevisionProgram2.tools
{
    partial class TimerStopwatch
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
            this.components = new System.ComponentModel.Container();
            this.TypeCombo = new System.Windows.Forms.ComboBox();
            this.TimerMain = new System.Windows.Forms.Timer(this.components);
            this.StartBtn = new System.Windows.Forms.Button();
            this.BackPanel = new RevisionProgram2.tools.TimerBackPanel();
            this.HourLbl = new RevisionProgram2.specialControls.EditableLabel();
            this.Colon2 = new System.Windows.Forms.Label();
            this.SecondLbl = new RevisionProgram2.specialControls.EditableLabel();
            this.MinuteLbl = new RevisionProgram2.specialControls.EditableLabel();
            this.Colon1 = new System.Windows.Forms.Label();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.BackPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TypeCombo
            // 
            this.TypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeCombo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TypeCombo.FormattingEnabled = true;
            this.TypeCombo.Items.AddRange(new object[] {
            "Stopwatch",
            "Timer"});
            this.TypeCombo.Location = new System.Drawing.Point(16, 19);
            this.TypeCombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TypeCombo.Name = "TypeCombo";
            this.TypeCombo.Size = new System.Drawing.Size(198, 28);
            this.TypeCombo.TabIndex = 0;
            this.TypeCombo.SelectedIndexChanged += new System.EventHandler(this.TypeCombo_SelectedIndexChanged);
            // 
            // TimerMain
            // 
            this.TimerMain.Interval = 10;
            this.TimerMain.Tick += new System.EventHandler(this.TimerMain_Tick);
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.Color.LightGray;
            this.StartBtn.FlatAppearance.BorderSize = 0;
            this.StartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartBtn.Location = new System.Drawing.Point(369, 134);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(99, 36);
            this.StartBtn.TabIndex = 7;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // BackPanel
            // 
            this.BackPanel.BackColourName = null;
            this.BackPanel.Controls.Add(this.HourLbl);
            this.BackPanel.Controls.Add(this.Colon2);
            this.BackPanel.Controls.Add(this.SecondLbl);
            this.BackPanel.Controls.Add(this.MinuteLbl);
            this.BackPanel.Controls.Add(this.Colon1);
            this.BackPanel.Location = new System.Drawing.Point(16, 60);
            this.BackPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BackPanel.Name = "BackPanel";
            this.BackPanel.Size = new System.Drawing.Size(454, 65);
            this.BackPanel.TabIndex = 1;
            // 
            // HourLbl
            // 
            this.HourLbl.AutoSize = true;
            this.HourLbl.BackColor = System.Drawing.Color.Transparent;
            this.HourLbl.Font = new System.Drawing.Font("Segoe UI", 36F);
            this.HourLbl.Location = new System.Drawing.Point(12, 0);
            this.HourLbl.Name = "HourLbl";
            this.HourLbl.Size = new System.Drawing.Size(80, 65);
            this.HourLbl.TabIndex = 2;
            this.HourLbl.Text = "00";
            this.HourLbl.TextChanged += new System.EventHandler(this.PartLbl_TextChanged);
            // 
            // Colon2
            // 
            this.Colon2.AutoSize = true;
            this.Colon2.BackColor = System.Drawing.Color.Transparent;
            this.Colon2.Font = new System.Drawing.Font("Segoe UI", 36F);
            this.Colon2.Location = new System.Drawing.Point(288, 0);
            this.Colon2.Name = "Colon2";
            this.Colon2.Size = new System.Drawing.Size(38, 65);
            this.Colon2.TabIndex = 5;
            this.Colon2.Text = ":";
            // 
            // SecondLbl
            // 
            this.SecondLbl.AutoSize = true;
            this.SecondLbl.BackColor = System.Drawing.Color.Transparent;
            this.SecondLbl.Font = new System.Drawing.Font("Segoe UI", 36F);
            this.SecondLbl.Location = new System.Drawing.Point(358, 0);
            this.SecondLbl.Name = "SecondLbl";
            this.SecondLbl.Size = new System.Drawing.Size(80, 65);
            this.SecondLbl.TabIndex = 6;
            this.SecondLbl.Text = "00";
            this.SecondLbl.TextChanged += new System.EventHandler(this.PartLbl_TextChanged);
            // 
            // MinuteLbl
            // 
            this.MinuteLbl.AutoSize = true;
            this.MinuteLbl.BackColor = System.Drawing.Color.Transparent;
            this.MinuteLbl.Font = new System.Drawing.Font("Segoe UI", 36F);
            this.MinuteLbl.Location = new System.Drawing.Point(186, 0);
            this.MinuteLbl.Name = "MinuteLbl";
            this.MinuteLbl.Size = new System.Drawing.Size(80, 65);
            this.MinuteLbl.TabIndex = 4;
            this.MinuteLbl.Text = "00";
            this.MinuteLbl.TextChanged += new System.EventHandler(this.PartLbl_TextChanged);
            // 
            // Colon1
            // 
            this.Colon1.AutoSize = true;
            this.Colon1.BackColor = System.Drawing.Color.Transparent;
            this.Colon1.Font = new System.Drawing.Font("Segoe UI", 36F);
            this.Colon1.Location = new System.Drawing.Point(114, 0);
            this.Colon1.Name = "Colon1";
            this.Colon1.Size = new System.Drawing.Size(38, 65);
            this.Colon1.TabIndex = 3;
            this.Colon1.Text = ":";
            // 
            // ResetBtn
            // 
            this.ResetBtn.BackColor = System.Drawing.Color.LightGray;
            this.ResetBtn.Enabled = false;
            this.ResetBtn.FlatAppearance.BorderSize = 0;
            this.ResetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetBtn.Location = new System.Drawing.Point(264, 134);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(99, 36);
            this.ResetBtn.TabIndex = 8;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = false;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // TimerStopwatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 187);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.BackPanel);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.TypeCombo);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "TimerStopwatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stopwatch/Timer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimerStopwatch_FormClosing);
            this.Load += new System.EventHandler(this.TimerStopwatch_Load);
            this.BackPanel.ResumeLayout(false);
            this.BackPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox TypeCombo;
        //private specialControls.EditableLabel hourLbl;
        private System.Windows.Forms.Label Colon1;
        //private specialControls.EditableLabel minuteLbl;
        private System.Windows.Forms.Label Colon2;
        //private specialControls.EditableLabel secondLbl;
        private System.Windows.Forms.Timer TimerMain;
        private System.Windows.Forms.Button StartBtn;
        private specialControls.EditableLabel HourLbl;
        private specialControls.EditableLabel MinuteLbl;
        private specialControls.EditableLabel SecondLbl;
        private TimerBackPanel BackPanel;
        private System.Windows.Forms.Button ResetBtn;
    }
}