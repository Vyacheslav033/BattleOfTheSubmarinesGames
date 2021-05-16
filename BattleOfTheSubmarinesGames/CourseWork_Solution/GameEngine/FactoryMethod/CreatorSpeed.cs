using System;

namespace GameEngine
{
    public class CreatorSpeed : BonusCreator
    {

        public override Bonus CreateBonus()
        {
            return new SpeedBonus();
        }
    }
}
