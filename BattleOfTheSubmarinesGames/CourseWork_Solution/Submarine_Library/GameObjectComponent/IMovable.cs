using System;

namespace Submarine_Library.GameObjectComponent
{
    
    public interface IMovable
    {
        /// <summary>
        /// Движение объекта.
        /// </summary>
        void Move(Direction direction, double time);
    }
}
