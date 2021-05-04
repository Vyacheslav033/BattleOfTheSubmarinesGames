using System;

namespace Submarine_Library
{
    /// <summary>
    /// Увеличение брони лодки.
    /// </summary>
    public class AdditionalArmor : SubmarineDecorator
    {
        static int boostArmor = 20;

        public AdditionalArmor(Submarine submarine) : base( submarine )
        {
            Armor += boostArmor;
        }
    }
}
