
namespace RevisionProgram2.dialogs
{
    partial class ProgressForm
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
            this.MessageLbl = new System.Windows.Forms.Label();
            this.TaskProgress = new System.Windows.Forms.ProgressBar();
            this.ProcessWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // MessageLbl
            // 
            this.MessageLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.MessageLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MessageLbl.Location = new System.Drawing.Point(0, 0);
            this.MessageLbl.Name = "MessageLbl";
            this.MessageLbl.Size = new System.Drawing.Size(331, 135);
            this.MessageLbl.TabIndex = 1;
            this.MessageLbl.Text = "Message";
            this.MessageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TaskProgress
            // 
            this.TaskProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TaskProgress.Location = new System.Drawing.Point(0, 135);
            this.TaskProgress.Name = "TaskProgress";
            this.TaskProgress.Size = new System.Drawing.Size(331, 26);
            this.TaskProgress.TabIndex = 2;
            // 
            // ProcessWorker
            // 
            this.ProcessWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ProcessWorker_DoWork);
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 161);
            this.Controls.Add(this.TaskProgress);
            this.Controls.Add(this.MessageLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Progress";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MessageLbl;
        private System.Windows.Forms.ProgressBar TaskProgress;
        private System.ComponentModel.BackgroundWorker ProcessWorker;
    }
}