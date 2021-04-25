using OpenTK;
using Submarine_Library.GameObjectComponent;
using Submarine_Library.Interfaces;

namespace Submarine_Library.Destroyer
{
    /// <summary>
    /// Мина.
    /// </summary>
    public class Mina : GameObject, IMovable
    {
        /// <summary>
        /// Урон мины.
        /// </summary>
        public int LifeDamage { get; }

        /// <summary>
        /// Бронепробиваемость.
        /// </summary>
        public int ArmorDamage { get; }

        /// <summary>
        /// Скорость.
        /// </summary>
        public float Speed { get; }

        /// <summary>
        /// Инициализатор мины.
        /// </summary>
        public Mina()
        {
            LifeDamage = 20;
            ArmorDamage = 20;
            Speed = 20;
        }
        public void Move(double time)
        {
            float x = Transform.Position.X;
            float y = Transform.Position.Y;

            y -= Speed * (float)time;

            Transform.Position = new Vector2(x, y);
        }
    }
}
