using System;
using System.Drawing;
using System.Windows.Forms;

// Christian Gonzalez/CST-250/This is a work based upon the Activity 4 Assignment for Programming in C# II, Grand Canyon University with inspiration from the following: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.colordialog?view=windowsdesktop-8.0
namespace SuperHeroMaker
{
    public partial class Form1 : Form
    {
        private SuperHeroList heroList;

        public Form1()
        {
            InitializeComponent();
            heroList = new SuperHeroList();
        }

        private void SpeedTrackBar_Scroll(object sender, EventArgs e)
        {
            int total = speedTrackBar.Value + staminaTrackBar.Value + strengthTrackBar.Value;
            if (total > 100)
            {
                MessageBox.Show("The total of speed, stamina, and strength cannot exceed 100.");
                speedTrackBar.Value = 100 - staminaTrackBar.Value - strengthTrackBar.Value;
            }
            speedLabel.Text = $"Speed: {speedTrackBar.Value}";
        }

        private void StaminaTrackBar_Scroll(object sender, EventArgs e)
        {
            int total = speedTrackBar.Value + staminaTrackBar.Value + strengthTrackBar.Value;
            if (total > 100)
            {
                MessageBox.Show("The total of speed, stamina, and strength cannot exceed 100.");
                staminaTrackBar.Value = 100 - speedTrackBar.Value - strengthTrackBar.Value;
            }
            staminaLabel.Text = $"Stamina: {staminaTrackBar.Value}";
        }

        private void StrengthTrackBar_Scroll(object sender, EventArgs e)
        {
            int total = speedTrackBar.Value + staminaTrackBar.Value + strengthTrackBar.Value;
            if (total > 100)
            {
                MessageBox.Show("The total of speed, stamina, and strength cannot exceed 100.");
                strengthTrackBar.Value = 100 - speedTrackBar.Value - staminaTrackBar.Value;
            }
            strengthLabel.Text = $"Strength: {strengthTrackBar.Value}";
        }

        private void DarkSideTrackBar_Scroll(object sender, EventArgs e)
        {
            darkSideLabel.Text = $"Dark Side Propensity: {darkSideTrackBar.Value}";
        }

        private void SubmitColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                capeColorPictureBox.BackColor = colorDialog.Color;
                capeColorTextBox.Text = ColorTranslator.ToHtml(colorDialog.Color);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            SuperHero hero = new SuperHero
            {
                Name = nameTextBox.Text,
                IsFlying = flyingCheckBox.Checked,
                Ability = abilityListBox.SelectedItem?.ToString(),
                Speed = speedTrackBar.Value,
                Stamina = staminaTrackBar.Value,
                Strength = strengthTrackBar.Value,
                Birthdate = birthdatePicker.Value,
                DarkSidePropensity = darkSideTrackBar.Value,
                CapeColor = capeColorTextBox.Text,
            };

            heroList.AddHero(hero);

            // Clear the form for the next entry
            nameTextBox.Clear();
            flyingCheckBox.Checked = false;
            abilityListBox.ClearSelected();
            speedTrackBar.Value = 0;
            staminaTrackBar.Value = 0;
            strengthTrackBar.Value = 0;
            darkSideTrackBar.Value = 1;
            darkSideLabel.Text = $"Dark Side Propensity: 1";
            birthdatePicker.Value = DateTime.Now;
            capeColorTextBox.Clear();
            capeColorPictureBox.BackColor = Color.Transparent;
            speedLabel.Text = "Speed: 0";
            staminaLabel.Text = "Stamina: 0";
            strengthLabel.Text = "Strength: 0";
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(heroList);
            form2.Show();
            this.Hide();
        }
    }
}
