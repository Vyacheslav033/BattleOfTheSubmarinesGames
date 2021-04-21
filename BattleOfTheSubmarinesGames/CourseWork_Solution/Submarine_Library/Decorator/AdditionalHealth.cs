using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Увеличение жизней лодки.
    /// </summary>
    public class AdditionalHealth : SubmarineDecorator
    {
        private static int boostLife = 5;

        public AdditionalHealth(Submarine submarine) : base(submarine) { }

        public override int Health
        {
            get => base.Health + boostLife;
        }
    }
}
