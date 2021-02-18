
namespace RevisionProgram2.revision.assessments.tests
{
    partial class QPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EditBtn = new RevisionProgram2.specialControls.ColourSpecificButton();
            this.AnswersLbl = new RevisionProgram2.specialControls.ColourSpecificLabel();
            this.QuestionLbl = new RevisionProgram2.specialControls.ColourSpecificLabel();
            this.FileContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.DuplicateStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MoveUpStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.MoveDownStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.FileContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditBtn
            // 
            this.EditBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.EditBtn.BackColor = System.Drawing.Color.LightGray;
            this.EditBtn.BackColourName = "ChangeButtonBack";
            this.EditBtn.FlatAppearance.BorderSize = 0;
            this.EditBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBtn.ForeColourName = "ChangeButtonFore";
            this.EditBtn.GlobalBackColour = System.Drawing.Color.Empty;
            this.EditBtn.Location = new System.Drawing.Point(304, 61);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(25, 23);
            this.EditBtn.TabIndex = 2;
            this.EditBtn.Text = "…";
            this.EditBtn.UseVisualStyleBackColor = false;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // AnswersLbl
            // 
            this.AnswersLbl.AutoSize = true;
            this.AnswersLbl.BackColourName = "QuestionBackcolour";
            this.AnswersLbl.ForeColourName = "QuestionForecolour";
            this.AnswersLbl.Location = new System.Drawing.Point(13, 45);
            this.AnswersLbl.MaximumSize = new System.Drawing.Size(244, 0);
            this.AnswersLbl.Name = "AnswersLbl";
            this.AnswersLbl.Size = new System.Drawing.Size(68, 19);
            this.AnswersLbl.TabIndex = 1;
            this.AnswersLbl.Text = "(Answers)";
            // 
            // QuestionLbl
            // 
            this.QuestionLbl.AutoSize = true;
            this.QuestionLbl.BackColourName = "QuestionBackcolour";
            this.QuestionLbl.ForeColourName = "QuestionForecolour";
            this.QuestionLbl.Location = new System.Drawing.Point(13, 10);
            this.QuestionLbl.MaximumSize = new System.Drawing.Size(244, 0);
            this.QuestionLbl.Name = "QuestionLbl";
            this.QuestionLbl.Size = new System.Drawing.Size(73, 19);
            this.QuestionLbl.TabIndex = 0;
            this.QuestionLbl.Text = "(Question)";
            // 
            // FileContext
            // 
            this.FileContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditStrip,
            this.DeleteStrip,
            this.DuplicateStrip,
            this.toolStripSeparator1,
            this.MoveUpStrip,
            this.MoveDownStrip});
            this.FileContext.Name = "FileContext";
            this.FileContext.Size = new System.Drawing.Size(139, 120);
            // 
            // EditStrip
            // 
            this.EditStrip.Name = "EditStrip";
            this.EditStrip.Size = new System.Drawing.Size(138, 22);
            this.EditStrip.Text = "Edit";
            this.EditStrip.Click += new System.EventHandler(this.EditStrip_Click);
            // 
            // DeleteStrip
            // 
            this.DeleteStrip.Name = "DeleteStrip";
            this.DeleteStrip.Size = new System.Drawing.Size(138, 22);
            this.DeleteStrip.Text = "Delete";
            this.DeleteStrip.Click += new System.EventHandler(this.DeleteStrip_Click);
            // 
            // DuplicateStrip
            // 
            this.DuplicateStrip.Name = "DuplicateStrip";
            this.DuplicateStrip.Size = new System.Drawing.Size(138, 22);
            this.DuplicateStrip.Text = "Duplicate";
            this.DuplicateStrip.Click += new System.EventHandler(this.DuplicateStrip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // MoveUpStrip
            // 
            this.MoveUpStrip.Name = "MoveUpStrip";
            this.MoveUpStrip.Size = new System.Drawing.Size(138, 22);
            this.MoveUpStrip.Text = "Move Up";
            this.MoveUpStrip.Click += new System.EventHandler(this.MoveUpStrip_Click);
            // 
            // MoveDownStrip
            // 
            this.MoveDownStrip.Name = "MoveDownStrip";
            this.MoveDownStrip.Size = new System.Drawing.Size(138, 22);
            this.MoveDownStrip.Text = "Move Down";
            this.MoveDownStrip.Click += new System.EventHandler(this.MoveDownStrip_Click);
            // 
            // QPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.AnswersLbl);
            this.Controls.Add(this.QuestionLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QPanel";
            this.Size = new System.Drawing.Size(332, 148);
            this.FileContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private specialControls.ColourSpecificLabel QuestionLbl;
        private specialControls.ColourSpecificLabel AnswersLbl;
        private specialControls.ColourSpecificButton EditBtn;
        private System.Windows.Forms.ContextMenuStrip FileContext;
        private System.Windows.Forms.ToolStripMenuItem EditStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteStrip;
        private System.Windows.Forms.ToolStripMenuItem DuplicateStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MoveUpStrip;
        private System.Windows.Forms.ToolStripMenuItem MoveDownStrip;
    }
}
