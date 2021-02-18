
namespace RevisionProgram2.revision.assessments.tests
{
    partial class TestSettings
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
            this.SortGroup = new System.Windows.Forms.GroupBox();
            this.SortShuffleRadio = new System.Windows.Forms.RadioButton();
            this.SortReverseRadio = new System.Windows.Forms.RadioButton();
            this.SortNormalRadio = new System.Windows.Forms.RadioButton();
            this.SkipBox = new System.Windows.Forms.CheckBox();
            this.FlashcardsBtn = new System.Windows.Forms.Button();
            this.CsvBtn = new System.Windows.Forms.Button();
            this.SortGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // SortGroup
            // 
            this.SortGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SortGroup.Controls.Add(this.SortShuffleRadio);
            this.SortGroup.Controls.Add(this.SortReverseRadio);
            this.SortGroup.Controls.Add(this.SortNormalRadio);
            this.SortGroup.Location = new System.Drawing.Point(3, 4);
            this.SortGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SortGroup.Name = "SortGroup";
            this.SortGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SortGroup.Size = new System.Drawing.Size(136, 107);
            this.SortGroup.TabIndex = 1;
            this.SortGroup.TabStop = false;
            this.SortGroup.Text = "Sort";
            // 
            // SortShuffleRadio
            // 
            this.SortShuffleRadio.AutoSize = true;
            this.SortShuffleRadio.Location = new System.Drawing.Point(6, 79);
            this.SortShuffleRadio.Name = "SortShuffleRadio";
            this.SortShuffleRadio.Size = new System.Drawing.Size(65, 21);
            this.SortShuffleRadio.TabIndex = 3;
            this.SortShuffleRadio.TabStop = true;
            this.SortShuffleRadio.Text = "Shuffle";
            this.SortShuffleRadio.UseVisualStyleBackColor = true;
            // 
            // SortReverseRadio
            // 
            this.SortReverseRadio.AutoSize = true;
            this.SortReverseRadio.Location = new System.Drawing.Point(6, 52);
            this.SortReverseRadio.Name = "SortReverseRadio";
            this.SortReverseRadio.Size = new System.Drawing.Size(72, 21);
            this.SortReverseRadio.TabIndex = 2;
            this.SortReverseRadio.TabStop = true;
            this.SortReverseRadio.Text = "Reverse";
            this.SortReverseRadio.UseVisualStyleBackColor = true;
            // 
            // SortNormalRadio
            // 
            this.SortNormalRadio.AutoSize = true;
            this.SortNormalRadio.Location = new System.Drawing.Point(6, 25);
            this.SortNormalRadio.Name = "SortNormalRadio";
            this.SortNormalRadio.Size = new System.Drawing.Size(70, 21);
            this.SortNormalRadio.TabIndex = 1;
            this.SortNormalRadio.TabStop = true;
            this.SortNormalRadio.Text = "Normal";
            this.SortNormalRadio.UseVisualStyleBackColor = true;
            // 
            // SkipBox
            // 
            this.SkipBox.AutoSize = true;
            this.SkipBox.Location = new System.Drawing.Point(9, 118);
            this.SkipBox.Name = "SkipBox";
            this.SkipBox.Size = new System.Drawing.Size(77, 21);
            this.SkipBox.TabIndex = 2;
            this.SkipBox.Text = "Can Skip";
            this.SkipBox.UseVisualStyleBackColor = true;
            // 
            // FlashcardsBtn
            // 
            this.FlashcardsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlashcardsBtn.BackColor = System.Drawing.Color.LightGray;
            this.FlashcardsBtn.FlatAppearance.BorderSize = 0;
            this.FlashcardsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlashcardsBtn.Location = new System.Drawing.Point(3, 145);
            this.FlashcardsBtn.Name = "FlashcardsBtn";
            this.FlashcardsBtn.Size = new System.Drawing.Size(136, 31);
            this.FlashcardsBtn.TabIndex = 6;
            this.FlashcardsBtn.Text = "Revise As Flashcards";
            this.FlashcardsBtn.UseVisualStyleBackColor = false;
            this.FlashcardsBtn.Click += new System.EventHandler(this.FlashcardsBtn_Click);
            // 
            // CsvBtn
            // 
            this.CsvBtn.BackColor = System.Drawing.Color.LightGray;
            this.CsvBtn.FlatAppearance.BorderSize = 0;
            this.CsvBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CsvBtn.Location = new System.Drawing.Point(3, 182);
            this.CsvBtn.Name = "CsvBtn";
            this.CsvBtn.Size = new System.Drawing.Size(136, 31);
            this.CsvBtn.TabIndex = 7;
            this.CsvBtn.Text = "Save As CSV";
            this.CsvBtn.UseVisualStyleBackColor = false;
            this.CsvBtn.Click += new System.EventHandler(this.CsvBtn_Click);
            // 
            // TestSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CsvBtn);
            this.Controls.Add(this.FlashcardsBtn);
            this.Controls.Add(this.SkipBox);
            this.Controls.Add(this.SortGroup);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TestSettings";
            this.Size = new System.Drawing.Size(142, 216);
            this.Load += new System.EventHandler(this.TestSettings_Load);
            this.SortGroup.ResumeLayout(false);
            this.SortGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SortGroup;
        private System.Windows.Forms.RadioButton SortShuffleRadio;
        private System.Windows.Forms.RadioButton SortReverseRadio;
        private System.Windows.Forms.RadioButton SortNormalRadio;
        private System.Windows.Forms.CheckBox SkipBox;
        private System.Windows.Forms.Button FlashcardsBtn;
        private System.Windows.Forms.Button CsvBtn;
    }
}
