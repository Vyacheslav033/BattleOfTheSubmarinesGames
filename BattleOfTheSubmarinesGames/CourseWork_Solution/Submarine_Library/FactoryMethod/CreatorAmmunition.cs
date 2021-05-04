using System;

namespace Submarine_Library
{
    public class CreatorAmmunition : BonusCreator
    {
        public override Bonus CreateBonus()
        {
            return new AmmunitionBonus();
        }
    }
}
