using System;

namespace Submarine_Library
{
    public class CreatorSpeed : BonusCreator
    {

        public override Bonus CreateBonus()
        {
            return new SpeedBonus();
        }
    }
}
