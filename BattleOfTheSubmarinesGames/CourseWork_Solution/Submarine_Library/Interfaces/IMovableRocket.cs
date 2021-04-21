using System;

namespace Submarine_Library.Interfaces
{
    /// <summary>
    /// Движение ракеты.
    /// </summary>
    interface IMovableRocket
    {
        void Move(double time);
    }
}
