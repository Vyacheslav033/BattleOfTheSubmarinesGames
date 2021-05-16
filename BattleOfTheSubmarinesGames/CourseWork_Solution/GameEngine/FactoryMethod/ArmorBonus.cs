using System;

namespace GameEngine
{
    public class ArmorBonus : Bonus
    {
        public override Submarine Activation(Submarine submarine)
        {
            return new AdditionalArmor(submarine);
        }
    }
}
