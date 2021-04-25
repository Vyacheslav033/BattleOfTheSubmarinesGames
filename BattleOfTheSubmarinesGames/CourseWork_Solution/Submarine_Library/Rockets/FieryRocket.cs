using System;
using Submarine_Library.GameObjectComponent;
using Submarine_Library.Submarines;

namespace Submarine_Library.Rockets
{
    /// <summary>
    /// Огненная ракета.
    /// </summary>
    public class FieryRocket : Rocket
    {      
        public FieryRocket(Direction direction, Type owner) : base(35, 45, 35, 750, direction, owner) { } 
    }
}
