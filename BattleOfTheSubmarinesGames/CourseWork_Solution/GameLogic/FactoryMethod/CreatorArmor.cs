using System;

namespace GameLogic
{
    public class CreatorArmor : BonusCreator
    {
        public override Bonus CreateBonus()
        {
            return new ArmorBonus();
        }
    }
}
