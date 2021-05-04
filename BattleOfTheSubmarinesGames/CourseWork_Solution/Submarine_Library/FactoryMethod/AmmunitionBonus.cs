using System;

namespace Submarine_Library
{
    public class AmmunitionBonus : Bonus
    {
        public override Submarine Activation(Submarine submarine)
        {
            return new AdditionalAmmunition(submarine);
        }
    }
}
