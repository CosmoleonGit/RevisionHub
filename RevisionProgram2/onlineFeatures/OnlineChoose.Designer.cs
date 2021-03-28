
namespace RevisionProgram2.folderSync
{
    partial class OnlineChoose
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
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.HostRadio = new System.Windows.Forms.RadioButton();
            this.JoinRadio = new System.Windows.Forms.RadioButton();
            this.IPLbl = new System.Windows.Forms.Label();
            this.PortLbl = new System.Windows.Forms.Label();
            this.IPTxt = new System.Windows.Forms.TextBox();
            this.PortNumeric = new System.Windows.Forms.NumericUpDown();
            this.SettingsGroup = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PortNumeric)).BeginInit();
            this.SettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.LightGray;
            this.ConnectBtn.FlatAppearance.BorderSize = 0;
            this.ConnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectBtn.Location = new System.Drawing.Point(12, 159);
            this.ConnectBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(177, 30);
            this.ConnectBtn.TabIndex = 1;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // HostRadio
            // 
            this.HostRadio.AutoSize = true;
            this.HostRadio.Checked = true;
            this.HostRadio.Location = new System.Drawing.Point(12, 12);
            this.HostRadio.Name = "HostRadio";
            this.HostRadio.Size = new System.Drawing.Size(53, 21);
            this.HostRadio.TabIndex = 2;
            this.HostRadio.TabStop = true;
            this.HostRadio.Text = "Host";
            this.HostRadio.UseVisualStyleBackColor = true;
            this.HostRadio.CheckedChanged += new System.EventHandler(this.HostRadio_CheckedChanged);
            // 
            // JoinRadio
            // 
            this.JoinRadio.AutoSize = true;
            this.JoinRadio.Location = new System.Drawing.Point(12, 39);
            this.JoinRadio.Name = "JoinRadio";
            this.JoinRadio.Size = new System.Drawing.Size(49, 21);
            this.JoinRadio.TabIndex = 3;
            this.JoinRadio.Text = "Join";
            this.JoinRadio.UseVisualStyleBackColor = true;
            this.JoinRadio.CheckedChanged += new System.EventHandler(this.JoinRadio_CheckedChanged);
            // 
            // IPLbl
            // 
            this.IPLbl.AutoSize = true;
            this.IPLbl.Enabled = false;
            this.IPLbl.Location = new System.Drawing.Point(10, 27);
            this.IPLbl.Name = "IPLbl";
            this.IPLbl.Size = new System.Drawing.Size(21, 17);
            this.IPLbl.TabIndex = 4;
            this.IPLbl.Text = "IP:";
            // 
            // PortLbl
            // 
            this.PortLbl.AutoSize = true;
            this.PortLbl.Location = new System.Drawing.Point(10, 57);
            this.PortLbl.Name = "PortLbl";
            this.PortLbl.Size = new System.Drawing.Size(35, 17);
            this.PortLbl.TabIndex = 5;
            this.PortLbl.Text = "Port:";
            // 
            // IPTxt
            // 
            this.IPTxt.Enabled = false;
            this.IPTxt.Location = new System.Drawing.Point(51, 24);
            this.IPTxt.Name = "IPTxt";
            this.IPTxt.Size = new System.Drawing.Size(120, 25);
            this.IPTxt.TabIndex = 6;
            this.IPTxt.TextChanged += new System.EventHandler(this.IPTxt_TextChanged);
            // 
            // PortNumeric
            // 
            this.PortNumeric.Location = new System.Drawing.Point(51, 55);
            this.PortNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PortNumeric.Name = "PortNumeric";
            this.PortNumeric.Size = new System.Drawing.Size(120, 25);
            this.PortNumeric.TabIndex = 7;
            this.PortNumeric.ValueChanged += new System.EventHandler(this.PortNumeric_ValueChanged);
            // 
            // SettingsGroup
            // 
            this.SettingsGroup.Controls.Add(this.IPTxt);
            this.SettingsGroup.Controls.Add(this.PortNumeric);
            this.SettingsGroup.Controls.Add(this.IPLbl);
            this.SettingsGroup.Controls.Add(this.PortLbl);
            this.SettingsGroup.Location = new System.Drawing.Point(12, 66);
            this.SettingsGroup.Name = "SettingsGroup";
            this.SettingsGroup.Size = new System.Drawing.Size(177, 86);
            this.SettingsGroup.TabIndex = 8;
            this.SettingsGroup.TabStop = false;
            this.SettingsGroup.Text = "Settings";
            // 
            // OnlineChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 202);
            this.Controls.Add(this.SettingsGroup);
            this.Controls.Add(this.JoinRadio);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.HostRadio);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OnlineChoose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect";
            this.Load += new System.EventHandler(this.OnlineChoose_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PortNumeric)).EndInit();
            this.SettingsGroup.ResumeLayout(false);
            this.SettingsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.RadioButton HostRadio;
        private System.Windows.Forms.RadioButton JoinRadio;
        private System.Windows.Forms.Label IPLbl;
        private System.Windows.Forms.Label PortLbl;
        private System.Windows.Forms.TextBox IPTxt;
        private System.Windows.Forms.NumericUpDown PortNumeric;
        private System.Windows.Forms.GroupBox SettingsGroup;
    }
}