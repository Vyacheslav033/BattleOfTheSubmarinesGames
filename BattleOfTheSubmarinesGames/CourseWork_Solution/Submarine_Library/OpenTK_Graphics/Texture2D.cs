using System;
using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.OpenTK_Graphics
{
    /// <summary>
    /// Свойства текстуры.
    /// </summary>
    public class Texture2D : GameComponents
    {
        private int id;

        private int width;

        private int height;

        /// <summary>
        /// Инициализатор текстуры.
        /// </summary>
        /// <param name="id"> Номер текстуры. </param>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        public Texture2D(int id, int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentException($"Ширина текстура не может быть {width}", nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentException($"Высота текстура не может быть {height}", nameof(height));
            }

            this.id = id;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Номер текстуры.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Ширина.
        /// </summary>
        public int Width
        {
            get { return width; }
            set
            {
                if (value > 0)
                {
                    width = value;
                }
            }
        }

        /// <summary>
        /// Высота.
        /// </summary>
        public int Height
        {
            get { return height; }
            set
            {
                if (value > 0)
                {
                    height = value;
                }
            }
        }

    }
}
