using System;
using Submarine_Library.GameObjectComponent;

namespace Submarine_Library.Interfaces
{
    /// <summary>
    /// Движение игровых объектов.
    /// </summary>
    public interface IMovable
    {
        void Move(Direction direction, double time);
    }
}
