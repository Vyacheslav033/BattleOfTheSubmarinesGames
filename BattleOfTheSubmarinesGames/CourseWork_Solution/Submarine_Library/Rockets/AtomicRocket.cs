using System;
using Submarine_Library.GameObjectComponent;
using Submarine_Library.Submarines;

namespace Submarine_Library.Rockets
{
    /// <summary>
    /// Атомная ракета.
    /// </summary>
    public class AtomicRocket : Rocket
    {     
        public AtomicRocket(Direction direction, Type owner) : base(20, 80, 60, 1250, direction, owner) { }
    }
}
