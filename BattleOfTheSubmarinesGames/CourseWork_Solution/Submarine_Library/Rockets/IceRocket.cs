using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.Rockets
{
    /// <summary>
    /// Ледяная ракета.
    /// </summary>
    public class IceTorpedo : Rocket
    {      
        public IceTorpedo(Direction direction) : base(30, 20, 25, direction) { }
    }
}
