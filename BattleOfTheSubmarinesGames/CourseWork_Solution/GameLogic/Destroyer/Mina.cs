using System;
using OpenTK;
using GameEngine;

namespace GameLogic
{
    /// <summary>
    /// Мина.
    /// </summary>
    public class Mina : GameObject, IMovable
    {
        private int lifeDamage;

        private int armorDamage;

        private float speed;

        /// <summary>
        /// Инициализатор мины.
        /// </summary>
        public Mina()
        {
            lifeDamage = 30;
            armorDamage = 30;
            speed = 20;
        }

        /// <summary>
        /// Урон по здоровью.
        /// </summary>
        public int LifeDamage
        {
            get { return lifeDamage; }
        }

        /// <summary>
        /// Бронепробиваемость.
        /// </summary>
        public int ArmorDamage
        {
            get { return armorDamage; }
        }

        /// <summary>
        /// Движение мины.
        /// </summary>
        /// <param name="time"> Время. </param>
        public void Move(double time)
        {
            float x = Transform.Position.X;
            float y = Transform.Position.Y;

            y -= (float)(Math.Pow(speed, 2) * time);

            Transform.Position = new Vector2(x, y);
        }
    }
}
