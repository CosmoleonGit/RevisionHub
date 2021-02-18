namespace RevisionProgram2.alerts
{
    partial class ModifyAlert
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
            this.TitleLbl = new System.Windows.Forms.Label();
            this.TitleTxt = new System.Windows.Forms.TextBox();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.MessageTxt = new System.Windows.Forms.TextBox();
            this.MessageLbl = new System.Windows.Forms.Label();
            this.TimeLbl = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(18, 24);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(42, 21);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Title:";
            // 
            // TitleTxt
            // 
            this.TitleTxt.Location = new System.Drawing.Point(109, 20);
            this.TitleTxt.Margin = new System.Windows.Forms.Padding(4);
            this.TitleTxt.Name = "TitleTxt";
            this.TitleTxt.Size = new System.Drawing.Size(232, 29);
            this.TitleTxt.TabIndex = 1;
            this.TitleTxt.TextChanged += new System.EventHandler(this.TitleTxt_TextChanged);
            // 
            // DatePicker
            // 
            this.DatePicker.Location = new System.Drawing.Point(109, 126);
            this.DatePicker.Margin = new System.Windows.Forms.Padding(4);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(232, 29);
            this.DatePicker.TabIndex = 5;
            this.DatePicker.ValueChanged += new System.EventHandler(this.DatePicker_ValueChanged);
            // 
            // MessageTxt
            // 
            this.MessageTxt.Location = new System.Drawing.Point(109, 64);
            this.MessageTxt.Margin = new System.Windows.Forms.Padding(4);
            this.MessageTxt.Name = "MessageTxt";
            this.MessageTxt.Size = new System.Drawing.Size(232, 29);
            this.MessageTxt.TabIndex = 3;
            this.MessageTxt.TextChanged += new System.EventHandler(this.MessageTxt_TextChanged);
            // 
            // MessageLbl
            // 
            this.MessageLbl.AutoSize = true;
            this.MessageLbl.Location = new System.Drawing.Point(18, 70);
            this.MessageLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MessageLbl.Name = "MessageLbl";
            this.MessageLbl.Size = new System.Drawing.Size(74, 21);
            this.MessageLbl.TabIndex = 2;
            this.MessageLbl.Text = "Message:";
            // 
            // TimeLbl
            // 
            this.TimeLbl.AutoSize = true;
            this.TimeLbl.Location = new System.Drawing.Point(18, 130);
            this.TimeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TimeLbl.Name = "TimeLbl";
            this.TimeLbl.Size = new System.Drawing.Size(47, 21);
            this.TimeLbl.TabIndex = 4;
            this.TimeLbl.Text = "Time:";
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.LightGray;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Location = new System.Drawing.Point(230, 188);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(112, 38);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.BackColor = System.Drawing.Color.LightGray;
            this.OKBtn.Enabled = false;
            this.OKBtn.FlatAppearance.BorderSize = 0;
            this.OKBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKBtn.Location = new System.Drawing.Point(109, 188);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(4);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(112, 38);
            this.OKBtn.TabIndex = 6;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = false;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // ModifyAlert
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(361, 244);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.TimeLbl);
            this.Controls.Add(this.MessageTxt);
            this.Controls.Add(this.MessageLbl);
            this.Controls.Add(this.DatePicker);
            this.Controls.Add(this.TitleTxt);
            this.Controls.Add(this.TitleLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyAlert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify Reminder";
            this.Load += new System.EventHandler(this.ModifyAlert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.TextBox TitleTxt;
        private System.Windows.Forms.DateTimePicker DatePicker;
        private System.Windows.Forms.TextBox MessageTxt;
        private System.Windows.Forms.Label MessageLbl;
        private System.Windows.Forms.Label TimeLbl;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
    }
}