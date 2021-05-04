using System;

namespace Submarine_Library
{
    public class ArmorBonus : Bonus
    {
        public override Submarine Activation(Submarine submarine)
        {
            return new AdditionalArmor(submarine);
        }
    }
}
