using System;

namespace GameLogic
{
    /// <summary>
    /// Увеличение брони лодки.
    /// </summary>
    public class AdditionalArmor : SubmarineDecorator
    {
        private static int boostArmor = 20;

        public AdditionalArmor(Submarine submarine) : base( submarine )
        {
            Armor += boostArmor;
        }

        /// <summary>
        /// Значение дополнительной брони, свойство необходимо для тестов.
        /// </summary>
        public int BoostArmor
        {
            get { return boostArmor; }
        }
    }
}
