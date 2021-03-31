using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;

namespace BattleOfTheSubmarinesGames
{
    /// <summary>
    /// Игровой объект подводная лодка.
    /// </summary>
    public class Submarine
    {
        /// <summary>
        /// Начальное положение лодки.
        /// </summary>
        public Vector2 Position { get; set; }

        private int vertexBufferId;
        private float[] vertexData;
        private Texture texture;
        private int width;
        private int height;

        /// <summary>
        /// Конструктор лодки.
        /// </summary>
        /// <param name="width"> Ширина лодки. </param>
        /// <param name="height"> Высота лодки. </param>
        /// <param name="position"> Начальная позиция лодки. </param>
        /// <param name="path"> Текстура лодки. </param>
        public Submarine(int width, int height, Vector2 position, string path)
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
            SetBuffer();
        }

        public void Move(Vector2 direction)
        {
            Position += direction;
            SetBuffer();
        }

        private void SetBuffer()
        {
            // Добавить изменение размера лодки с экраном.
            vertexData = new float[]
            {
                0.0f + Position.X, 0.0f + Position.Y,0.0f,
                width + Position.X, 0.0f + Position.Y,0.0f,
                width + Position.X, height + Position.Y,0.0f,
                0.0f + Position.X, height + Position.Y,0.0f
            };

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferId);
            GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

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
        }

        public void Dispose()
        {
            texture?.Dispose();
            GL.DeleteBuffer(vertexBufferId);
        }
    }
}
