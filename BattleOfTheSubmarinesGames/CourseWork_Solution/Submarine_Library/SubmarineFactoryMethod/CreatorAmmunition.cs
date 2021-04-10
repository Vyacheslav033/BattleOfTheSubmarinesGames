using System;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public class CreatorAmmunition : Creator
    {
        public override Bonus CreateBonus()
        {
            //return new AmmunitionBonus();
            return null;
        }
    }
}
