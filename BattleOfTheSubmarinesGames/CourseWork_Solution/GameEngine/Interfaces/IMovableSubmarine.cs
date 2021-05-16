using System;

namespace GameEngine
{
    /// <summary>
    /// Движение игровых объектов.
    /// </summary>
    public interface IMovableSubmarine
    {
        void Move(Direction direction, double time);
    }
}
