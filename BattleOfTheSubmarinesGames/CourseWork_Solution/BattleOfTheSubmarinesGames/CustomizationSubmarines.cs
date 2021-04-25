using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Submarine_Library.Rockets;
using Submarine_Library.GameObjectComponent;
using Submarine_Library.Submarines;

namespace BattleOfTheSubmarinesGames
{
    public partial class CustomizationSubmarines : Form
    {
        Dictionary<RocketType, int> testAmmo = new Dictionary<RocketType, int>();      
        BlueSubmarine submarine;
        RocketAmmunition blueAmmunition;
        RocketAmmunition redAmmunition;
        int submarines = 0;

        public CustomizationSubmarines(int width, int height)
        {
            InitializeComponent();

            testAmmo.Add(RocketType.FieryRocket, (int)FieryRocketSum.Value);
            var ammo = new RocketAmmunition(testAmmo);
            submarine = new BlueSubmarine(ammo);

            Width = width;
            Height = height;
            CangePosition(NameGame, (Width - NameGame.Size.Width) / 2, (Height / 2) - 200 );
            CangePosition(StartGame_Button, (Width - StartGame_Button.Size.Width)  / 2, Height / 2);
            CangePosition(Customization_panel, (Width - Customization_panel.Size.Width)  / 2, (Height - Customization_panel.Size.Width) / 2);
        }

        /// <summary>
        /// Открытие панели с настройкой лодки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGame_Button_Click(object sender, EventArgs e)
        {
            Customization_panel.Visible = true;
            StartGame_Button.Visible = false;
            NameGame.Visible = false;

            var fieryRocket = new FieryRocket(Direction.Up, typeof(Rocket));
            AddRocketPropertys(fieryRocketPanel, fieryRocket);

            var iceRocket = new IceRocket(Direction.Up, typeof(Rocket));
            AddRocketPropertys(iceRocketPanel, iceRocket);

            var atomicRocket = new AtomicRocket(Direction.Up, typeof(Rocket));
            AddRocketPropertys(atomicRocketPanel, atomicRocket);          

            SubmarineAmunitionPanel.Text = $"Выберите {submarine.AmmunitionCount} снарядов";

            FieryRocketSum.Maximum = submarine.AmmunitionCount;
            IceRocketSum.Maximum = submarine.AmmunitionCount;
            AtomicRocketSum.Maximum = submarine.AmmunitionCount;
        }

        /// <summary>
        /// Вывод информации о ракетах.
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="rocket"></param>
        private void AddRocketPropertys(Control panel, Rocket rocket)
        {
            int positionY = 0;

            for (var i = 0; i < 4; i++)
            {
                var label1 = new Label();
                var label = new Label()
                {
                    ForeColor = Color.Black,
                    Width = 300,
                    Font = new Font(label1.Font.FontFamily, 15, label1.Font.Style),
                    Location = new Point(0, positionY)
                };

                switch (i)
                {
                    case 0:
                        label.Text = $"Урон по жизням = {rocket.LifeDamage}";
                        break;
                    case 1:
                        label.Text = $"Урон по броне = {rocket.ArmorDamage}";
                        break;
                    case 2:
                        label.Text = $"Скорость = {rocket.Speed}";
                        break;
                    case 3:
                        label.Text = $"Скорострельность = {rocket.FiringRate}";
                        break;
                    default:
                        break;
                }

                panel.Controls.Add(label);
                positionY += 20;
            }

        }

        /// <summary>
        /// Измненение позиции элементов.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void CangePosition(Control element, int x, int y)
        {
            element.Location = new Point(x, y);
        }

        /// <summary>
        /// Выбор боекоплекта для лодок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquipSubmarinePanel_Click(object sender, EventArgs e)
        {
            var sumAmmunition = FieryRocketSum.Value + IceRocketSum.Value + AtomicRocketSum.Value;

            if (sumAmmunition == submarine.AmmunitionCount)
            {
                Dictionary<RocketType, int> ammo = new Dictionary<RocketType, int>();

                ammo.Add(RocketType.FieryRocket, (int)FieryRocketSum.Value);
                ammo.Add(RocketType.IceRocket, (int)IceRocketSum.Value);
                ammo.Add(RocketType.AtomicRocket, (int)AtomicRocketSum.Value);

                if (submarines == 1)
                {
                    redAmmunition = new RocketAmmunition(ammo);
                    this.Close();
                    var mainWindow = new MainWindow(1920, 1080, blueAmmunition, redAmmunition);
                    mainWindow.Run(60);
                }
                else
                {
                    blueAmmunition = new RocketAmmunition(ammo);

                    SubmarineType.Text = "Снарядите второго игрока";
                    SubmarineType.ForeColor = Color.Red;                 
                }
                submarines++;
            }
        }
    }
}
