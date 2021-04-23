using System;
using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.Rockets
{
    /// <summary>
    /// Огненная ракета.
    /// </summary>
    public class FieryRocket : Rocket
    {      
        public FieryRocket(Direction direction, Type owner) : base(35, 20, 25, 750, direction, owner) { } 
    }
}
