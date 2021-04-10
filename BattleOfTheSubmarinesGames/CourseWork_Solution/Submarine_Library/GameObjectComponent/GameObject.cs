using System;
using System.Collections.Generic;

namespace Submarine_Library.GameObjectComponent
{
    /// <summary>
    /// Игровой объект.
    /// </summary>
    public class GameObject
    {
        public Transform Transform { get; }
        public List<GameObjectComponents> Components { get;}

        public GameObject()
        {
            Transform = new Transform();
            Components = new List<GameObjectComponents>();
        }
    }
}
