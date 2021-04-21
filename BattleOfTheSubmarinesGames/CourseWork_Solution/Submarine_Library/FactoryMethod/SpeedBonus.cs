using Submarine_Library.SubmarineDecorator;
using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public class SpeedBonus : Bonus
    {
        public override Submarine Activation(Submarine submarine)
        {
            return new AdditionalSpeed(submarine);
        }
    }
}
