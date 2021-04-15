using System;

namespace Submarine_Library.OpenTK_Graphics
{
    /// <summary>
    /// Свойства текстуры.
    /// </summary>
    public class Texture2D
    {
        /// <summary>
        /// Номер текстуры.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Ширина.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Высота.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Инициализатор текстуры.
        /// </summary>
        /// <param name="id"> Номер текстуры. </param>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        public Texture2D(int id, int width, int height)
        {
            Id = id;
            Width = width;
            Height = height;
        }
    }
}
