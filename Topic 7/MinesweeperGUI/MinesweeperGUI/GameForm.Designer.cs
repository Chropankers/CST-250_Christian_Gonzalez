namespace MinesweeperGUI
{
    partial class GameForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblStopwatch;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Button btnDebugWin;

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
            this.components = new System.ComponentModel.Container();
            this.lblStopwatch = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.btnDebugWin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStopwatch
            // 
            this.lblStopwatch.BackColor = System.Drawing.Color.Black;
            this.lblStopwatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStopwatch.ForeColor = System.Drawing.Color.Lime;
            this.lblStopwatch.Location = new System.Drawing.Point(12, 9);
            this.lblStopwatch.Name = "lblStopwatch";
            this.lblStopwatch.Size = new System.Drawing.Size(150, 40);
            this.lblStopwatch.TabIndex = 0;
            this.lblStopwatch.Text = "00:00:00";
            this.lblStopwatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.BackColor = System.Drawing.Color.LightPink;
            this.btnPlayAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayAgain.ForeColor = System.Drawing.Color.Black;
            this.btnPlayAgain.Location = new System.Drawing.Point(200, 9);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(150, 40);
            this.btnPlayAgain.TabIndex = 1;
            this.btnPlayAgain.Text = "Play Again";
            this.btnPlayAgain.UseVisualStyleBackColor = false;
            this.btnPlayAgain.Click += new System.EventHandler(this.BtnPlayAgain_Click);
            // 
            // btnDebugWin
            // 
            this.btnDebugWin.BackColor = System.Drawing.Color.LightPink;
            this.btnDebugWin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebugWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebugWin.ForeColor = System.Drawing.Color.Black;
            this.btnDebugWin.Location = new System.Drawing.Point(12, 760);
            this.btnDebugWin.Name = "btnDebugWin";
            this.btnDebugWin.Size = new System.Drawing.Size(75, 23);
            this.btnDebugWin.TabIndex = 2;
            this.btnDebugWin.Text = "Debug Win";
            this.btnDebugWin.UseVisualStyleBackColor = false;
            this.btnDebugWin.Click += new System.EventHandler(this.BtnDebugWin_Click);
            this.btnDebugWin.Visible = true;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.btnDebugWin);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.lblStopwatch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
        }
    }
}
