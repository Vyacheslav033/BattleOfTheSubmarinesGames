using System;

namespace Submarine_Library.Interfaces
{
    /// <summary>
    /// Движение ракеты.
    /// </summary>
    interface IMovable
    {
        void Move(double time);
    }
}
