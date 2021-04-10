﻿using OpenTK;
using Submarine_Library.SubmarineDecorator;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public class AmmunitionBonus : Bonus
    {
        public override void Activation(ref Submarine submarine)
        {
            submarine = new Ammunition(submarine);
        }
    }
}
