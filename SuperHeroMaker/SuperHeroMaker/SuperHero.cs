namespace SuperHeroMaker
{
    // Christian Gonzalez/CST-250/This is a work based upon the Activity 4 Assignment for Programming in C# II, Grand Canyon University
    public class SuperHero
    {
        public string Name { get; set; }
        public bool IsFlying { get; set; }
        public string Ability { get; set; }
        public int Speed { get; set; }
        public int Stamina { get; set; }
        public int Strength { get; set; }
        public DateTime Birthdate { get; set; }
        public int DarkSidePropensity { get; set; }
        public string CapeColor { get; set; }
        public string ImagePath { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
