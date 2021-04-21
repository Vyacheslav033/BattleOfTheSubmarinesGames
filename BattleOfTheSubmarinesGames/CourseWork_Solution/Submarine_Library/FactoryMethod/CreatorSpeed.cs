using System;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public class CreatorSpeed : BonusCreator
    {

        public override Bonus CreateBonus()
        {
            return new SpeedBonus();
        }
    }
}
