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
        public double Speed { get; protected set; }

        /// <summary>
        /// Урон торпеды.
        /// </summary>
        public int LifeDamage { get; protected set; }

        /// <summary>
        /// Бронепробиваемость.
        /// </summary>
        public int ArmorDamage { get; protected set; }

        /// <summary>
        /// Конструктор торпеды.
        /// </summary>
        /// <param name="speed"> Скорость. </param>
        /// <param name="lifeDamage"> Урон по жизням. </param>
        /// <param name="armorDamage"> Урон по броне. </param>
        public Torpedo(double speed, int lifeDamage, int armorDamage)
        {
            Speed = speed;
            LifeDamage = lifeDamage;
            ArmorDamage = armorDamage;
        }
    }
}
