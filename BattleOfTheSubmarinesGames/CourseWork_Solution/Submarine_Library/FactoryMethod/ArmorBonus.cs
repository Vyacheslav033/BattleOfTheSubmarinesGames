using Submarine_Library.SubmarineDecorator;
using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public class ArmorBonus : Bonus
    {
        public override Submarine Activation(Submarine submarine)
        {
            return new AdditionalArmor(submarine);
        }
    }
}
