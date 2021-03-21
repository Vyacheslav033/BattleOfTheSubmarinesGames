using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submarine_Library.Torpedos
{
    /// <summary>
    /// Огненная торпеда.
    /// </summary>
    public class FieryTorpedo : Torpedo
    {
        /// <summary>
        /// Конструктор торпеды.
        /// </summary>
        /// <param name="speed"> Скорость. </param>
        /// <param name="lifeDamage"> Урон. </param>
        /// <param name="armorDamage"> Бронепробиваемость. </param>
        /// <param name="firingSpeed"> Скорострельность. </param>
        public FieryTorpedo(double speed, int lifeDamage, int armorDamage, double firingSpeed) : base(speed, lifeDamage, armorDamage, firingSpeed) { }
    }
}
