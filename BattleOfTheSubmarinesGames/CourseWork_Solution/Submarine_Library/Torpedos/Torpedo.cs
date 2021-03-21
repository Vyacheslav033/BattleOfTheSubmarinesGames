using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submarine_Library.Torpedos
{
    /// <summary>
    /// Торпеда.
    /// </summary>
    public abstract class Torpedo
    {
        /// <summary>
        /// Скорость торпеды.
        /// </summary>
        public double Speed { get; private set; }

        /// <summary>
        /// Урон торпеды.
        /// </summary>
        public int LifeDamage { get; private set; }

        /// <summary>
        /// Бронепробиваемость.
        /// </summary>
        public int ArmorDamage { get; private set; }

        /// <summary>
        /// Скорострельность торпеды.
        /// </summary>
        public double FiringSpeed { get; private set; }

        /// <summary>
        /// Конструктор торпеды.
        /// </summary>
        /// <param name="speed"> Скорость. </param>
        /// <param name="lifeDamage"> Урон. </param>
        /// <param name="armorDamage"> Бронепробиваемость. </param>
        /// <param name="firingSpeed"> Скорострельность. </param>
        public Torpedo(double speed, int lifeDamage, int armorDamage, double firingSpeed)
        {
            Speed = speed;
            LifeDamage = lifeDamage;
            ArmorDamage = armorDamage;
            FiringSpeed = firingSpeed;
        }
    }
}
