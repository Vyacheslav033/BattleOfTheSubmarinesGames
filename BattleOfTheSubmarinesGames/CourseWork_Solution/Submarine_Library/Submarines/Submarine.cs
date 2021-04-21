using System;
using OpenTK;
using Submarine_Library.GameObjectComponent;
using Submarine_Library.Interfaces;

namespace Submarine_Library.Submarines
{
    /// <summary>
    /// Подводная лодка.
    /// </summary>
    public class Submarine : GameObject, IMovable
    {
        private int health;
        private int armor;
        private float speed; 
        private int ammunition;

        /// <summary>
        /// Инициализатор лодки.
        /// </summary>
        /// <param name="sumAmmunition"> Количество снаряжения. </param>
        public Submarine()
        {
            health = 100;
            speed = 25;
            armor = 100;
            ammunition = 10;
        }
        
        /// <summary>
        /// Количество жизней.
        /// </summary>
        public virtual int Health
        {
            get { return health; }
        }

        /// <summary>
        /// Запас брони.
        /// </summary>
        public virtual int Armor
        {
            get { return armor; }
        }

        /// <summary>
        /// Скорость.
        /// </summary>
        public virtual float Speed
        {
            get { return speed; }
        }

        /// <summary>
        /// Количество ракет.
        /// </summary>
        public virtual int Ammunition
        {
            get { return ammunition; }
        }

        /// <summary>
        /// Получение урона.
        /// </summary>
        /// <param name="lifeDamage"> Урон по здоровью. </param>
        /// <param name="armorDamage"> Урон по броне. </param>
        private void TakingDamage(int lifeDamage, int armorDamage)
        {
            health -= lifeDamage;
            armor -= armorDamage;
        }

        public void Move(Direction direction, double time)
        {
            float x = Transform.Position.X;
            float y = Transform.Position.Y;

            switch (direction)
            {
                case Direction.Up:
                    y += Speed * (float)time;
                    break;

                case Direction.Down:
                    y -= Speed * (float)time;
                    break;

                case Direction.Left:
                    x -= Speed * (float)time;
                    break;

                case Direction.Right:
                    x += Speed * (float)time;
                    break;

                default:
                    break;
            }

            Transform.Position = new Vector2(x, y);
        }

        /// <summary>
        /// Вывод характеристик лодки.
        /// </summary>
        /// <returns> Характеристика лодки. </returns>
        public override string ToString()
        {
            return $"Жизни: {Health} | Броня: {Armor} | Скорость: {Speed} | Снаряды: {Ammunition}";
        }
    }
}
