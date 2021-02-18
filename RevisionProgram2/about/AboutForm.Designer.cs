namespace RevisionProgram2.about
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.VersionLbl = new System.Windows.Forms.Label();
            this.DYLbl = new System.Windows.Forms.Label();
            this.TimerMain = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LinkInfoLbl = new System.Windows.Forms.Label();
            this.GitLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // IconBox
            // 
            this.IconBox.Location = new System.Drawing.Point(16, 19);
            this.IconBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(64, 64);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconBox.TabIndex = 0;
            this.IconBox.TabStop = false;
            this.IconBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IconBox_MouseDown);
            this.IconBox.MouseLeave += new System.EventHandler(this.IconBox_MouseLeave);
            this.IconBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.IconBox_MouseUp);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.TitleLbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.TitleLbl.Location = new System.Drawing.Point(86, 19);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(101, 20);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Revision Hub";
            // 
            // VersionLbl
            // 
            this.VersionLbl.AutoSize = true;
            this.VersionLbl.BackColor = System.Drawing.Color.Transparent;
            this.VersionLbl.Location = new System.Drawing.Point(86, 57);
            this.VersionLbl.Name = "VersionLbl";
            this.VersionLbl.Size = new System.Drawing.Size(64, 20);
            this.VersionLbl.TabIndex = 1;
            this.VersionLbl.Text = "Version: ";
            // 
            // DYLbl
            // 
            this.DYLbl.AutoSize = true;
            this.DYLbl.BackColor = System.Drawing.Color.Transparent;
            this.DYLbl.Location = new System.Drawing.Point(86, 97);
            this.DYLbl.Name = "DYLbl";
            this.DYLbl.Size = new System.Drawing.Size(120, 20);
            this.DYLbl.TabIndex = 2;
            this.DYLbl.Text = "Years: 2020-2021";
            // 
            // TimerMain
            // 
            this.TimerMain.Interval = 1;
            this.TimerMain.Tick += new System.EventHandler(this.TimerMain_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RevisionProgram2.Properties.Resources.Bee;
            this.pictureBox1.Location = new System.Drawing.Point(383, 261);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // LinkInfoLbl
            // 
            this.LinkInfoLbl.AutoSize = true;
            this.LinkInfoLbl.Location = new System.Drawing.Point(86, 137);
            this.LinkInfoLbl.Name = "LinkInfoLbl";
            this.LinkInfoLbl.Size = new System.Drawing.Size(358, 20);
            this.LinkInfoLbl.TabIndex = 4;
            this.LinkInfoLbl.Text = "Releases, pack zips and source code can be found at:";
            // 
            // GitLink
            // 
            this.GitLink.AutoSize = true;
            this.GitLink.Location = new System.Drawing.Point(86, 157);
            this.GitLink.Name = "GitLink";
            this.GitLink.Size = new System.Drawing.Size(321, 20);
            this.GitLink.TabIndex = 5;
            this.GitLink.TabStop = true;
            this.GitLink.Text = "https://github.com/CosmoleonGit/RevisionHub";
            this.GitLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitLink_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 377);
            this.Controls.Add(this.IconBox);
            this.Controls.Add(this.GitLink);
            this.Controls.Add(this.LinkInfoLbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DYLbl);
            this.Controls.Add(this.VersionLbl);
            this.Controls.Add(this.TitleLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Padding = new System.Windows.Forms.Padding(11, 13, 11, 13);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Revision Hub";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox IconBox;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Label VersionLbl;
        private System.Windows.Forms.Label DYLbl;
        private System.Windows.Forms.Timer TimerMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LinkInfoLbl;
        private System.Windows.Forms.LinkLabel GitLink;
    }
}
