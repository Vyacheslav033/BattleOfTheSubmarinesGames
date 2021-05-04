using System;
using OpenTK;

namespace Submarine_Library
{
    /// <summary>
    /// Граница.
    /// </summary>
    public class Border : GameObject
    {
        private int width;

        private int height;

        Direction direction;

        /// <summary>
        /// Инициализатор границы.
        /// </summary>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        public Border(int width, int height, Direction direction)
        {
            if (width <= 0)
            {
                throw new ArgumentException($"Ширина границы не может быть {width}", nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentException($"Высота границы не может быть {height}", nameof(height));
            }

            this.width = width;
            this.height = height;
            this.direction = direction;

            Components.Add(new BoxCollider(width, height));
            AddProperties();
        }

        /// <summary>
        /// Настройка позиции границы.
        /// </summary>
        private void AddProperties()
        {
            int x = width;
            int y = height;

            switch (direction)
            {
                case Direction.Up:
                    x = 0;
                    break;

                case Direction.Down:
                    x = 0;
                    y = y * -1;
                    break;

                case Direction.Left:
                    x = x * -1;
                    y = 0;
                    break;

                case Direction.Right:
                    y = 0;
                    break;

                default:
                    break;
            }

            Transform.Position = new Vector2(x, y);
        }
    }
}
