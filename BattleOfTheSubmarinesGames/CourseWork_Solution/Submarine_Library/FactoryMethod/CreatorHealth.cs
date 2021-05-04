using System;

namespace Submarine_Library
{
    public class CreatorHealth : BonusCreator
    {
        public override Bonus CreateBonus()
        {
            return new HealthBonus();
        }
    }
}
