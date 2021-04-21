using System;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public class CreatorAmmunition : BonusCreator
    {
        public override Bonus CreateBonus()
        {
            return new AmmunitionBonus();
        }
    }
}
