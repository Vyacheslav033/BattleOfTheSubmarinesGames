using System.Collections.Generic;

namespace Submarine_Library.GameObjectComponent
{
    /// <summary>
    /// Игровой объект.
    /// </summary>
    public abstract class GameObject
    {
        public Transform Transform { get; }

        public List<GameComponents> Components { get;}

        /// <summary>
        /// Инициализатор игрового объекта.
        /// </summary>
        public GameObject()
        {
            Transform = new Transform();
            Components = new List<GameComponents>();
        }

        /// <summary>
        /// Проверка классов компонентов.
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <returns></returns>
        public GameComponents GetComponent<TComponent>()
            where TComponent : GameComponents
        {
            foreach (GameComponents component in Components)
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
