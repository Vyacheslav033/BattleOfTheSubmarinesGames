using System;
using Submarine_Library.Torpedos;
using System.Collections.Generic;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Увеличение скорость лодки.
    /// </summary>
    public class Speed : SubmarineDecorator
    {
        private double boostSpeed = 1;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="ammunition"> Торпеды. </param>
        /// <param name="submarine"> Декорируемая лодка. </param>
        /// <param name="boostSpeed"> Увеличение скорости. </param>
        public Speed(Submarine submarine) : base(submarine)
        {
            //if (boostSpeed < 0)
            //{
            //    throw new ArgumentException("Нельзя понижать скорость лодки", nameof(boostSpeed));
            //}
        }

        public override double GetSpeed()
        {
            return base.GetSpeed() + boostSpeed;
        }
    }
}
