using System;

namespace GameLogic
{
    public class CreatorAmmunition : BonusCreator
    {
        public override Bonus CreateBonus()
        {
            return new AmmunitionBonus();
        }
    }
}
