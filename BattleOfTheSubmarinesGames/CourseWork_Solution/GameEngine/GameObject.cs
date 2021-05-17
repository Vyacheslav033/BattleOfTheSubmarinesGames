using System.Collections.Generic;

namespace GameEngine
{
    /// <summary>
    /// Игровой объект.
    /// </summary>
    public abstract class GameObject
    {
        private Transform transform;

        private List<GameComponents> components;

        /// <summary>
        /// Инициализатор игрового объекта.
        /// </summary>
        public GameObject()
        {
            transform = new Transform();
            components = new List<GameComponents>();
        }

        /// <summary>
        /// Позиция, вращение, масштаб объекта.
        /// </summary>
        public Transform Transform
        {
            get { return transform; }
        }

        /// <summary>
        /// Компоненты объекта.
        /// </summary>
        public List<GameComponents> Components
        {
            get { return components; }
        }

        /// <summary>
        /// Проверка типов компонентов.
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <returns></returns>
        public GameComponents GetComponent<TComponent>() where TComponent : GameComponents
        {
            foreach (GameComponents component in components)
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
