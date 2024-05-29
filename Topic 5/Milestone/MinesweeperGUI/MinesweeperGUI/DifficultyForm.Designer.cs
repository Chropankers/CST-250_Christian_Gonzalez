// Christian Gonzalez/CST-250/5-20-24 This is original work
namespace MinesweeperGUI
{
    partial class DifficultyForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RadioButton rbtnEasy;
        private System.Windows.Forms.RadioButton rbtnMedium;
        private System.Windows.Forms.RadioButton rbtnHard;
        private System.Windows.Forms.Button btnStartGame;

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
            this.SuspendLayout();
            // 
            // rbtnEasy
            // 
            this.rbtnEasy.AutoSize = true;
            this.rbtnEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnEasy.Location = new System.Drawing.Point(12, 12);
            this.rbtnEasy.Name = "rbtnEasy";
            this.rbtnEasy.Size = new System.Drawing.Size(80, 29);
            this.rbtnEasy.TabIndex = 0;
            this.rbtnEasy.TabStop = true;
            this.rbtnEasy.Text = "Easy";
            this.rbtnEasy.UseVisualStyleBackColor = true;
            // 
            // rbtnMedium
            // 
            this.rbtnMedium.AutoSize = true;
            this.rbtnMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnMedium.Location = new System.Drawing.Point(12, 47);
            this.rbtnMedium.Name = "rbtnMedium";
            this.rbtnMedium.Size = new System.Drawing.Size(108, 29);
            this.rbtnMedium.TabIndex = 1;
            this.rbtnMedium.TabStop = true;
            this.rbtnMedium.Text = "Medium";
            this.rbtnMedium.UseVisualStyleBackColor = true;
            // 
            // rbtnHard
            // 
            this.rbtnHard.AutoSize = true;
            this.rbtnHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHard.Location = new System.Drawing.Point(12, 82);
            this.rbtnHard.Name = "rbtnHard";
            this.rbtnHard.Size = new System.Drawing.Size(78, 29);
            this.rbtnHard.TabIndex = 2;
            this.rbtnHard.TabStop = true;
            this.rbtnHard.Text = "Hard";
            this.rbtnHard.UseVisualStyleBackColor = true;
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.LightGray;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(12, 124);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(260, 50);
            this.btnStartGame.TabIndex = 3;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // DifficultyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(284, 186);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.rbtnHard);
            this.Controls.Add(this.rbtnMedium);
            this.Controls.Add(this.rbtnEasy);
            this.Name = "DifficultyForm";
            this.Text = "Select Difficulty";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
