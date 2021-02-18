namespace RevisionProgram2.revision.assessments.tests
{
    partial class QuestionEditor
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
            this.QuestionLbl = new System.Windows.Forms.Label();
            this.AnswerGroup = new System.Windows.Forms.GroupBox();
            this.CorrectLbl = new System.Windows.Forms.Label();
            this.CorrectCombo = new System.Windows.Forms.ComboBox();
            this.MultipleCheck = new System.Windows.Forms.CheckBox();
            this.AnswerList = new System.Windows.Forms.ListBox();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.QuestionTxt = new RevisionProgram2.specialControls.SpecialTextBox();
            this.AnswerGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuestionLbl
            // 
            this.QuestionLbl.AutoSize = true;
            this.QuestionLbl.Location = new System.Drawing.Point(16, 23);
            this.QuestionLbl.Name = "QuestionLbl";
            this.QuestionLbl.Size = new System.Drawing.Size(71, 20);
            this.QuestionLbl.TabIndex = 0;
            this.QuestionLbl.Text = "Question:";
            // 
            // AnswerGroup
            // 
            this.AnswerGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AnswerGroup.Controls.Add(this.CorrectLbl);
            this.AnswerGroup.Controls.Add(this.CorrectCombo);
            this.AnswerGroup.Controls.Add(this.MultipleCheck);
            this.AnswerGroup.Controls.Add(this.AnswerList);
            this.AnswerGroup.Controls.Add(this.DeleteBtn);
            this.AnswerGroup.Controls.Add(this.EditBtn);
            this.AnswerGroup.Controls.Add(this.AddBtn);
            this.AnswerGroup.Location = new System.Drawing.Point(16, 61);
            this.AnswerGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AnswerGroup.Name = "AnswerGroup";
            this.AnswerGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AnswerGroup.Size = new System.Drawing.Size(283, 292);
            this.AnswerGroup.TabIndex = 2;
            this.AnswerGroup.TabStop = false;
            this.AnswerGroup.Text = "Answers";
            // 
            // CorrectLbl
            // 
            this.CorrectLbl.AutoSize = true;
            this.CorrectLbl.Location = new System.Drawing.Point(8, 292);
            this.CorrectLbl.Name = "CorrectLbl";
            this.CorrectLbl.Size = new System.Drawing.Size(112, 20);
            this.CorrectLbl.TabIndex = 8;
            this.CorrectLbl.Text = "Correct Answer:";
            this.CorrectLbl.Visible = false;
            // 
            // CorrectCombo
            // 
            this.CorrectCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CorrectCombo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CorrectCombo.FormattingEnabled = true;
            this.CorrectCombo.Location = new System.Drawing.Point(134, 288);
            this.CorrectCombo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CorrectCombo.Name = "CorrectCombo";
            this.CorrectCombo.Size = new System.Drawing.Size(138, 28);
            this.CorrectCombo.TabIndex = 9;
            this.CorrectCombo.Visible = false;
            // 
            // MultipleCheck
            // 
            this.MultipleCheck.Location = new System.Drawing.Point(8, 252);
            this.MultipleCheck.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MultipleCheck.Name = "MultipleCheck";
            this.MultipleCheck.Size = new System.Drawing.Size(264, 27);
            this.MultipleCheck.TabIndex = 7;
            this.MultipleCheck.Text = "Multiple Choice";
            this.MultipleCheck.UseVisualStyleBackColor = true;
            this.MultipleCheck.CheckedChanged += new System.EventHandler(this.MultipleCheck_CheckedChanged);
            // 
            // AnswerList
            // 
            this.AnswerList.FormattingEnabled = true;
            this.AnswerList.ItemHeight = 20;
            this.AnswerList.Location = new System.Drawing.Point(8, 32);
            this.AnswerList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AnswerList.Name = "AnswerList";
            this.AnswerList.Size = new System.Drawing.Size(262, 164);
            this.AnswerList.TabIndex = 3;
            this.AnswerList.SelectedIndexChanged += new System.EventHandler(this.AnswerList_SelectedIndexChanged);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.BackColor = System.Drawing.Color.LightGray;
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.FlatAppearance.BorderSize = 0;
            this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBtn.Location = new System.Drawing.Point(190, 208);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(82, 36);
            this.DeleteBtn.TabIndex = 6;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = false;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.BackColor = System.Drawing.Color.LightGray;
            this.EditBtn.Enabled = false;
            this.EditBtn.FlatAppearance.BorderSize = 0;
            this.EditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBtn.Location = new System.Drawing.Point(98, 208);
            this.EditBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(82, 36);
            this.EditBtn.TabIndex = 5;
            this.EditBtn.Text = "Edit";
            this.EditBtn.UseVisualStyleBackColor = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.BackColor = System.Drawing.Color.LightGray;
            this.AddBtn.FlatAppearance.BorderSize = 0;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Location = new System.Drawing.Point(8, 208);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(82, 36);
            this.AddBtn.TabIndex = 4;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = false;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.LightGray;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Location = new System.Drawing.Point(200, 363);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(99, 36);
            this.CancelBtn.TabIndex = 11;
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
            this.OKBtn.Location = new System.Drawing.Point(91, 363);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(99, 36);
            this.OKBtn.TabIndex = 10;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = false;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // QuestionTxt
            // 
            this.QuestionTxt.AllowSpecialCharacters = true;
            this.QuestionTxt.Location = new System.Drawing.Point(99, 19);
            this.QuestionTxt.Name = "QuestionTxt";
            this.QuestionTxt.Size = new System.Drawing.Size(198, 27);
            this.QuestionTxt.TabIndex = 1;
            this.QuestionTxt.TextChanged += new System.EventHandler(this.QuestionTxt_TextChanged);
            // 
            // QuestionEditor
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(315, 417);
            this.Controls.Add(this.QuestionTxt);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.AnswerGroup);
            this.Controls.Add(this.QuestionLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Question Editor";
            this.Load += new System.EventHandler(this.QuestionEditor_Load);
            this.AnswerGroup.ResumeLayout(false);
            this.AnswerGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label QuestionLbl;
        private System.Windows.Forms.GroupBox AnswerGroup;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Label CorrectLbl;
        private System.Windows.Forms.ComboBox CorrectCombo;
        private System.Windows.Forms.CheckBox MultipleCheck;
        private specialControls.SpecialTextBox QuestionTxt;
        private System.Windows.Forms.ListBox AnswerList;
    }
}