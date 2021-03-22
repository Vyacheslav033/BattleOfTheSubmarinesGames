using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submarine_Library.Torpedos
{
    /// <summary>
    /// Атомная торпеда.
    /// </summary>
    public class AtomicTorpedo : Torpedo
    {
        /// <summary>
        /// Конструктор торпеды.
        /// </summary>       
        public AtomicTorpedo()
        {
            Speed = 10;
            LifeDamage = 25;
            ArmorDamage = 5;
        }
    }
}
