using System;
using Submarine_Library.GameObjectComponent;
using Submarine_Library.Submarines;

namespace Submarine_Library.Rockets
{
    /// <summary>
    /// Ледяная ракета.
    /// </summary>
    public class IceRocket : Rocket
    {      
        public IceRocket(Direction direction, Type owner) : base(30, 60, 55, 1000, direction, owner) { }
    }
}
