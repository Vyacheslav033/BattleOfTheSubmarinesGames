using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.Destroyer
{
    /// <summary>
    /// Миноносец.
    /// </summary>
    public class Destroyer : GameObject
    {
        /// <summary>
        /// Мина.
        /// </summary>
        public Mina Mina { get; private set; }
    }
}
