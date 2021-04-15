using OpenTK;
using System;
using System.Collections.Generic;

namespace Submarine_Library.GameObjectComponent
{
    public class BoxCollider : Collider
    {
        private int width;
        private int height;

        public BoxCollider(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public override List<Vector2> GetField(GameObject gameObject)
        {
            if (!gameObject.GetComponent<Collider>().Equals(this))
            {
                throw new Exception("gameObject collider doesn't match to this collider!");
            }

            float x = gameObject.Transform.Position.X;
            float y = gameObject.Transform.Position.Y;

            var vertices = new List<Vector2>()
            {
                new Vector2(x + width, y), // top left 
                new Vector2(x, y), // top right 
                new Vector2(x, y + height), // bottom right 
                new Vector2(x + width, y + height), // bottom left 
            };

            return vertices;
        }
    }
}