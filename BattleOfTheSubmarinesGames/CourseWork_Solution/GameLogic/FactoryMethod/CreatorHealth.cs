using System;

namespace GameLogic
{
    public class CreatorHealth : BonusCreator
    {
        public override Bonus CreateBonus()
        {
            return new HealthBonus();
        }
    }
}
