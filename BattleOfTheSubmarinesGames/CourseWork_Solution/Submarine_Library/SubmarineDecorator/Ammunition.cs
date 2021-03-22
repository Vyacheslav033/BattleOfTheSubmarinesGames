using System;
using Submarine_Library.Torpedos;
using System.Collections.Generic;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Пополнение боеприпасов лодки.
    /// </summary>
    public class Ammunition : SubmarineDecorator
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="ammunition"> Торпеды. </param>
        /// <param name="submarine"> Декорируемая лодка. </param>
        public Ammunition(List<Torpedo> ammunition, Submarine submarine) : base( ammunition, submarine ) { }
    }
}
