using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;

namespace Submarine_Library.OpenTK_Graphics
{
    /// <summary>
    /// Игровой объект.
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// Начальное положение объекта.
        /// </summary>
        public Vector2 Position { get; set; }

        private int vertexBufferId;
        private float[] vertexData;
        private Texture texture;
        private int width;
        private int height;

        /// <summary>
        /// Конструктор объекта.
        /// </summary>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        /// <param name="position"> Начальная позиция. </param>
        /// <param name="path"> Текстура. </param>
        public GameObject(int width, int height, Vector2 position, string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException($"Изображение не найдено. Провертье путь на корректность {path}", nameof(path));
            }

            this.width = width;
            this.height = height;
            Position = position;
            texture = new Texture(path);
            vertexBufferId = GL.GenBuffer();
            Resize(this.width, this.height);
        }

        /// <summary>
        /// Перемещение объекта.
        /// </summary>
        /// <param name="direction"> Вектор направления. </param>
        public void Move(Vector2 direction)
        {
            Position += direction;
            Resize(this.width, this.height);
        }

        /// <summary>
        /// Изменение размеров объекта с экраном.
        /// </summary>
        /// <param name="width"> Ширина. </param>
        /// <param name="height"> Высота. </param>
        public void Resize(int width, int height)
        {
            vertexData = new float[]
            {
                0.0f + Position.X, 0.0f + Position.Y, 0.0f,
                width + Position.X, 0.0f + Position.Y, 0.0f,
                width + Position.X, height + Position.Y, 0.0f,
                0.0f + Position.X, height + Position.Y, 0.0f
            };
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferId);
            GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        /// <summary>
        /// Отрисовка объекта.
        /// </summary>
        public void Draw()
        {
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.TextureCoordArray);
            texture.Bind();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferId);
            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
            GL.DrawArrays(PrimitiveType.Quads, 0, vertexData.Length);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            texture.Unbind();

            GL.DisableClientState(ArrayCap.VertexArray);
            GL.DisableClientState(ArrayCap.TextureCoordArray);
            //GL.Translate(1.0, 0.0, 0.0);
            //GL.Vertex2(-1, 1);
            //GL.Scale(-1,1,1);
        }

        /// <summary>
        /// Очистка памяти.
        /// </summary>
        public void Dispose()
        {
            texture?.Dispose();
            GL.DeleteBuffer(vertexBufferId);
        }
    }
}
