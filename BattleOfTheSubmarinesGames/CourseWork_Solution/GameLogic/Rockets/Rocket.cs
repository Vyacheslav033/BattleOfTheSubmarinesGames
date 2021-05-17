using System;
using OpenTK;
using GameEngine;

namespace GameLogic
{
    /// <summary>
    /// Ракета.
    /// </summary>
    public abstract class Rocket : GameObject, IMovable
    {
        /// <summary>
        /// Скорость.
        /// </summary>
        public float Speed { get; }

        /// <summary>
        /// Урон.
        /// </summary>
        public int LifeDamage { get; }

        /// <summary>
        /// Бронепробиваемость.
        /// </summary>
        public int ArmorDamage { get; }

        /// <summary>
        /// Скорострельность.
        /// </summary>
        public int FiringRate { get; }

        /// <summary>
        /// Направление ракеты.
        /// </summary>
        public Direction Direction { get; }

        /// <summary>
        /// Хозяин ракеты.
        /// </summary>
        public Type Owner { get; }

        /// <summary>
        /// Инициализатор ракеты.
        /// </summary>
        /// <param name="speed"> Скорость. </param>
        /// <param name="lifeDamage"> Урон по жизням. </param>
        /// <param name="armorDamage"> Бронепробиваемость. </param>
        /// <param name="firingRate"> Скорострельность </param>
        /// <param name="direction"> Направление. </param>
        /// <param name="owner"> Тип стреляющей лодки. </param>
        public Rocket(float speed, int lifeDamage, int armorDamage, int firingRate, Direction direction, Type owner)
        {          
            Speed = speed;
            LifeDamage = lifeDamage;
            ArmorDamage = armorDamage;
            FiringRate = firingRate;
            Direction = direction;
            Owner = owner;       
        }

        /// <summary>
        /// Движение ракеты.
        /// </summary>
        /// <param name="time"> Время. </param>
        public void Move(double time)
        {
            float x = Transform.Position.X;
            float y = Transform.Position.Y;

            if (Direction == Direction.Right)
            {
                x += (float)(Math.Pow(Speed, 2) * time);
            }

            if (Direction == Direction.Left)
            {
                x -= (float)(Math.Pow(Speed, 2) * time);
            }

            Transform.Position = new Vector2(x, y);
        }
    }
}
