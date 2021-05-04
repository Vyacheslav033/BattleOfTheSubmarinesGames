using System;

namespace Submarine_Library
{
    /// <summary>
    /// Атомная ракета.
    /// </summary>
    public class AtomicRocket : Rocket
    {     
        public AtomicRocket(Direction direction, Type owner) : base(25, 80, 60, 1250, direction, owner) { }
    }
}
