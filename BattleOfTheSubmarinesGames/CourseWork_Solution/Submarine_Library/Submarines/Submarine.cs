using Submarine_Library.Torpedos;
using System.Collections.Generic;

namespace Submarine_Library
{
    /// <summary>
    /// Подводная лодка.
    /// </summary>
    public abstract class Submarine
    {
        /// <summary>
        /// Количество жизней.
        /// </summary>
        public int Life { get; private set; }

        /// <summary>
        /// Скорость лодки.
        /// </summary>
        public double Speed { get; private set; }

        /// <summary>
        /// Броня.
        /// </summary>
        public int Armor { get; private set; }

        /// <summary>
        /// Торпеды.
        /// </summary>
        public List<Torpedo> Ammunition { get; private set; }

        /// <summary>
        ///  Конструктор лодки.
        /// </summary>
        /// <param name="life"> Жизни. </param>
        /// <param name="speed"> Скорость. </param>
        /// <param name="armor"> Броня. </param>
        /// <param name="ammunition"> Торпеды. </param>
        public Submarine(int life, double speed, int armor, List<Torpedo> ammunition)
        {
            Life = life;
            Speed = speed;
            Armor = armor;
            Ammunition = ammunition;
        }
    }
}
