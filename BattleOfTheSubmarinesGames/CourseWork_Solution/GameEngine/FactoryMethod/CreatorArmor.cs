using System;

namespace GameEngine
{
    public class CreatorArmor : BonusCreator
    {
        public override Bonus CreateBonus()
        {
            return new ArmorBonus();
        }
    }
}
