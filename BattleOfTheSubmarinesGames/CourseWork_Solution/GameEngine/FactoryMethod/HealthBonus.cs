using System;

namespace GameEngine
{
    public class HealthBonus : Bonus
    {
        public override Submarine Activation(Submarine submarine)
        {
            return new AdditionalHealth(submarine);
        }
    }
}
