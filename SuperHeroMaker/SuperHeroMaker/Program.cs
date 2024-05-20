using System;
using System.Windows.Forms;
// Christian Gonzalez/CST-250/This is a work based upon the Activity 4 Assignment for Programming in C# II, Grand Canyon University
namespace SuperHeroMaker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
