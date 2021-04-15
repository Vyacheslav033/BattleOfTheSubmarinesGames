using System;
using OpenTK.Graphics.OpenGL;
using System.IO;

namespace Submarine_Library.OpenTK_Graphics
{
    /// <summary>
    /// Фон.
    /// </summary>
    public class Background : IDisposable
    {
        /// <summary>
        /// Ширина фона.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Высота фона.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Id буфера вершин фона.
        /// </summary>
        private int vertexBufferId;

        /// <summary>
        /// Координаты точек фона.
        /// </summary>
        private float[] vertexData;

        /// <summary>
        /// Текстура фона.
        /// </summary>
        private Texture2D texture;

        /// <summary>
        /// Конструктор фона.
        /// </summary>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        /// <param name="path"> Путь к изображению. </param>
        public Background(int width, int height, string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException($"Изображение не найдено. Проверьте путь на корректность {path}", nameof(path));
            }

            Width = width;
            Height = height;
            //texture = new Texture(path);
            vertexBufferId = GL.GenBuffer();
            Resize(Width, Height);
        }

        /// <summary>
        /// Изменение размера фона.
        /// </summary>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        public void Resize(int width, int height)
        {
            vertexData = new float[]
            {
                0.0f, 0.0f, 0.0f, // left up
                width, 0.0f, 0.0f, // right up
                width, height, 0.0f, // right dowm
                0.0f, height, 0.0f // left down
            };

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferId);
            GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        /// <summary>
        /// Отрисовка.
        /// </summary>
        public void Draw()
        {
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);
            //texture.Bind();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferId);
            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
            GL.DrawArrays(PrimitiveType.Quads, 0, vertexData.Length);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //texture.Unbind();
            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.TextureCoordArray);
        }

        /// <summary>
        /// Очистка памяти.
        /// </summary>
        public void Dispose()
        {
            //texture?.Dispose();
            GL.DeleteBuffer(vertexBufferId);
        }
    }
}
