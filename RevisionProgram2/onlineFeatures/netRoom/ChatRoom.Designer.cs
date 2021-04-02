
namespace RevisionProgram2.onlineFeatures.netRoom
{
    partial class ChatRoom
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.MembersLbl = new System.Windows.Forms.Label();
            this.MembersTitle = new System.Windows.Forms.Label();
            this.NetworkWorker = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.MessageLbl = new System.Windows.Forms.Label();
            this.SendBtn = new System.Windows.Forms.Button();
            this.SendTxt = new System.Windows.Forms.TextBox();
            this.ChallengeGroup = new System.Windows.Forms.GroupBox();
            this.ChallengeLbl = new System.Windows.Forms.Label();
            this.ChatTxt = new System.Windows.Forms.TextBox();
            this.AcceptBtn = new RevisionProgram2.specialControls.ColourSpecificButton();
            this.DeclineBtn = new RevisionProgram2.specialControls.ColourSpecificButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MessagePanel.SuspendLayout();
            this.ChallengeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MembersLbl);
            this.panel1.Controls.Add(this.MembersTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 461);
            this.panel1.TabIndex = 0;
            // 
            // MembersLbl
            // 
            this.MembersLbl.AutoSize = true;
            this.MembersLbl.Location = new System.Drawing.Point(12, 33);
            this.MembersLbl.Name = "MembersLbl";
            this.MembersLbl.Size = new System.Drawing.Size(64, 17);
            this.MembersLbl.TabIndex = 1;
            this.MembersLbl.Text = "(Nobody)";
            // 
            // MembersTitle
            // 
            this.MembersTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.MembersTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MembersTitle.Location = new System.Drawing.Point(0, 0);
            this.MembersTitle.Name = "MembersTitle";
            this.MembersTitle.Size = new System.Drawing.Size(175, 33);
            this.MembersTitle.TabIndex = 0;
            this.MembersTitle.Text = "Room Members";
            this.MembersTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MessagePanel);
            this.panel2.Controls.Add(this.ChallengeGroup);
            this.panel2.Controls.Add(this.ChatTxt);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(175, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 461);
            this.panel2.TabIndex = 1;
            // 
            // MessagePanel
            // 
            this.MessagePanel.Controls.Add(this.MessageLbl);
            this.MessagePanel.Controls.Add(this.SendBtn);
            this.MessagePanel.Controls.Add(this.SendTxt);
            this.MessagePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MessagePanel.Location = new System.Drawing.Point(0, 412);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Size = new System.Drawing.Size(409, 49);
            this.MessagePanel.TabIndex = 9;
            // 
            // MessageLbl
            // 
            this.MessageLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MessageLbl.AutoSize = true;
            this.MessageLbl.Location = new System.Drawing.Point(8, 14);
            this.MessageLbl.Name = "MessageLbl";
            this.MessageLbl.Size = new System.Drawing.Size(64, 17);
            this.MessageLbl.TabIndex = 3;
            this.MessageLbl.Text = "Message:";
            // 
            // SendBtn
            // 
            this.SendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendBtn.BackColor = System.Drawing.Color.LightGray;
            this.SendBtn.Enabled = false;
            this.SendBtn.FlatAppearance.BorderSize = 0;
            this.SendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendBtn.Location = new System.Drawing.Point(324, 7);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(75, 30);
            this.SendBtn.TabIndex = 2;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = false;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // SendTxt
            // 
            this.SendTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SendTxt.Location = new System.Drawing.Point(78, 11);
            this.SendTxt.Name = "SendTxt";
            this.SendTxt.Size = new System.Drawing.Size(240, 25);
            this.SendTxt.TabIndex = 4;
            this.SendTxt.TextChanged += new System.EventHandler(this.SendTxt_TextChanged);
            this.SendTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SendTxt_KeyDown);
            // 
            // ChallengeGroup
            // 
            this.ChallengeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChallengeGroup.Controls.Add(this.AcceptBtn);
            this.ChallengeGroup.Controls.Add(this.DeclineBtn);
            this.ChallengeGroup.Controls.Add(this.ChallengeLbl);
            this.ChallengeGroup.Location = new System.Drawing.Point(6, 304);
            this.ChallengeGroup.Name = "ChallengeGroup";
            this.ChallengeGroup.Size = new System.Drawing.Size(391, 102);
            this.ChallengeGroup.TabIndex = 8;
            this.ChallengeGroup.TabStop = false;
            this.ChallengeGroup.Text = "Challenge";
            this.ChallengeGroup.Visible = false;
            // 
            // ChallengeLbl
            // 
            this.ChallengeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChallengeLbl.AutoEllipsis = true;
            this.ChallengeLbl.Location = new System.Drawing.Point(7, 25);
            this.ChallengeLbl.Name = "ChallengeLbl";
            this.ChallengeLbl.Size = new System.Drawing.Size(378, 38);
            this.ChallengeLbl.TabIndex = 0;
            this.ChallengeLbl.Text = "(Challenge Text)";
            // 
            // ChatTxt
            // 
            this.ChatTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatTxt.Location = new System.Drawing.Point(6, 7);
            this.ChatTxt.Multiline = true;
            this.ChatTxt.Name = "ChatTxt";
            this.ChatTxt.ReadOnly = true;
            this.ChatTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatTxt.Size = new System.Drawing.Size(391, 399);
            this.ChatTxt.TabIndex = 7;
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AcceptBtn.BackColor = System.Drawing.Color.LightGray;
            this.AcceptBtn.BackColourName = "AcceptBackColour";
            this.AcceptBtn.FlatAppearance.BorderSize = 0;
            this.AcceptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptBtn.ForeColourName = "AcceptForeColour";
            this.AcceptBtn.GlobalBackColour = System.Drawing.Color.Empty;
            this.AcceptBtn.Location = new System.Drawing.Point(229, 66);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(75, 30);
            this.AcceptBtn.TabIndex = 2;
            this.AcceptBtn.Text = "Accept";
            this.AcceptBtn.UseVisualStyleBackColor = false;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // DeclineBtn
            // 
            this.DeclineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeclineBtn.BackColor = System.Drawing.Color.LightGray;
            this.DeclineBtn.BackColourName = "DeclineBackColour";
            this.DeclineBtn.FlatAppearance.BorderSize = 0;
            this.DeclineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeclineBtn.ForeColourName = "DeclineForeColour";
            this.DeclineBtn.GlobalBackColour = System.Drawing.Color.Empty;
            this.DeclineBtn.Location = new System.Drawing.Point(310, 66);
            this.DeclineBtn.Name = "DeclineBtn";
            this.DeclineBtn.Size = new System.Drawing.Size(75, 30);
            this.DeclineBtn.TabIndex = 1;
            this.DeclineBtn.Text = "Decline";
            this.DeclineBtn.UseVisualStyleBackColor = false;
            this.DeclineBtn.Click += new System.EventHandler(this.DeclineBtn_Click);
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "ChatRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Room";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatRoom_FormClosing);
            this.Load += new System.EventHandler(this.ChatRoom_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.MessagePanel.ResumeLayout(false);
            this.MessagePanel.PerformLayout();
            this.ChallengeGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label MembersLbl;
        private System.Windows.Forms.Label MembersTitle;
        private System.ComponentModel.BackgroundWorker NetworkWorker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel MessagePanel;
        private System.Windows.Forms.Label MessageLbl;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox SendTxt;
        private System.Windows.Forms.GroupBox ChallengeGroup;
        private specialControls.ColourSpecificButton AcceptBtn;
        private specialControls.ColourSpecificButton DeclineBtn;
        private System.Windows.Forms.Label ChallengeLbl;
        private System.Windows.Forms.TextBox ChatTxt;
    }
}