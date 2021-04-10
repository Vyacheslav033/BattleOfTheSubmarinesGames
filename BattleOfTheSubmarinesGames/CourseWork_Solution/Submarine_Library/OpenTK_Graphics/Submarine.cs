using OpenTK;
using System;

namespace Submarine_Library.OpenTK_Graphics
{
    /// <summary>
    /// Игровой объект подводная лодка.
    /// </summary>
    public class Submarine : GameObject
    {
        public Submarine(int width, int height, Vector2 position, string path) : base(width, height, position, path) { }

    }
} 
