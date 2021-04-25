using Submarine_Library.Submarines;
using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Пополнение боеприпасов лодки.
    /// </summary>
    public class AdditionalAmmunition : SubmarineDecorator
    {
        static int boostAmmunition = 1;

        public AdditionalAmmunition(Submarine submarine) : base(submarine)
        {
            Ammunition.Ammo[RocketType.FieryRocket] += boostAmmunition;
            Ammunition.Ammo[RocketType.IceRocket] += boostAmmunition;
            Ammunition.Ammo[RocketType.AtomicRocket] += boostAmmunition;
        }  
    }
}
