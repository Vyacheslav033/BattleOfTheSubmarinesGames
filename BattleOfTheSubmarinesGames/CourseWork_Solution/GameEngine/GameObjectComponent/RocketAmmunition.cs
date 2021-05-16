using System.Collections.Generic;

namespace GameEngine
{
    /// <summary>
    /// Снаряжение подводной лодки.
    /// </summary>
    public class RocketAmmunition
    {
        private Dictionary<RocketType, int> ammunition;

        /// <summary>
        /// Инициализатор снаряжения.
        /// </summary>
        public RocketAmmunition()
        {
            ammunition = new Dictionary<RocketType, int>();
        }

        /// <summary>
        /// Количестов ракет заданного типа.
        /// </summary>
        public int GetRockets(RocketType rocketType)
        {
            if (ammunition.ContainsKey(rocketType))
            {
                return ammunition[rocketType];
            }

            return 0;
        }

        /// <summary>
        /// Количество всех ракет.
        /// </summary>
        /// <returns> Количество всех ракет. </returns>
        public int Count()
        {
            int count = 0;

            foreach (KeyValuePair<RocketType, int> ammo in ammunition)
            {
                count += ammo.Value;
            }

            return count;
        }

        /// <summary>
        /// Количество типов ракет.
        /// </summary>
        /// <returns> Количество типов ракет. </returns>
        public int TypeRocketCount
        {
            get { return ammunition.Count; }
        }

        /// <summary>
        /// Добвление ракет заданного типа.
        /// </summary>
        /// <param name="rocketType"></param>
        /// <param name="rocketCount"></param>
        public void AddRockets(RocketType rocketType, int rocketCount)
        {
            if (!ammunition.ContainsKey(rocketType))
            {
                ammunition.Add(rocketType, rocketCount);
            }          
        }

        /// <summary>
        /// Изменение ракет заданного типа, (добавить/отнять).
        /// </summary>
        /// <param name="rocketType"></param>
        public void ChangeRockets(RocketType rocketType, int countRockets)
        {
            if (ammunition.ContainsKey(rocketType))
            {
                ammunition[rocketType] += countRockets;
            }   
        }
    }
}
