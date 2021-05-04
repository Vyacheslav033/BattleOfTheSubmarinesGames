﻿using System;

namespace Submarine_Library
{
    /// <summary>
    /// Увеличение скорость лодки.
    /// </summary>
    public class AdditionalSpeed : SubmarineDecorator
    {
        static int boostSpeed = 2;
        public AdditionalSpeed(Submarine submarine) : base(submarine)
        {
            Speed += boostSpeed;
        }
    }
}
