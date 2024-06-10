namespace MinesweeperGUI
{
    partial class HighScoreForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstHighScores;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClearScores;

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
            this.btnClearScores = new System.Windows.Forms.Button();
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
            // btnClearScores
            // 
            this.btnClearScores.Location = new System.Drawing.Point(12, 198);
            this.btnClearScores.Name = "btnClearScores";
            this.btnClearScores.Size = new System.Drawing.Size(120, 23);
            this.btnClearScores.TabIndex = 2;
            this.btnClearScores.Text = "Clear Scores";
            this.btnClearScores.UseVisualStyleBackColor = true;
            this.btnClearScores.Click += new System.EventHandler(this.BtnClearScores_Click);
            // 
            // HighScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(284, 233);
            this.Controls.Add(this.btnClearScores);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstHighScores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HighScoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Scores";
            this.Load += new System.EventHandler(this.HighScoreForm_Load);
            this.ResumeLayout(false);
        }
    }
}
