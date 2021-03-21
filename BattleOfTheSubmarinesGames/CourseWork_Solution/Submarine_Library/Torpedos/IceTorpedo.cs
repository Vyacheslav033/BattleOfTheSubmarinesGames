using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submarine_Library.Torpedos
{
    /// <summary>
    /// Ледяная торпеда.
    /// </summary>
    public class IceTorpedo : Torpedo
    {
        /// <summary>
        /// Конструктор торпеды.
        /// </summary>
        /// <param name="speed"> Скорость. </param>
        /// <param name="lifeDamage"> Урон. </param>
        /// <param name="armorDamage"> Бронепробиваемость. </param>
        /// <param name="firingSpeed"> Скорострельность. </param>
        public IceTorpedo(double speed, int lifeDamage, int armorDamage, double firingSpeed) : base(speed, lifeDamage, armorDamage, firingSpeed) { }
    }
}
