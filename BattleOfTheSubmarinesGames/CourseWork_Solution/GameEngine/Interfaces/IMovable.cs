using System;

namespace GameEngine
{
    /// <summary>
    /// Движение ракеты.
    /// </summary>
    interface IMovable
    {
        void Move(double time);
    }
}
