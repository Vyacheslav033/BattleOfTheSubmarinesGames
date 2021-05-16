using System;

namespace GameEngine
{
    /// <summary>
    /// Огненная ракета.
    /// </summary>
    public class FieryRocket : Rocket
    {      
        public FieryRocket(Direction direction, Type owner) : base(40, 45, 35, 750, direction, owner) { } 
    }
}
