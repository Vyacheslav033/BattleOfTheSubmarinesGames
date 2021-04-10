using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Submarine_Library.OpenTK_Graphics
{
    /// <summary>
    /// Работа с текстурами.
    /// </summary>
    public class Texture : IDisposable
    {
        /// <summary>
        /// Id текстуры.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Ширина.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Высота.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Id буфера.
        /// </summary>
        public int BufferID { get; }

        /// <summary>
        /// Координаты текстуры.
        /// </summary>
        public float[] Coordinate { get; }

        /// <summary>
        /// Конструктор текстуры.
        /// </summary>
        /// <param name="path"> Путь к текстуре. </param>
        public Texture(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException($"Изображение не найдено. Провертье путь на корректность {path}", nameof(path));
            }

            Bitmap bmp = new Bitmap(1, 1);
            bmp = (Bitmap)Image.FromFile(path);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
            //bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);

            Width = bmp.Width;
            Height = bmp.Height;
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            ID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, ID);

            // Привязка координат к границе текстуры. 
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);

            // Фильтрация текстур.
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Linear);
           

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            bmp.UnlockBits(data);

            Coordinate = new[]
            {
                0f, 1f, // left up
                1f, 1f, // righr up
                1f, 0f, // left down
                0f, 0f  // right down
            };

            BufferID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, BufferID);
            GL.BufferData(BufferTarget.ArrayBuffer, Coordinate.Length * sizeof(float), Coordinate, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        /// <summary>
        /// Привязка текстуры.
        /// </summary>
        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, ID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, BufferID);
            GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, IntPtr.Zero);
        }

        /// <summary>
        /// Отвязка текстуры.
        /// </summary>
        public void Unbind()
        {
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        /// <summary>
        /// Очистка памяти.
        /// </summary>
        public void Dispose()
        {
            GL.DeleteBuffer(BufferID);
            GL.DeleteTexture(ID);
        }
    }
}
