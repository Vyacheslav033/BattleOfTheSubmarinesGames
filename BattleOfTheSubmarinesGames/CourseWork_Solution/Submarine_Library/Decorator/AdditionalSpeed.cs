using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Увеличение скорость лодки.
    /// </summary>
    public class AdditionalSpeed : SubmarineDecorator
    {
        private static float boostSpeed = 5;

        public AdditionalSpeed(Submarine submarine) : base(submarine) { }

        public override float Speed
        {
            get => base.Speed + boostSpeed;
        }
    }
}
