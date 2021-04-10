using System;
using System.Collections.Generic;
using OpenTK;

namespace Submarine_Library.GameObjectComponent
{
    public class BoxCollider
    {
        private float width;
        private float height;

        public BoxCollider(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        public List<Vector2> GetVertices(GameObject gameObject)
        {
            float x = gameObject.Transform.Position.X;
            float y = gameObject.Transform.Position.Y;

            float halfWidth = width / 2;
            float halfHeight = height / 2;

            var vertices = new List<Vector2>()
            {
                new Vector2(x - halfWidth, y + halfHeight), // top left 
                new Vector2(x + halfWidth, y + halfHeight), // top right 
                new Vector2(x + halfWidth, y - halfHeight), // bottom right 
                new Vector2(x - halfWidth, y - halfHeight), // bottom left 
            };

            return vertices;
        }
    }
}
