using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameEngine;

namespace AppVerification
{
    /// <summary>
    /// Тестирование классов декоратора.
    /// </summary>
    [TestClass()]
    public class Decorator_Tests
    {
        /// <summary>
        /// Тестирование класса декоратора с изменением жизней лодки.
        /// </summary>
        [TestMethod()]
        public void AdditionalHealth_Test()
        {
            // Arrang.
            var submarine = new BlueSubmarine(new RocketAmmunition());

            // Act.
            var decoratedSubmarine = new AdditionalHealth(submarine);
            var difference = decoratedSubmarine.BoostHealth;

            // Assert.
            Assert.AreEqual(decoratedSubmarine.Health, submarine.Health + difference);
        }

        /// <summary>
        /// Тестирование класса декоратора с изменением брони лодки.
        /// </summary>
        [TestMethod()]
        public void AdditionalArmor_Test()
        {
            // Arrang.
            var submarine = new BlueSubmarine(new RocketAmmunition());

            // Act.
            var decoratedSubmarine = new AdditionalArmor(submarine);
            var difference = decoratedSubmarine.BoostArmor;

            // Assert.
            Assert.AreEqual(decoratedSubmarine.Armor, submarine.Armor + difference);
        }

        /// <summary>
        /// Тестирование класса декоратора с изменением скорости лодки.
        /// </summary>
        [TestMethod()]
        public void AdditionalSpeed_Test()
        {
            // Arrang.
            var submarine = new BlueSubmarine(new RocketAmmunition());

            // Act.
            var decoratedSubmarine = new AdditionalSpeed(submarine);
            var difference = decoratedSubmarine.BoostSpeed;

            // Assert.
            Assert.AreEqual(decoratedSubmarine.Speed, submarine.Speed + difference);
        }

        /// <summary>
        /// Тестирование класса декоратора с изменением боеприпасов лодки.
        /// </summary>
        [TestMethod()]
        public void AdditionalAmmunition_Test()
        {
            // Arrang.
            var submarine = new BlueSubmarine(new RocketAmmunition());

            // Act.
            var decoratedSubmarine = new AdditionalAmmunition(submarine);
            var difference = decoratedSubmarine.BoostAmmunition;

            // Assert.
            Assert.AreEqual(decoratedSubmarine.Ammunition.Count(), submarine.Ammunition.Count() + difference);
        }
    }
}