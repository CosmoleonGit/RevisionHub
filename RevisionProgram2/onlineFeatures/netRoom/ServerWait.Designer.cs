
namespace RevisionProgram2.onlineFeatures.netRoom
{
    partial class ServerWait
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
            this.ServerWorker = new System.ComponentModel.BackgroundWorker();
            this.MemberList = new System.Windows.Forms.ListBox();
            this.BeginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLbl.Location = new System.Drawing.Point(0, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(284, 28);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Waiting for people to connect...";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerWorker
            // 
            this.ServerWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ServerWorker_DoWork);
            // 
            // MemberList
            // 
            this.MemberList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MemberList.FormattingEnabled = true;
            this.MemberList.ItemHeight = 17;
            this.MemberList.Location = new System.Drawing.Point(12, 31);
            this.MemberList.Name = "MemberList";
            this.MemberList.Size = new System.Drawing.Size(260, 174);
            this.MemberList.TabIndex = 1;
            // 
            // BeginBtn
            // 
            this.BeginBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BeginBtn.BackColor = System.Drawing.Color.LightGray;
            this.BeginBtn.FlatAppearance.BorderSize = 0;
            this.BeginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BeginBtn.Location = new System.Drawing.Point(12, 219);
            this.BeginBtn.Name = "BeginBtn";
            this.BeginBtn.Size = new System.Drawing.Size(260, 30);
            this.BeginBtn.TabIndex = 2;
            this.BeginBtn.Text = "Begin";
            this.BeginBtn.UseVisualStyleBackColor = false;
            this.BeginBtn.Click += new System.EventHandler(this.BeginBtn_Click);
            // 
            // ServerWait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.BeginBtn);
            this.Controls.Add(this.MemberList);
            this.Controls.Add(this.TitleLbl);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ServerWait";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Wait";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerWait_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.ComponentModel.BackgroundWorker ServerWorker;
        private System.Windows.Forms.ListBox MemberList;
        private System.Windows.Forms.Button BeginBtn;
    }
}