using System;

namespace GameLogic
{
    /// <summary>
    /// Увеличение скорость лодки.
    /// </summary>
    public class AdditionalSpeed : SubmarineDecorator
    {
        private static int boostSpeed = 2;

        public AdditionalSpeed(Submarine submarine) : base(submarine)
        {
            Speed += boostSpeed;
        }

        /// <summary>
        /// Значение дополнительной скорости, свойство необходимо для тестов.
        /// </summary>
        public int BoostSpeed
        {
            get { return boostSpeed; }
        }
    }
}
