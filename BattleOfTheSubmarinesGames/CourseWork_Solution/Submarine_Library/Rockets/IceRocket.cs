using System;
using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.Rockets
{
    /// <summary>
    /// Ледяная ракета.
    /// </summary>
    public class IceRocket : Rocket
    {      
        public IceRocket(Direction direction, Type owner) : base(30, 25, 20, 1000, direction, owner) { }
    }
}
