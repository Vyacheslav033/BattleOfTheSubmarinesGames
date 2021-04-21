using OpenTK;
using Submarine_Library.GameObjectComponent;
using Submarine_Library.Interfaces;

namespace Submarine_Library.Destroyer
{
    /// <summary>
    /// Миноносец.
    /// </summary>
    public class Destroyer : GameObject, IMovable
    {
        /// <summary>
        /// Скорость.
        /// </summary>
        public float Speed { get; }

        /// <summary>
        /// Направление.
        /// </summary>
        public Direction Direction { get; }

        public Destroyer(Direction direction)
        {
            Direction = direction;
            Speed = 15;
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
