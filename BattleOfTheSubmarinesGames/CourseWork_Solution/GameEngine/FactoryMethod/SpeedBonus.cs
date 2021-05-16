using System;

namespace GameEngine
{
    public class SpeedBonus : Bonus
    {
        public override Submarine Activation(Submarine submarine)
        {
            return new AdditionalSpeed(submarine);
        }
    }
}
