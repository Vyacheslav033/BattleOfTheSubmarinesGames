using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public class CreatorArmor : BonusCreator
    {
        public override Bonus CreateBonus()
        {
            return new ArmorBonus();
        }
    }
}
