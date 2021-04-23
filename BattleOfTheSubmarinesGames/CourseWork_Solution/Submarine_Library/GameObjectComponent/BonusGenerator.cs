using System;
using Submarine_Library.SubmarineFactoryMethod;

namespace Submarine_Library.GameObjectComponent
{
    /// <summary>
    /// Генератор бонусов.
    /// </summary>
    public class BonusGenerator : GameObject    
    {
        private int randomBonus;

        /// <summary>
        /// Инициализатор бонуса.
        /// </summary>
        public BonusGenerator()
        {
            Random random = new Random();
            this.randomBonus = random.Next(0, 4);
        }

        /// <summary>
        /// Номер бонуса.
        /// </summary>
        public int RandomBonus
        {
            get { return randomBonus; }
        }

        /// <summary>
        /// Генерация бонуса.
        /// </summary>
        /// <returns> Бонус. </returns>
        public Bonus GenerateBonus()
        {
            BonusCreator bonusCreator = null;
          
            switch (randomBonus)
            {
                case 0:
                    bonusCreator = new CreatorHealth();
                    break;
                case 1:
                    bonusCreator = new CreatorArmor();
                    break;
                case 2:
                    bonusCreator = new CreatorSpeed();
                    break;
                case 3:
                    bonusCreator = new CreatorAmmunition();
                    break;
                default:
                    break;
            }

            return bonusCreator.CreateBonus();
        }
    }
}
