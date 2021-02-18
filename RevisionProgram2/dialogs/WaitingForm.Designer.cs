namespace RevisionProgram2.dialogs
{
    partial class WaitingForm
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
            this.ProcessWorker = new System.ComponentModel.BackgroundWorker();
            this.MessageLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProcessWorker
            // 
            this.ProcessWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ProcessWorker_DoWork);
            // 
            // MessageLbl
            // 
            this.MessageLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLbl.Location = new System.Drawing.Point(0, 0);
            this.MessageLbl.Name = "MessageLbl";
            this.MessageLbl.Size = new System.Drawing.Size(331, 161);
            this.MessageLbl.TabIndex = 0;
            this.MessageLbl.Text = "Message";
            this.MessageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WaitingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 161);
            this.Controls.Add(this.MessageLbl);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WaitingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Waiting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaitingForm_FormClosing);
            this.Load += new System.EventHandler(this.WaitingForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker ProcessWorker;
        private System.Windows.Forms.Label MessageLbl;
    }
}