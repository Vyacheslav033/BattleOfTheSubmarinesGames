using OpenTK;
using System;
using System.Collections.Generic;

namespace Submarine_Library.GameObjectComponent
{
    /// <summary>
    /// Коллайдер прямоугольной формы.
    /// </summary>
    public class BoxCollider : Collider
    {
        private int width;

        public bool Visability { get; set; }

        private int height;

        /// <summary>
        /// Инициализатор коллайдера.
        /// </summary>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        public BoxCollider(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentException($"Ширина коллайдера не может быть {width}", nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentException($"Высота коллайдера не может быть {height}", nameof(height));
            }

            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Считывание вершин игрового объекта.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        public override List<Vector2> GetField(GameObject gameObject)
        {
            if (!gameObject.GetComponent<Collider>().Equals(this))
            {
                throw new Exception("gameObject collider doesn't match to this collider!");
            }

            float x = gameObject.Transform.Position.X;
            float y = gameObject.Transform.Position.Y;

            var halfWidth = width / 2;
            var halfHeight = height / 2;

            var vertices = new List<Vector2>()
            {
                new Vector2(x - halfWidth, y + halfHeight), // top left 
                new Vector2(x + halfWidth, y + halfHeight), // top right 
                new Vector2(x + halfWidth, y - halfHeight), // bottom right 
                new Vector2(x - halfWidth, y - halfHeight), // bottom left 
            };

            return vertices;
        }
    }
}