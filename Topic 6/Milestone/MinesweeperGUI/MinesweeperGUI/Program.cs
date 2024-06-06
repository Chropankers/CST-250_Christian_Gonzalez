using System;
using System.Windows.Forms;
// Christian Gonzalez/CST-250/5-20-24 This is original work
namespace MinesweeperGUI
{
    //entry point program
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DifficultyForm());
        }
    }
}
