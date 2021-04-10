using System;
using Submarine_Library.OpenTK_Graphics;

namespace BattleOfTheSubmarinesGames
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MainWindow mainWindow = new MainWindow(1200, 600);
            mainWindow.Run(60);
        }
    }
}
