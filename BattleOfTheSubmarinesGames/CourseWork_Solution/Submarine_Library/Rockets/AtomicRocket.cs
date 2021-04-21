using System;
using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.Rockets
{
    /// <summary>
    /// Атомная ракета.
    /// </summary>
    public class AtomicRocket : Rocket
    {     
        public AtomicRocket(Direction direction, Type owner) : base(10, 25, 5, direction, owner) { }
    }
}
