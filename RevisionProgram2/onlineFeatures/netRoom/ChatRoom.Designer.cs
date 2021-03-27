
namespace RevisionProgram2.netRoom
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
            this.ChatTxt = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.MessageLbl = new System.Windows.Forms.Label();
            this.SendTxt = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MembersLbl);
            this.panel1.Controls.Add(this.MembersTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 490);
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
            // ChatTxt
            // 
            this.ChatTxt.Location = new System.Drawing.Point(181, 7);
            this.ChatTxt.Multiline = true;
            this.ChatTxt.Name = "ChatTxt";
            this.ChatTxt.ReadOnly = true;
            this.ChatTxt.Size = new System.Drawing.Size(370, 436);
            this.ChatTxt.TabIndex = 1;
            // 
            // SendBtn
            // 
            this.SendBtn.Enabled = false;
            this.SendBtn.Location = new System.Drawing.Point(476, 449);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(75, 30);
            this.SendBtn.TabIndex = 2;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // MessageLbl
            // 
            this.MessageLbl.AutoSize = true;
            this.MessageLbl.Location = new System.Drawing.Point(180, 454);
            this.MessageLbl.Name = "MessageLbl";
            this.MessageLbl.Size = new System.Drawing.Size(64, 17);
            this.MessageLbl.TabIndex = 3;
            this.MessageLbl.Text = "Message:";
            // 
            // SendTxt
            // 
            this.SendTxt.Location = new System.Drawing.Point(250, 451);
            this.SendTxt.Name = "SendTxt";
            this.SendTxt.Size = new System.Drawing.Size(219, 25);
            this.SendTxt.TabIndex = 4;
            this.SendTxt.TextChanged += new System.EventHandler(this.SendTxt_TextChanged);
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 490);
            this.Controls.Add(this.SendTxt);
            this.Controls.Add(this.MessageLbl);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.ChatTxt);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChatRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Room";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label MembersLbl;
        private System.Windows.Forms.Label MembersTitle;
        private System.Windows.Forms.TextBox ChatTxt;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Label MessageLbl;
        private System.Windows.Forms.TextBox SendTxt;
    }
}