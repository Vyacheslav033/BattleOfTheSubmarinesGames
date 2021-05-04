﻿using System;

namespace Submarine_Library
{
    /// <summary>
    /// Ледяная ракета.
    /// </summary>
    public class IceRocket : Rocket
    {      
        public IceRocket(Direction direction, Type owner) : base(30, 60, 55, 1000, direction, owner) { }
    }
}
