using System;
using OpenTK;

namespace Submarine_Library
{
    /// <summary>
    /// Миноносец.
    /// </summary>
    public class Destroyer : GameObject, IMovable
    {
        private float speed;

        private Direction direction;

        /// <summary>
        /// Инициализатор миноносца.
        /// </summary>
        /// <param name="direction"></param>
        public Destroyer(Direction direction)
        {          
            speed = 20;
            this.direction = direction;
        }

        /// <summary>
        /// Движение миноносца.
        /// </summary>
        /// <param name="time"> Время. </param>
        public void Move(double time)
        {
            float x = Transform.Position.X;
            float y = Transform.Position.Y;

            if (direction == Direction.Right)
            {
                x += (float)(Math.Pow(speed, 2) * time);
            }

            if (direction == Direction.Left)
            {
                x -= (float)(Math.Pow(speed, 2) * time);
            }

            Transform.Position = new Vector2(x, y);
        }
    }
}
