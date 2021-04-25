using System;
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
            //var mainWindow = new MainWindow(1920, 1080);
            //mainWindow.Run(60);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CustomizationSubmarines(1920, 1080));
        }
    }
}
