using System;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public class CreatorSpeed : Creator
    {
        public override Bonus CreateBonus()
        {
            return null;
            //return new SpeedBonus();
        }
    }
}
