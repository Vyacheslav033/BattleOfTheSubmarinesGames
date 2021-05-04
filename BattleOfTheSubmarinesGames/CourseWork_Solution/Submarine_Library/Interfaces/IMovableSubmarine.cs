using System;

namespace Submarine_Library
{
    /// <summary>
    /// Движение игровых объектов.
    /// </summary>
    public interface IMovableSubmarine
    {
        void Move(Direction direction, double time);
    }
}
