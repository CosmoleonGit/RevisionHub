
namespace RevisionProgram2.revision.explorer.panels
{
    partial class ItemPanel
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
            this.NameLink = new System.Windows.Forms.LinkLabel();
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.ChangeBtn = new RevisionProgram2.specialControls.ColourSpecificButton();
            this.EditingIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditingIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // NameLink
            // 
            this.NameLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameLink.AutoEllipsis = true;
            this.NameLink.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLink.Location = new System.Drawing.Point(42, 16);
            this.NameLink.Name = "NameLink";
            this.NameLink.Size = new System.Drawing.Size(272, 17);
            this.NameLink.TabIndex = 4;
            this.NameLink.TabStop = true;
            this.NameLink.Text = "(Item Name)";
            this.NameLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NameLink_LinkClicked);
            // 
            // IconBox
            // 
            this.IconBox.Location = new System.Drawing.Point(4, 9);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(32, 32);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconBox.TabIndex = 3;
            this.IconBox.TabStop = false;
            // 
            // ChangeBtn
            // 
            this.ChangeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeBtn.BackColor = System.Drawing.Color.LightGray;
            this.ChangeBtn.BackColourName = "ChangeButtonBack";
            this.ChangeBtn.FlatAppearance.BorderSize = 0;
            this.ChangeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeBtn.ForeColourName = "ChangeButtonFore";
            this.ChangeBtn.GlobalBackColour = System.Drawing.Color.Empty;
            this.ChangeBtn.Location = new System.Drawing.Point(320, 13);
            this.ChangeBtn.Name = "ChangeBtn";
            this.ChangeBtn.Size = new System.Drawing.Size(25, 23);
            this.ChangeBtn.TabIndex = 5;
            this.ChangeBtn.Text = "…";
            this.ChangeBtn.UseVisualStyleBackColor = false;
            this.ChangeBtn.Click += new System.EventHandler(this.ChangeBtn_Click);
            // 
            // EditingIcon
            // 
            this.EditingIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditingIcon.Image = global::RevisionProgram2.Properties.Resources.Editing;
            this.EditingIcon.Location = new System.Drawing.Point(298, 17);
            this.EditingIcon.Name = "EditingIcon";
            this.EditingIcon.Size = new System.Drawing.Size(16, 16);
            this.EditingIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EditingIcon.TabIndex = 6;
            this.EditingIcon.TabStop = false;
            this.EditingIcon.Visible = false;
            // 
            // ItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.EditingIcon);
            this.Controls.Add(this.ChangeBtn);
            this.Controls.Add(this.NameLink);
            this.Controls.Add(this.IconBox);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ItemPanel";
            this.Size = new System.Drawing.Size(348, 48);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditingIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.LinkLabel NameLink;
        private System.Windows.Forms.PictureBox IconBox;
        private specialControls.ColourSpecificButton ChangeBtn;
        private System.Windows.Forms.PictureBox EditingIcon;
    }
}
