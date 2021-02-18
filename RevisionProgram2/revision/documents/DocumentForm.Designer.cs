namespace RevisionProgram2.revision.documents
{
    partial class DocumentForm
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
            this.SaveBtn = new System.Windows.Forms.Button();
            this.ChangeFontBtn = new System.Windows.Forms.Button();
            this.ChangeFontDialog = new System.Windows.Forms.FontDialog();
            this.DocumentTxt = new System.Windows.Forms.RichTextBox();
            this.BulletPointBtn = new System.Windows.Forms.Button();
            this.ColourBtn = new RevisionProgram2.specialControls.ColourButton();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.BackColor = System.Drawing.Color.LightGray;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Location = new System.Drawing.Point(417, 565);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(99, 36);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.BackColor = System.Drawing.Color.LightGray;
            this.SaveBtn.FlatAppearance.BorderSize = 0;
            this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBtn.Location = new System.Drawing.Point(310, 565);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(99, 36);
            this.SaveBtn.TabIndex = 3;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ChangeFontBtn
            // 
            this.ChangeFontBtn.BackColor = System.Drawing.Color.LightGray;
            this.ChangeFontBtn.FlatAppearance.BorderSize = 0;
            this.ChangeFontBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeFontBtn.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeFontBtn.Location = new System.Drawing.Point(58, 12);
            this.ChangeFontBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChangeFontBtn.Name = "ChangeFontBtn";
            this.ChangeFontBtn.Size = new System.Drawing.Size(36, 36);
            this.ChangeFontBtn.TabIndex = 1;
            this.ChangeFontBtn.Text = "A";
            this.ChangeFontBtn.UseVisualStyleBackColor = false;
            this.ChangeFontBtn.Click += new System.EventHandler(this.ChangeFontBtn_Click);
            // 
            // ChangeFontDialog
            // 
            this.ChangeFontDialog.AllowScriptChange = false;
            this.ChangeFontDialog.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeFontDialog.FontMustExist = true;
            // 
            // DocumentTxt
            // 
            this.DocumentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DocumentTxt.BulletIndent = 10;
            this.DocumentTxt.Location = new System.Drawing.Point(16, 55);
            this.DocumentTxt.Name = "DocumentTxt";
            this.DocumentTxt.Size = new System.Drawing.Size(500, 500);
            this.DocumentTxt.TabIndex = 2;
            this.DocumentTxt.Text = "";
            this.DocumentTxt.SelectionChanged += new System.EventHandler(this.DocumentTxt_SelectionChanged);
            this.DocumentTxt.TextChanged += new System.EventHandler(this.DocumentTxt_TextChanged);
            // 
            // BulletPointBtn
            // 
            this.BulletPointBtn.BackColor = System.Drawing.Color.LightGray;
            this.BulletPointBtn.FlatAppearance.BorderSize = 0;
            this.BulletPointBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BulletPointBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BulletPointBtn.Location = new System.Drawing.Point(100, 12);
            this.BulletPointBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BulletPointBtn.Name = "BulletPointBtn";
            this.BulletPointBtn.Size = new System.Drawing.Size(36, 36);
            this.BulletPointBtn.TabIndex = 5;
            this.BulletPointBtn.Text = "•";
            this.BulletPointBtn.UseVisualStyleBackColor = false;
            this.BulletPointBtn.Click += new System.EventHandler(this.BulletPointBtn_Click);
            // 
            // ColourBtn
            // 
            this.ColourBtn.BackColor = System.Drawing.Color.Black;
            this.ColourBtn.FlatAppearance.BorderSize = 3;
            this.ColourBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColourBtn.Location = new System.Drawing.Point(16, 12);
            this.ColourBtn.Name = "ColourBtn";
            this.ColourBtn.Size = new System.Drawing.Size(36, 36);
            this.ColourBtn.TabIndex = 0;
            this.ColourBtn.UseVisualStyleBackColor = false;
            this.ColourBtn.Click += new System.EventHandler(this.ColourBtn_Click);
            // 
            // DocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(534, 619);
            this.Controls.Add(this.BulletPointBtn);
            this.Controls.Add(this.DocumentTxt);
            this.Controls.Add(this.ColourBtn);
            this.Controls.Add(this.ChangeFontBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CancelBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(350, 458);
            this.Name = "DocumentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocumentForm_FormClosing);
            this.Load += new System.EventHandler(this.DocumentForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button ChangeFontBtn;
        private System.Windows.Forms.FontDialog ChangeFontDialog;
        private specialControls.ColourButton ColourBtn;
        private System.Windows.Forms.RichTextBox DocumentTxt;
        private System.Windows.Forms.Button BulletPointBtn;
    }
}