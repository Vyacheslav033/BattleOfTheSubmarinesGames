using System;

namespace Submarine_Library
{
    public class SpeedBonus : Bonus
    {
        public override Submarine Activation(Submarine submarine)
        {
            return new AdditionalSpeed(submarine);
        }
    }
}
