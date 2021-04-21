using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Увеличение брони лодки.
    /// </summary>
    public class AdditionalArmor : SubmarineDecorator
    {
        private static int boostArmor = 5;

        public AdditionalArmor(Submarine submarine) : base( submarine ) { }

        public override int Armor
        {
            get => base.Armor + boostArmor;
        }
    }
}
