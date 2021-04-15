using System.Collections.Generic;

namespace Submarine_Library.GameObjectComponent
{
    /// <summary>
    /// Игровой объект.
    /// </summary>
    public class GameObject
    {
        public Transform Transform { get; }

        public List<Component> Components { get;}

        /// <summary>
        /// Инициализатор игрового объекта.
        /// </summary>
        public GameObject()
        {
            Transform = new Transform();
            Components = new List<Component>();
        }

        public Component GetComponent<TComponent>() where TComponent : Component
        {
            foreach (Component component in Components)
            {
                if (component is TComponent)
                {
                    return component as TComponent;
                }
            }

            return null;
        }
    }
}
