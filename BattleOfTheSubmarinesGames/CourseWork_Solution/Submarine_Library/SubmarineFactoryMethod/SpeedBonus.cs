using Submarine_Library.SubmarineDecorator;
using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public class SpeedBonus : Bonus
    {
        public override void Activation(ref Submarine submarine)
        {
            submarine = new Speed(submarine);
        }
    }
}
