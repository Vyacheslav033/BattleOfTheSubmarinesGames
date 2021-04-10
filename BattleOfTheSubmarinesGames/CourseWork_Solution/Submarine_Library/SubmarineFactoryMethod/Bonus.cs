using OpenTK;
using Submarine_Library.OpenTK_Graphics;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public abstract class Bonus : GameObject
    {
        public Bonus(int width, int height, Vector2 position, string path) : base(width, height, position, path) { }
    }
}
