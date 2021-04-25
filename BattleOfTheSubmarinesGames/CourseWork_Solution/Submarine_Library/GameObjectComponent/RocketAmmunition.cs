using System;
using System.Collections.Generic;

namespace Submarine_Library.GameObjectComponent
{
    /// <summary>
    /// Снаряжение подводной лодки.
    /// </summary>
    public class RocketAmmunition
    {
        private Dictionary<RocketType, int> ammo;

        /// <summary>
        /// Инициализатор снаряжения.
        /// </summary>
        /// <param name="ammo"></param>
        public RocketAmmunition(Dictionary<RocketType, int> ammo)
        {
            if (ammo == null)
            {
                throw new ArgumentNullException("Снаряжении лодки не может быть пустым!");
            }

            this.ammo = ammo;
        }

        /// <summary>
        /// Боекомплкет ракет.
        /// </summary>
        public Dictionary<RocketType, int> Ammo
        {
            get { return ammo; }
        }

        /// <summary>
        /// Количество боеприпасов.
        /// </summary>
        /// <returns> Количество боеприпасов. </returns>
        public int Count()
        {
            return ammo[RocketType.FieryRocket] + ammo[RocketType.IceRocket] + ammo[RocketType.AtomicRocket];
        }
    }
}
