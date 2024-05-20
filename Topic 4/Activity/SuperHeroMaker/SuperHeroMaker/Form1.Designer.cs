namespace SuperHeroMaker
{
    // Christian Gonzalez/CST-250/This is a work based upon the Activity 4 Assignment for Programming in C# II, Grand Canyon University
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox nameTextBox;
        private CheckBox flyingCheckBox;
        private ListBox abilityListBox;
        private TrackBar speedTrackBar, staminaTrackBar, strengthTrackBar, darkSideTrackBar;
        private Label speedLabel, staminaLabel, strengthLabel, darkSideLabel;
        private Button submitButton, nextButton, submitColorButton;
        private TextBox capeColorTextBox;
        private DateTimePicker birthdatePicker;
        private PictureBox capeColorPictureBox;
        private ColorDialog colorDialog;

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
            nameTextBox = new TextBox();
            flyingCheckBox = new CheckBox();
            abilityListBox = new ListBox();
            speedTrackBar = new TrackBar();
            staminaTrackBar = new TrackBar();
            strengthTrackBar = new TrackBar();
            darkSideTrackBar = new TrackBar();
            speedLabel = new Label();
            staminaLabel = new Label();
            strengthLabel = new Label();
            darkSideLabel = new Label();
            submitButton = new Button();
            nextButton = new Button();
            capeColorTextBox = new TextBox();
            submitColorButton = new Button();
            birthdatePicker = new DateTimePicker();
            capeColorPictureBox = new PictureBox();
            colorDialog = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)speedTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)staminaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)strengthTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)darkSideTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)capeColorPictureBox).BeginInit();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(20, 20);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(200, 27);
            nameTextBox.TabIndex = 0;
            // 
            // flyingCheckBox
            // 
            flyingCheckBox.Location = new Point(20, 50);
            flyingCheckBox.Name = "flyingCheckBox";
            flyingCheckBox.Size = new Size(104, 24);
            flyingCheckBox.TabIndex = 1;
            flyingCheckBox.Text = "Can Fly";
            // 
            // abilityListBox
            // 
            abilityListBox.ItemHeight = 20;
            abilityListBox.Items.AddRange(new object[] { "Super Strength", "Invisibility", "Telepathy" });
            abilityListBox.Location = new Point(20, 80);
            abilityListBox.Name = "abilityListBox";
            abilityListBox.Size = new Size(200, 84);
            abilityListBox.TabIndex = 2;
            // 
            // speedTrackBar
            // 
            speedTrackBar.Location = new Point(20, 200);
            speedTrackBar.Maximum = 100;
            speedTrackBar.Name = "speedTrackBar";
            speedTrackBar.Size = new Size(104, 56);
            speedTrackBar.TabIndex = 3;
            speedTrackBar.Scroll += SpeedTrackBar_Scroll;
            // 
            // staminaTrackBar
            // 
            staminaTrackBar.Location = new Point(20, 240);
            staminaTrackBar.Maximum = 100;
            staminaTrackBar.Name = "staminaTrackBar";
            staminaTrackBar.Size = new Size(104, 56);
            staminaTrackBar.TabIndex = 4;
            staminaTrackBar.Scroll += StaminaTrackBar_Scroll;
            // 
            // strengthTrackBar
            // 
            strengthTrackBar.Location = new Point(20, 280);
            strengthTrackBar.Maximum = 100;
            strengthTrackBar.Name = "strengthTrackBar";
            strengthTrackBar.Size = new Size(104, 56);
            strengthTrackBar.TabIndex = 5;
            strengthTrackBar.Scroll += StrengthTrackBar_Scroll;
            // 
            // darkSideTrackBar
            // 
            darkSideTrackBar.Location = new Point(20, 320);
            darkSideTrackBar.Minimum = 1;
            darkSideTrackBar.Name = "darkSideTrackBar";
            darkSideTrackBar.Size = new Size(104, 56);
            darkSideTrackBar.TabIndex = 9;
            darkSideTrackBar.Value = 1;
            darkSideTrackBar.Scroll += DarkSideTrackBar_Scroll;
            // 
            // speedLabel
            // 
            speedLabel.Location = new Point(250, 200);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new Size(100, 23);
            speedLabel.TabIndex = 6;
            speedLabel.Text = "Speed: 0";
            // 
            // staminaLabel
            // 
            staminaLabel.Location = new Point(250, 240);
            staminaLabel.Name = "staminaLabel";
            staminaLabel.Size = new Size(100, 23);
            staminaLabel.TabIndex = 7;
            staminaLabel.Text = "Stamina: 0";
            // 
            // strengthLabel
            // 
            strengthLabel.Location = new Point(250, 280);
            strengthLabel.Name = "strengthLabel";
            strengthLabel.Size = new Size(100, 23);
            strengthLabel.TabIndex = 8;
            strengthLabel.Text = "Strength: 0";
            // 
            // darkSideLabel
            // 
            darkSideLabel.Location = new Point(250, 320);
            darkSideLabel.Name = "darkSideLabel";
            darkSideLabel.Size = new Size(100, 23);
            darkSideLabel.TabIndex = 10;
            darkSideLabel.Text = "Dark Side Propensity: 1";
            // 
            // submitButton
            // 
            submitButton.Location = new Point(20, 522);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(75, 66);
            submitButton.TabIndex = 15;
            submitButton.Text = "Submit Hero";
            submitButton.Click += SubmitButton_Click;
            // 
            // nextButton
            // 
            nextButton.Location = new Point(120, 522);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(75, 66);
            nextButton.TabIndex = 16;
            nextButton.Text = "Next";
            nextButton.Click += NextButton_Click;
            // 
            // capeColorTextBox
            // 
            capeColorTextBox.Location = new Point(20, 422);
            capeColorTextBox.Name = "capeColorTextBox";
            capeColorTextBox.Size = new Size(200, 27);
            capeColorTextBox.TabIndex = 12;
            // 
            // submitColorButton
            // 
            submitColorButton.Location = new Point(240, 402);
            submitColorButton.Name = "submitColorButton";
            submitColorButton.Size = new Size(75, 66);
            submitColorButton.TabIndex = 13;
            submitColorButton.Text = "Choose Color";
            submitColorButton.Click += SubmitColorButton_Click;
            // 
            // birthdatePicker
            // 
            birthdatePicker.Location = new Point(20, 382);
            birthdatePicker.Name = "birthdatePicker";
            birthdatePicker.Size = new Size(200, 27);
            birthdatePicker.TabIndex = 11;
            // 
            // capeColorPictureBox
            // 
            capeColorPictureBox.BorderStyle = BorderStyle.FixedSingle;
            capeColorPictureBox.Location = new Point(20, 462);
            capeColorPictureBox.Name = "capeColorPictureBox";
            capeColorPictureBox.Size = new Size(200, 50);
            capeColorPictureBox.TabIndex = 14;
            capeColorPictureBox.TabStop = false;
            // 
            // Form1
            // 
            ClientSize = new Size(400, 600);
            Controls.Add(nameTextBox);
            Controls.Add(flyingCheckBox);
            Controls.Add(abilityListBox);
            Controls.Add(speedTrackBar);
            Controls.Add(staminaTrackBar);
            Controls.Add(strengthTrackBar);
            Controls.Add(speedLabel);
            Controls.Add(staminaLabel);
            Controls.Add(strengthLabel);
            Controls.Add(darkSideTrackBar);
            Controls.Add(darkSideLabel);
            Controls.Add(birthdatePicker);
            Controls.Add(capeColorTextBox);
            Controls.Add(submitColorButton);
            Controls.Add(capeColorPictureBox);
            Controls.Add(submitButton);
            Controls.Add(nextButton);
            Name = "Form1";
            Text = "Hero Maker";
            ((System.ComponentModel.ISupportInitialize)speedTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)staminaTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)strengthTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)darkSideTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)capeColorPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
