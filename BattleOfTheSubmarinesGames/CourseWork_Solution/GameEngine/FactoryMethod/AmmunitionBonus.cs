using System;

namespace GameEngine
{
    public class AmmunitionBonus : Bonus
    {
        public override Submarine Activation(Submarine submarine)
        {
            return new AdditionalAmmunition(submarine);
        }
    }
}
