using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Submarine_Library.Rockets;
using Submarine_Library.GameObjectComponent;

namespace BattleOfTheSubmarinesGames
{
    public partial class CustomizationSubmarines : Form
    {
        public CustomizationSubmarines(int width, int height)
        {
            InitializeComponent();
            Width = width;
            Height = height;
            CangePosition(StartGame_Button, (Width - StartGame_Button.Size.Width)  / 2, Height / 2);
            CangePosition(Customization_panel, (Width - Customization_panel.Size.Width)  / 2, (Height - Customization_panel.Size.Width) / 2);
           
        }

        private void StartGame_Button_Click(object sender, EventArgs e)
        {
            Customization_panel.Visible = true;
            StartGame_Button.Visible = false;

            var fieryRocket = new FieryRocket(Direction.Up, typeof(Rocket));
            AddRocketPropertys(fieryRocketPanel, fieryRocket);

            var iceRocket = new IceRocket(Direction.Up, typeof(Rocket));
            AddRocketPropertys(iceRocketPanel, iceRocket);

            var atomicRocket = new AtomicRocket(Direction.Up, typeof(Rocket));
            AddRocketPropertys(atomicRocketPanel, atomicRocket);



        }



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

        
    }
}
