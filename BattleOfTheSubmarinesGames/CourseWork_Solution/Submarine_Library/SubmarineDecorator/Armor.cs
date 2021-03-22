using System;
using Submarine_Library.Torpedos;
using System.Collections.Generic;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Увеличение брони лодки.
    /// </summary>
    public class Armor : SubmarineDecorator
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="ammunition"> Торпеды. </param>
        /// <param name="submarine"> Декорируемая лодка. </param>
        /// <param name="boostArmor"> Увеличение брони. </param>
        public Armor(List<Torpedo> ammunition, Submarine submarine, int boostArmor) : base( ammunition, submarine )
        {
            if (boostArmor < 0)
            {
                throw new ArgumentException("Нельзя понижать броню лодки", nameof(boostArmor));
            }

            Armor += boostArmor;
        }
    }
}
