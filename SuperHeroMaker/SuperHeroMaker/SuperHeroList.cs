using System.Collections.Generic;
// Christian Gonzalez/CST-250/This is a work based upon the Activity 4 Assignment for Programming in C# II, Grand Canyon University
namespace SuperHeroMaker
{
    public class SuperHeroList
    {
        public List<SuperHero> Heroes { get; set; }

        public SuperHeroList()
        {
            Heroes = new List<SuperHero>();
        }

        public void AddHero(SuperHero hero)
        {
            Heroes.Add(hero);
        }
    }
}
