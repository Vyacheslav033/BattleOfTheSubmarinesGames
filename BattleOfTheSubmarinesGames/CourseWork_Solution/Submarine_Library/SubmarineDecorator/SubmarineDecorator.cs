using Submarine_Library.Torpedos;
using System.Collections.Generic;

namespace Submarine_Library.SubmarineDecorator
{
    public abstract class SubmarineDecorator : Submarine
    {
        /// <summary>
        /// Декорируемая лодка.
        /// </summary>
        protected Submarine submarine;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="ammunition"> Торпеды. </param>
        /// <param name="submarine"> Декорируемая лодка. </param>
        public SubmarineDecorator(List<Torpedo> ammunition, Submarine submarine) : base( ammunition )
        {
            this.submarine = submarine;
        }
    }
}
