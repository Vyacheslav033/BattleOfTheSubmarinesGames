using OpenTK;

namespace Submarine_Library.SubmarineFactoryMethod
{
    public class LifeBonus : Bonus
    {
        public LifeBonus(int width, int height, Vector2 position, string path) : base(width, height, position, @"SpritesAndTextures\health.png") { }
    }
}
