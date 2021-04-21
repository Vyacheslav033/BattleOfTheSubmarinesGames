using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.Rockets
{
    /// <summary>
    /// Ледяная ракета.
    /// </summary>
    public class IceTorpedo : Rocket
    {      
        public IceTorpedo(Direction direction) : base(15, 10, 15, direction) { }
    }
}
