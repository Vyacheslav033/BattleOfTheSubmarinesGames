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
        public int Life { get; protected set; }

        /// <summary>
        /// Скорость лодки.
        /// </summary>
        public double Speed { get; protected set; }

        /// <summary>
        /// Броня.
        /// </summary>
        public int Armor { get; protected set; }

        /// <summary>
        /// Торпеды.
        /// </summary>
        public List<Torpedo> Ammunition { get; protected set; }

        /// <summary>
        ///  Конструктор лодки.
        /// </summary>
        /// <param name="ammunition"> Торпеды. </param>
        public Submarine(List<Torpedo> ammunition)
        {
            Life = 100;
            Speed = 15;
            Armor = 100;
            Ammunition = ammunition;
        }

        /// <summary>
        ///  Получение урона
        /// </summary>
        /// <param name="lifeDamage"></param>
        public void TakingDamage(int lifeDamage, int armorDamage)
        {
            Life += lifeDamage;
            Armor += armorDamage;
        }
    }
}
