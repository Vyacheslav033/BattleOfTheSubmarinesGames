using OpenTK;

namespace Submarine_Library.GameObjectComponent
{
    /// <summary>
    /// Значения позиции, вращения, масштаба объекта.
    /// </summary>
    public class Transform
    {
        /// <summary>
        /// Позиция.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Вращение.
        /// </summary>
        public Vector2 Rotation { get; set; }

        /// <summary>
        /// Масштаб.
        /// </summary>
        public Vector2 Scale { get; set; }

        /// <summary>
        /// Инициализатор.
        /// </summary>
        public Transform()
        {
            Position = new Vector2(0.0f, 0.0f);
            Rotation = new Vector2(0.0f, 0.0f);
            Scale = new Vector2(1.0f, 1.0f);
        }    
    }
}
