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
        private int boostArmor = 1;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="ammunition"> Торпеды. </param>
        /// <param name="submarine"> Декорируемая лодка. </param>
        /// <param name="boostArmor"> Увеличение брони. </param>
        public Armor(Submarine submarine) : base( submarine )
        {
            //if (boostArmor < 0)
            //{
            //    throw new ArgumentException("Нельзя понижать броню лодки", nameof(boostArmor));
            //}
        }

        public override int GetArmor()
        {
            return base.GetArmor() + boostArmor;
        }
    }
}
