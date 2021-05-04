using System;

namespace Submarine_Library
{
    public class CreatorArmor : BonusCreator
    {
        public override Bonus CreateBonus()
        {
            return new ArmorBonus();
        }
    }
}
