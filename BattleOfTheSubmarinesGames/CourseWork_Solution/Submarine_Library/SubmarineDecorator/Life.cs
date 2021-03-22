using System;
using Submarine_Library.Torpedos;
using System.Collections.Generic;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Увеличение жизней лодки.
    /// </summary>
    public class Life : SubmarineDecorator
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="ammunition"> Торпеды. </param>
        /// <param name="submarine"> Декорируемая лодка. </param>
        /// <param name="boostLife"> Увеличение жизней. </param>
        public Life(List<Torpedo> ammunition, Submarine submarine, int boostLife) : base( ammunition, submarine )
        {
            if (boostLife < 0)
            {
                throw new ArgumentException("Нельзя понижать жизни лодки", nameof(boostLife));
            }

            Life += boostLife;
        }
    }
}
