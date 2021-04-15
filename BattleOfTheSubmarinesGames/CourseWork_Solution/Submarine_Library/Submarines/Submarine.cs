using System;
using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.Submarines
{
    /// <summary>
    /// Подводная лодка.
    /// </summary>
    public class Submarine : GameObject, IMovable
    {
        /// <summary>
        /// Количество жизней.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// Скорость лодки.
        /// </summary>
        public float Speed { get; protected set; }

        /// <summary>
        /// Броня.
        /// </summary>
        public int Armor { get; protected set; }

        /// <summary>
        /// Торпеды.
        /// </summary>
        public int SumAmmunition { get; protected set; }

        /// <summary>
        /// Инициализатор лодки.
        /// </summary>
        /// <param name="sumAmmunition"> Количество снаряжения. </param>
        public Submarine(int sumAmmunition)
        {
            if (sumAmmunition <= 0)
            {
                throw new ArgumentException("Снаряды не выбраны", nameof(sumAmmunition));
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
        /// Получение урона.
        /// </summary>
        /// <param name="lifeDamage"> Урон по здоровью. </param>
        /// <param name="armorDamage"> Урон по броне. </param>
        public void TakingDamage(int lifeDamage, int armorDamage)
        {
            Health -= lifeDamage;
            Armor -= armorDamage;
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

            Transform.Position = new OpenTK.Vector2(x, y);
        }
    }
}
