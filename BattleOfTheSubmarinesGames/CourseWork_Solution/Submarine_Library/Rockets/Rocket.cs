using OpenTK;
using Submarine_Library.GameObjectComponent;
using Submarine_Library.Interfaces;

namespace Submarine_Library.Rockets
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
        /// Направление ракеты.
        /// </summary>
        public Direction Direction { get; }

        /// <summary>
        /// Инициализатор ракеты.
        /// </summary>
        /// <param name="speed"> Скорость. </param>
        /// <param name="lifeDamage"> Урон по жизням. </param>
        /// <param name="armorDamage"> Урон по броне. </param>
        public Rocket(float speed, int lifeDamage, int armorDamage, Direction direction)
        {          
            Speed = speed;
            LifeDamage = lifeDamage;
            ArmorDamage = armorDamage;
            Direction = direction;
        }

        public void Move(double time)
        {
            float x = Transform.Position.X;
            float y = Transform.Position.Y;

            if (Direction == Direction.Right)
            {
                x += Speed * (float)time;
            }

            if (Direction == Direction.Left)
            {
                x -= Speed * (float)time;
            }

            Transform.Position = new Vector2(x, y);
        }
    }
}
