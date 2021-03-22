using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submarine_Library.Destroyer
{
    /// <summary>
    /// Мина.
    /// </summary>
    public class Mina
    {
        /// <summary>
        /// Урон мины.
        /// </summary>
        public int LifeDamage { get; private set; }

        /// <summary>
        /// Бронепробиваемость.
        /// </summary>
        public int ArmorGamage { get; private set; }

        /// <summary>
        /// Скорость.
        /// </summary>
        public double Speed { get; private set; }

        /// <summary>
        /// Конструктор мины.
        /// </summary>
        public Mina()
        {
            LifeDamage = 15;
            ArmorGamage = 15;
            Speed = 15;
        }
    }
}
