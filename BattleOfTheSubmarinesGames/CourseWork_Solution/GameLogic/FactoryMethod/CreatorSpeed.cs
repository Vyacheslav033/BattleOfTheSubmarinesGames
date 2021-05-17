using System;

namespace GameLogic
{
    public class CreatorSpeed : BonusCreator
    {

        public override Bonus CreateBonus()
        {
            return new SpeedBonus();
        }
    }
}
