namespace MinesweeperGUI
{
    partial class DifficultyForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RadioButton rbtnEasy;
        private System.Windows.Forms.RadioButton rbtnMedium;
        private System.Windows.Forms.RadioButton rbtnHard;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnShowScores; // Add this line

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
            this.rbtnEasy = new System.Windows.Forms.RadioButton();
            this.rbtnMedium = new System.Windows.Forms.RadioButton();
            this.rbtnHard = new System.Windows.Forms.RadioButton();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnShowScores = new System.Windows.Forms.Button(); // Add this line
            this.SuspendLayout();
            // 
            // rbtnEasy
            // 
            this.rbtnEasy.Location = new System.Drawing.Point(12, 12);
            this.rbtnEasy.Name = "rbtnEasy";
            this.rbtnEasy.Size = new System.Drawing.Size(260, 24);
            this.rbtnEasy.TabIndex = 0;
            this.rbtnEasy.TabStop = true;
            this.rbtnEasy.Text = "Easy";
            this.rbtnEasy.UseVisualStyleBackColor = true;
            // 
            // rbtnMedium
            // 
            this.rbtnMedium.Location = new System.Drawing.Point(12, 42);
            this.rbtnMedium.Name = "rbtnMedium";
            this.rbtnMedium.Size = new System.Drawing.Size(260, 24);
            this.rbtnMedium.TabIndex = 1;
            this.rbtnMedium.TabStop = true;
            this.rbtnMedium.Text = "Medium";
            this.rbtnMedium.UseVisualStyleBackColor = true;
            // 
            // rbtnHard
            // 
            this.rbtnHard.Location = new System.Drawing.Point(12, 72);
            this.rbtnHard.Name = "rbtnHard";
            this.rbtnHard.Size = new System.Drawing.Size(260, 24);
            this.rbtnHard.TabIndex = 2;
            this.rbtnHard.TabStop = true;
            this.rbtnHard.Text = "Hard";
            this.rbtnHard.UseVisualStyleBackColor = true;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(12, 102);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(260, 40);
            this.btnStartGame.TabIndex = 3;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnShowScores
            // 
            this.btnShowScores.Location = new System.Drawing.Point(12, 148); // Adjust location as needed
            this.btnShowScores.Name = "btnShowScores";
            this.btnShowScores.Size = new System.Drawing.Size(260, 40);
            this.btnShowScores.TabIndex = 4;
            this.btnShowScores.Text = "Show High Scores";
            this.btnShowScores.UseVisualStyleBackColor = true;
            this.btnShowScores.Click += new System.EventHandler(this.btnShowScores_Click);
            // 
            // DifficultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 200); // Adjust size as needed
            this.Controls.Add(this.btnShowScores);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.rbtnHard);
            this.Controls.Add(this.rbtnMedium);
            this.Controls.Add(this.rbtnEasy);
            this.Name = "DifficultyForm";
            this.Text = "Select Difficulty";
            this.ResumeLayout(false);
        }
    }
}
