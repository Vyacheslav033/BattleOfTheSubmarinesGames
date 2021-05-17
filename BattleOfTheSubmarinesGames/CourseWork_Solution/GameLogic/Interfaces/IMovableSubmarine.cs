using System;

namespace GameLogic
{
    /// <summary>
    /// Движение игровых объектов.
    /// </summary>
    public interface IMovableSubmarine
    {
        void Move(Direction direction, double time);
    }
}
