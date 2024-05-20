using System;
using System.Windows.Forms;
// Christian Gonzalez/CST-250/This is a work based upon the Activity 4 Assignment for Programming in C# II, Grand Canyon University
namespace SuperHeroMaker
{
    public partial class Form2 : Form
    {
        private SuperHeroList heroList;

        public Form2(SuperHeroList heroes)
        {
            heroList = heroes;
            InitializeComponent();
            LoadHeroes();
        }

        private void LoadHeroes()
        {
            listBox1.Items.Clear();
            foreach (var hero in heroList.Heroes)
            {
                listBox1.Items.Add(hero);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                SuperHero selectedHero = (SuperHero)listBox1.SelectedItem;
                summaryTextBox.Text = $"Name: {selectedHero.Name}\n" +
                                      $"Flying: {selectedHero.IsFlying}\n" +
                                      $"Ability: {selectedHero.Ability}\n" +
                                      $"Speed: {selectedHero.Speed}\n" +
                                      $"Stamina: {selectedHero.Stamina}\n" +
                                      $"Strength: {selectedHero.Strength}\n" +
                                      $"Birthdate: {selectedHero.Birthdate.ToShortDateString()}\n" +
                                      $"Cape Color: {selectedHero.CapeColor}";
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
