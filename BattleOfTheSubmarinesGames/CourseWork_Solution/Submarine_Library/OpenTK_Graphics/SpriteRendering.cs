using OpenTK;
using OpenTK.Graphics.OpenGL;
using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.OpenTK_Graphics
{
    /// <summary>
    /// Работа с текстурой, отрисовка.
    /// </summary>
    public class SpriteRendering : GameComponents
    {
        /// <summary>
        /// Отрисовка текстуры.
        /// </summary>
        /// <param name="texture"> Класс со свойствами текстуры. </param>
        /// <param name="transform"> Позиция. </param>
        public static void Draw(Texture2D texture, Transform transform)
        {
            Vector2[] vertices = new Vector2[4]
            {
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1),
                new Vector2(0, 1),
            };

            GL.BindTexture(TextureTarget.Texture2D, texture.Id);
            GL.Begin(PrimitiveType.Quads);

            for (var i = 0; i < vertices.Length; ++i)
            {
                GL.TexCoord2(vertices[i]);

                vertices[i].X *= texture.Width;
                vertices[i].Y *= texture.Height;
                vertices[i] *= transform.Scale;
                vertices[i] += transform.Position;
                vertices[i] -= new Vector2(texture.Width / 2, texture.Height / 2);

                GL.Vertex2(vertices[i]);
            }

            GL.End();
        }

        public static void Begin(int screenWidth, int screenHeight)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            // Убрать деления на два.

            int halfScreenWidth = screenWidth / 2;
            int halfScreenHeight = screenHeight / 2;

            GL.Ortho(-halfScreenWidth, halfScreenWidth, -halfScreenHeight, halfScreenHeight, 0.0f, 1.0f);
        }
    }
}
