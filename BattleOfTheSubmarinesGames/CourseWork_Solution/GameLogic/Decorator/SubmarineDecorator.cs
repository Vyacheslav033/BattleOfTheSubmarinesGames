using System;
using GameEngine;

namespace GameLogic
{
    public abstract class SubmarineDecorator : Submarine
    {
        protected Submarine submarine;

        /// <summary>
        /// Инициализатор.
        /// </summary>
        /// <param name="submarine"> Декорируемая лодка. </param>
        protected SubmarineDecorator(Submarine submarine) : base(submarine.Ammunition)
        {
            if (submarine == null)
            {
                throw new ArgumentNullException();
            }

            this.submarine = submarine;

            Health = submarine.Health;
            Armor = submarine.Armor;
            Speed = submarine.Speed;
            BasicType = submarine.BasicType;
            AmmunitionCount = submarine.AmmunitionCount;

            foreach (GameComponents goc in submarine.Components)
            {
                this.Components.Add(goc);               
            }
        } 
    }
}
