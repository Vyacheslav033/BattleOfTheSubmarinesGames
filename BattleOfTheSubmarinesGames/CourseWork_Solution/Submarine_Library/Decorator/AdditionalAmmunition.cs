using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Пополнение боеприпасов лодки.
    /// </summary>
    public class AdditionalAmmunition : SubmarineDecorator
    {
        private static int boostAmmunition = 5;

        public AdditionalAmmunition(Submarine submarine) : base(submarine) { }

        public override int Ammunition
        {
            get => base.Ammunition + boostAmmunition;
        }
    }
}
