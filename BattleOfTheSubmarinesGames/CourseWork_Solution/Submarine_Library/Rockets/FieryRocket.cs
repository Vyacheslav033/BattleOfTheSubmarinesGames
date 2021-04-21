using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.Rockets
{
    /// <summary>
    /// Огненная ракета.
    /// </summary>
    public class FieryRocket : Rocket
    {      
        public FieryRocket(Direction direction) : base(25, 15, 10, direction) { } 
    }
}
