using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLogic;

namespace AppVerification
{  
    /// <summary>
    /// Тестирование классов фабричного метода.
    /// </summary>
    [TestClass()]
    public class FactoryMethod_Tests
    {
        /// <summary>
        /// Создание бонуса здоровья.
        /// </summary>
        [TestMethod()]
        public void HealthBonus_Test()
        {
            // Arrang.
            var submarine = new BlueSubmarine(new RocketAmmunition());
            var expectedsubmarine = new AdditionalHealth(submarine);

            // Act.
            var creatorHealth = new CreatorHealth();
            var healthBonus = creatorHealth.CreateBonus();
            var newSubmarine = healthBonus.Activation(submarine);

            // Assert.
            Assert.AreEqual(newSubmarine.GetType(), expectedsubmarine.GetType());
        }

        /// <summary>
        /// Создание бонуса брони.
        /// </summary>
        [TestMethod()]
        public void ArmorBonus_Test()
        {
            // Arrang.
            var submarine = new BlueSubmarine(new RocketAmmunition());
            var expectedsubmarine = new AdditionalArmor(submarine);

            // Act.
            var creatorArmor = new CreatorArmor();
            var armorBonus = creatorArmor.CreateBonus();
            var newSubmarine = armorBonus.Activation(submarine);

            // Assert.
            Assert.AreEqual(newSubmarine.GetType(), expectedsubmarine.GetType());
        }

        /// <summary>
        /// Создание бонуса скорости.
        /// </summary>
        [TestMethod()]
        public void SpeedBonus_Test()
        {
            // Arrang.
            var submarine = new BlueSubmarine(new RocketAmmunition());
            var expectedsubmarine = new AdditionalSpeed(submarine);

            // Act.
            var creatorSpeed = new CreatorSpeed();
            var speedBonus = creatorSpeed.CreateBonus();
            var newSubmarine = speedBonus.Activation(submarine);

            // Assert.
            Assert.AreEqual(newSubmarine.GetType(), expectedsubmarine.GetType());
        }

        /// <summary>
        /// Создание бонуса боеприпасов.
        /// </summary>
        [TestMethod()]
        public void AmmunitionBonus_Test()
        {
            // Arrang.
            var submarine = new BlueSubmarine(new RocketAmmunition());
            var expectedsubmarine = new AdditionalAmmunition(submarine);

            // Act.
            var creatorAmmo = new CreatorAmmunition();
            var ammoBonus = creatorAmmo.CreateBonus();
            var newSubmarine = ammoBonus.Activation(submarine);

            // Assert.
            Assert.AreEqual(newSubmarine.GetType(), expectedsubmarine.GetType());
        }
    }
}
