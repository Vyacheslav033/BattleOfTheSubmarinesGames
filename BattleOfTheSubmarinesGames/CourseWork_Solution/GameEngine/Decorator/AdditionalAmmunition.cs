using System;

namespace GameEngine
{
    /// <summary>
    /// Пополнение боеприпасов лодки.
    /// </summary>
    public class AdditionalAmmunition : SubmarineDecorator
    {
        static int boostAmmunition = 1;

        public AdditionalAmmunition(Submarine submarine) : base(submarine)
        {
            Ammunition.ChangeRockets(RocketType.FieryRocket, boostAmmunition);
            Ammunition.ChangeRockets(RocketType.IceRocket, boostAmmunition);
            Ammunition.ChangeRockets(RocketType.AtomicRocket, boostAmmunition);
        }  
    }
}
