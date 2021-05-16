using System;

namespace GameEngine
{
    /// <summary>
    /// Увеличение жизней лодки.
    /// </summary>
    public class AdditionalHealth : SubmarineDecorator
    {
        static int boostHealth = 20;

        public AdditionalHealth(Submarine submarine) : base(submarine)
        {
            Health += boostHealth;
        }
    }
}
