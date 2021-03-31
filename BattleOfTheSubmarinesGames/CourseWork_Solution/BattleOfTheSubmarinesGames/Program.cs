using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            MainWindow mainWindow = new MainWindow(800, 600);
            mainWindow.Run(60);
        }
    }
}
