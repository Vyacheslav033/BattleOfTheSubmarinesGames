using System;

namespace GameLogic
{
    /// <summary>
    /// Увеличение жизней лодки.
    /// </summary>
    public class AdditionalHealth : SubmarineDecorator
    {
        private static int boostHealth = 20;

        public AdditionalHealth(Submarine submarine) : base(submarine)
        {
            Health += boostHealth;
        }

        /// <summary>
        /// Значение дополнительных жизней, свойство необходимо для тестов.
        /// </summary>
        public int BoostHealth
        {
            get { return boostHealth; }
        }
    }
}
