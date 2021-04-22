using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineDecorator
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
