using System;

namespace GameLogic
{
    public class SpeedBonus : Bonus
    {
        public override Submarine Activation(Submarine submarine)
        {
            return new AdditionalSpeed(submarine);
        }
    }
}
