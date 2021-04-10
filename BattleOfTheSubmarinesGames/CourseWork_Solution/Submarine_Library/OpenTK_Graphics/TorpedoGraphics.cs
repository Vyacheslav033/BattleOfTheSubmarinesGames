using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.IO;

namespace Submarine_Library.OpenTK_Graphics
{
    /// <summary>
    /// Игровой объект торпеда.
    /// </summary>
    public class TorpedoGraphics : GameObject
    {
        public TorpedoGraphics(int width, int height, Vector2 position, string path) : base(width, height, position, path) { }
    }
}
