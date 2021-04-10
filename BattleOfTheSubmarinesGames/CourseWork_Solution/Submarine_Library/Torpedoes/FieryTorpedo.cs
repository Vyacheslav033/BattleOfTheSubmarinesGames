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
        public FieryTorpedo()
        {
            Speed = 20;
            LifeDamage = 15;
            ArmorDamage = 10;
        }
    }
}
