using System;

namespace GameEngine
{
    public class CreatorHealth : BonusCreator
    {
        public override Bonus CreateBonus()
        {
            return new HealthBonus();
        }
    }
}
