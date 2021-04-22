using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Увеличение скорость лодки.
    /// </summary>
    public class AdditionalSpeed : SubmarineDecorator
    {
        static int boostSpeed = 2;
        public AdditionalSpeed(Submarine submarine) : base(submarine)
        {
            Speed += boostSpeed;
        }
    }
}
