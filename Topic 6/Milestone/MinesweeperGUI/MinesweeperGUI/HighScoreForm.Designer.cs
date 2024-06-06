namespace MinesweeperGUI
{
    partial class HighScoreForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstHighScores;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstHighScores = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstHighScores
            // 
            this.lstHighScores.FormattingEnabled = true;
            this.lstHighScores.ItemHeight = 16;
            this.lstHighScores.Location = new System.Drawing.Point(12, 12);
            this.lstHighScores.Name = "lstHighScores";
            this.lstHighScores.Size = new System.Drawing.Size(260, 180);
            this.lstHighScores.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(197, 198);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // HighScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 233);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstHighScores);
            this.Name = "HighScoreForm";
            this.Text = "High Scores";
            this.Load += new System.EventHandler(this.HighScoreForm_Load);
            this.ResumeLayout(false);
        }
    }
}
