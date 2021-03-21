using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public class CreatorSpeed : Creator
    {
        public override Bonus FactoryMethod()
        {
            return new SpeedBonus();
        }
    }
}
