using Submarine_Library.Torpedos;
using System;
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
        public int Health { get; protected set; }

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
        public int SumAmmunition { get; protected set; }

        /// <summary>
        ///  Конструктор лодки.
        /// </summary>
        public Submarine(int sumAmmunition)
        {
            if (sumAmmunition == 0)
            {
                throw new ArgumentNullException("Снаряды не выбраны", nameof(sumAmmunition));
            }

            Health = 100;
            Speed = 15;
            Armor = 100;
            SumAmmunition = sumAmmunition;
        }

        /// <summary>
        /// Конструктор для декоратора.
        /// </summary>
        /// <param name="submarine"> Лодка. </param>
        protected Submarine(Submarine submarine) : this(submarine.SumAmmunition) { }

        public virtual int GetHealth()
        {
            return Health;
        }

        public virtual double GetSpeed()
        {
            return Speed;
        }

        public virtual int GetArmor()
        {
            return Armor;
        }

        public virtual int GetAmmunition()
        {
            return SumAmmunition;
        }

        /// <summary>
        ///  Получение урона
        /// </summary>
        /// <param name="lifeDamage"></param>
        public void TakingDamage(int lifeDamage, int armorDamage)
        {
            Health += lifeDamage;
            Armor += armorDamage;
        }
    }
}
