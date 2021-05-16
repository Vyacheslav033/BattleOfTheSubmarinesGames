using System;

namespace GameEngine
{
    public class CreatorAmmunition : BonusCreator
    {
        public override Bonus CreateBonus()
        {
            return new AmmunitionBonus();
        }
    }
}
