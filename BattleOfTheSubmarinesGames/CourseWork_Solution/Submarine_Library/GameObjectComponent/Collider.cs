using System;
using System.Collections.Generic;
using OpenTK;

namespace Submarine_Library.GameObjectComponent
{
    public abstract class Collider : GameComponents
    {
        public abstract List<Vector2> GetField(GameObject gameObject);
        
        /// <summary>
        /// Получение вершин объекта.
        /// </summary>
        /// <param name="gameObject"> Игровой объект. </param>
        /// <returns> Вершины. </returns>
        public static List<Vector2> GetVertices(GameObject gameObject)
        {
            return (gameObject.GetComponent<Collider>() as Collider).GetField(gameObject);
        }

        public static bool CheckCollision(GameObject gameObject_1, GameObject gameObject_2)
        {
            if (gameObject_1.GetComponent<Collider>() == null)
            {
                throw new ArgumentNullException($"Игровой объект {gameObject_1.GetType().Name} не имеет коллайдера!", nameof(gameObject_1));
            }

            if (gameObject_2.GetComponent<Collider>() == null)
            {
                throw new ArgumentNullException($"Игровой объект {gameObject_2.GetType().Name} не имеет коллайдера!", nameof(gameObject_2));
            }

            if (gameObject_1 == null)
            {
                throw new ArgumentNullException($"Игровой объект {gameObject_1.GetType().Name} является null!", nameof(gameObject_1));
            }

            if (gameObject_2 == null)
            {
                throw new ArgumentNullException($"Игровой объект {gameObject_2.GetType().Name} является null!", nameof(gameObject_2));
            }

            List<Vector2> vertices_1 = GetVertices(gameObject_1);
            List<Vector2> vertices_2 = GetVertices(gameObject_2);

            foreach (Vector2 point in vertices_2)
            {
                if (CheckPointCollision(gameObject_1, point))
                {
                    return true;
                }
            }

            foreach (Vector2 point in vertices_1)
            {
                if (CheckPointCollision(gameObject_2, point))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckPointCollision(GameObject gameObject, Vector2 point)
        {
            bool collision = false;

            float x = point.X;
            float y = point.Y;

            List<Vector2> vertices = GetVertices(gameObject);

            for (int i = 0, j = vertices.Count - 1; i < vertices.Count; j = i++)
            {
                if ((((vertices[i].Y <= y) && (y < vertices[j].Y)) ||
                    ((vertices[j].Y <= y) && (y < vertices[i].Y))) &&
                    (((vertices[j].Y - vertices[i].Y) != 0) &&
                    (x > ((vertices[j].X - vertices[i].X) * (y - vertices[i].Y) / (vertices[j].Y - vertices[i].Y) + vertices[i].X))))
                {
                    collision = !collision;
                }
            }

            return collision;
        }
    }
}