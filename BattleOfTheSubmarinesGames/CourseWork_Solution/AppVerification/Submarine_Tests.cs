using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLogic;

namespace AppVerification
{
    /// <summary>
    /// Тестирование методов стрельбы и получения урона у лодки.
    /// </summary>
    [TestClass()]
    public class Submarine_Tests
    {
        /// <summary>
        /// Тестирование метода TakingDamage класса Submarine, который отвечает за получение урона лодкой.
        /// </summary>
        [TestMethod()]
        public void TakingDamage_Test_RandomValue()
        {
            // Arrang.
            var rn = new Random();        
            var submarine = new BlueSubmarine(new RocketAmmunition());

            var testArmor = submarine.Armor;
            var healthDamage = rn.Next(0, 100);
            var armorDamage = rn.Next(0, 100);

            // Act.
            submarine.TakingDamage(healthDamage, armorDamage);
            testArmor -= armorDamage;

            // Assert.
            Assert.AreEqual(submarine.Armor, testArmor);
        }

        /// <summary>
        /// Тестирование метода Shoot класса Submarine, который отвечает за выстрел лодки.
        /// После выстрела ракетой определённого типа, подсчитываем количество ракет данного типа.
        /// </summary>
        [TestMethod()]
        public void Shoot_Test()
        {
            // Arrang.
            int limitRocket = 10;
            var submarine = new BlueSubmarine(new RocketAmmunition());
            submarine.Ammunition.AddRockets(RocketType.FieryRocket, limitRocket);
            submarine.Ammunition.AddRockets(RocketType.IceRocket, limitRocket);
            submarine.Ammunition.AddRockets(RocketType.AtomicRocket, limitRocket);

            var rocketType = RocketType.AtomicRocket;
            var atomicRocketCount = submarine.Ammunition.GetRockets(rocketType);

            // Act.
            submarine.Shoot(rocketType);
            atomicRocketCount--;

            // Assert.
            Assert.AreEqual(submarine.Ammunition.GetRockets(rocketType), atomicRocketCount);
        }
    }
}
