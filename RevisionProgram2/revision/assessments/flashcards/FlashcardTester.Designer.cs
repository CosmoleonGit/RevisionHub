namespace RevisionProgram2.revision.assessments.flashcards
{
    partial class FlashcardTester
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
            this.LeftBtn = new System.Windows.Forms.Button();
            this.RightBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.CurrentLbl = new System.Windows.Forms.Label();
            this.LeftMostBtn = new System.Windows.Forms.Button();
            this.RightMostBtn = new System.Windows.Forms.Button();
            this.FlashcardBtn = new RevisionProgram2.specialControls.ColourSpecificButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftBtn
            // 
            this.LeftBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LeftBtn.BackColor = System.Drawing.Color.LightGray;
            this.LeftBtn.FlatAppearance.BorderSize = 0;
            this.LeftBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftBtn.Location = new System.Drawing.Point(65, 33);
            this.LeftBtn.Margin = new System.Windows.Forms.Padding(4);
            this.LeftBtn.Name = "LeftBtn";
            this.LeftBtn.Size = new System.Drawing.Size(87, 38);
            this.LeftBtn.TabIndex = 4;
            this.LeftBtn.Text = "<";
            this.LeftBtn.UseVisualStyleBackColor = false;
            this.LeftBtn.Click += new System.EventHandler(this.LeftBtn_Click);
            // 
            // RightBtn
            // 
            this.RightBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RightBtn.BackColor = System.Drawing.Color.LightGray;
            this.RightBtn.FlatAppearance.BorderSize = 0;
            this.RightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightBtn.Location = new System.Drawing.Point(160, 33);
            this.RightBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RightBtn.Name = "RightBtn";
            this.RightBtn.Size = new System.Drawing.Size(87, 38);
            this.RightBtn.TabIndex = 5;
            this.RightBtn.Text = ">";
            this.RightBtn.UseVisualStyleBackColor = false;
            this.RightBtn.Click += new System.EventHandler(this.RightBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.BackColor = System.Drawing.Color.LightGray;
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Location = new System.Drawing.Point(205, 400);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(112, 38);
            this.CloseBtn.TabIndex = 7;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = false;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // CurrentLbl
            // 
            this.CurrentLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentLbl.Location = new System.Drawing.Point(4, 8);
            this.CurrentLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentLbl.Name = "CurrentLbl";
            this.CurrentLbl.Size = new System.Drawing.Size(304, 21);
            this.CurrentLbl.TabIndex = 2;
            this.CurrentLbl.Text = "Card 1 of 1";
            this.CurrentLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LeftMostBtn
            // 
            this.LeftMostBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LeftMostBtn.BackColor = System.Drawing.Color.LightGray;
            this.LeftMostBtn.FlatAppearance.BorderSize = 0;
            this.LeftMostBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftMostBtn.Location = new System.Drawing.Point(9, 33);
            this.LeftMostBtn.Margin = new System.Windows.Forms.Padding(4);
            this.LeftMostBtn.Name = "LeftMostBtn";
            this.LeftMostBtn.Size = new System.Drawing.Size(48, 38);
            this.LeftMostBtn.TabIndex = 3;
            this.LeftMostBtn.Text = "|<<";
            this.LeftMostBtn.UseVisualStyleBackColor = false;
            this.LeftMostBtn.Click += new System.EventHandler(this.LeftMostBtn_Click);
            // 
            // RightMostBtn
            // 
            this.RightMostBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RightMostBtn.BackColor = System.Drawing.Color.LightGray;
            this.RightMostBtn.Enabled = false;
            this.RightMostBtn.FlatAppearance.BorderSize = 0;
            this.RightMostBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightMostBtn.Location = new System.Drawing.Point(255, 33);
            this.RightMostBtn.Margin = new System.Windows.Forms.Padding(4);
            this.RightMostBtn.Name = "RightMostBtn";
            this.RightMostBtn.Size = new System.Drawing.Size(48, 38);
            this.RightMostBtn.TabIndex = 6;
            this.RightMostBtn.Text = ">>|";
            this.RightMostBtn.UseVisualStyleBackColor = false;
            this.RightMostBtn.Click += new System.EventHandler(this.RightMostBtn_Click);
            // 
            // FlashcardBtn
            // 
            this.FlashcardBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlashcardBtn.BackColor = System.Drawing.Color.LightGray;
            this.FlashcardBtn.BackColourName = "CardLeftBack";
            this.FlashcardBtn.FlatAppearance.BorderSize = 0;
            this.FlashcardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlashcardBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FlashcardBtn.ForeColourName = "CardLeftFore";
            this.FlashcardBtn.GlobalBackColour = System.Drawing.Color.Empty;
            this.FlashcardBtn.Location = new System.Drawing.Point(12, 12);
            this.FlashcardBtn.Name = "FlashcardBtn";
            this.FlashcardBtn.Size = new System.Drawing.Size(312, 290);
            this.FlashcardBtn.TabIndex = 1;
            this.FlashcardBtn.Text = "Side 1";
            this.FlashcardBtn.UseVisualStyleBackColor = false;
            this.FlashcardBtn.SizeChanged += new System.EventHandler(this.FlashcardBtn_SizeChanged);
            this.FlashcardBtn.TextChanged += new System.EventHandler(this.FlashcardBtn_TextChanged);
            this.FlashcardBtn.Click += new System.EventHandler(this.FlashcardBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.Controls.Add(this.LeftMostBtn);
            this.panel1.Controls.Add(this.LeftBtn);
            this.panel1.Controls.Add(this.RightMostBtn);
            this.panel1.Controls.Add(this.RightBtn);
            this.panel1.Controls.Add(this.CurrentLbl);
            this.panel1.Location = new System.Drawing.Point(12, 308);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 75);
            this.panel1.TabIndex = 8;
            // 
            // FlashcardTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(336, 458);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FlashcardBtn);
            this.Controls.Add(this.CloseBtn);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(352, 497);
            this.Name = "FlashcardTester";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flashcards";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlashcardTester_FormClosing);
            this.Load += new System.EventHandler(this.FlashcardTester_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FlashcardTester_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FlashcardTester_KeyPress);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button LeftBtn;
        private System.Windows.Forms.Button RightBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Label CurrentLbl;
        private System.Windows.Forms.Button LeftMostBtn;
        private System.Windows.Forms.Button RightMostBtn;
        private specialControls.ColourSpecificButton FlashcardBtn;
        private System.Windows.Forms.Panel panel1;
    }
}