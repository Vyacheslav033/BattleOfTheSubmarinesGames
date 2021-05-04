using System;

namespace Submarine_Library
{
    public class HealthBonus : Bonus
    {
        public override Submarine Activation(Submarine submarine)
        {
            return new AdditionalHealth(submarine);
        }
    }
}
