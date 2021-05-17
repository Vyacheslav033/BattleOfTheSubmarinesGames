using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLogic;
using GameEngine;
using OpenTK;
using System;

namespace AppVerification
{
    /// <summary>
    /// Тестирование коллайдера.
    /// </summary>
    [TestClass()]
    public class Collider_Tests
    {
        /// <summary>
        /// Тест на проверку столкновений объектов, одинаковое положение объектов.
        /// </summary>
        [TestMethod()]
        public void CollisionTrue_Test_SamePosition()
        {
            // Arrang.
            var position = new Vector2(10, 10);
            bool expected = true;

            var obj1 = new BlueSubmarine(new RocketAmmunition());
            obj1.Components.Add(new BoxCollider(100, 100));
            obj1.Transform.Position = position;

            var obj2 = new RedSubmarine(new RocketAmmunition());
            obj2.Components.Add(new BoxCollider(100, 100));
            obj2.Transform.Position = position;

            // Act.
            var actual = Collider.CheckCollision(obj1, obj2);

            // Assert.
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Тест на проверку столкновений объектов, рандомное положение объектов.
        /// </summary>
        [TestMethod()]
        public void CollisionTrue_Test_RandomPosition()
        {
            // Arrang.
            Random rn = new Random();
            int limit = 1000;
            
            var obj1 = new BlueSubmarine(new RocketAmmunition());
            obj1.Components.Add(new BoxCollider(100, 100));
            obj1.Transform.Position = new Vector2(rn.Next(-limit, limit), rn.Next(-limit, limit));

            var obj2 = new RedSubmarine(new RocketAmmunition());
            obj2.Components.Add(new BoxCollider(100, 100));
            obj2.Transform.Position = new Vector2(rn.Next(-limit, limit), rn.Next(-limit, limit));

            bool expected = (obj1.Transform.Position == obj2.Transform.Position) ? (true) : (false);

            // Act.
            var actual = Collider.CheckCollision(obj1, obj2);

            // Assert.
            Assert.AreEqual(actual, expected);
        }
    }
}
