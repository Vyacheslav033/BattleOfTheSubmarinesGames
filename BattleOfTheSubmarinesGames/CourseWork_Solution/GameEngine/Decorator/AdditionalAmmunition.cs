using System;

namespace GameEngine
{
    /// <summary>
    /// Пополнение боеприпасов лодки.
    /// </summary>
    public class AdditionalAmmunition : SubmarineDecorator
    {
        private static int boostAmmunition = 1;

        public AdditionalAmmunition(Submarine submarine) : base(submarine)
        {
            Ammunition.ChangeRockets(RocketType.FieryRocket, boostAmmunition);
            Ammunition.ChangeRockets(RocketType.IceRocket, boostAmmunition);
            Ammunition.ChangeRockets(RocketType.AtomicRocket, boostAmmunition);
        }

        /// <summary>
        /// Значение дополнительных боеприпасов, свойство необходимо для тестов.
        /// </summary>
        public int BoostAmmunition
        {
            get { return boostAmmunition * Ammunition.TypeRocketCount; }
        }
    }
}
