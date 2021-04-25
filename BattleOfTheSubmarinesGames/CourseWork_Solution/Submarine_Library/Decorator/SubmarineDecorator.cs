using Submarine_Library.Submarines;
using Submarine_Library.GameObjectComponent;
using System;

namespace Submarine_Library.SubmarineDecorator
{
    public abstract class SubmarineDecorator : Submarine
    {
        protected Submarine submarine;

        /// <summary>
        /// Инициализатор.
        /// </summary>
        /// <param name="submarine"> Декорируемая лодка. </param>
        protected SubmarineDecorator(Submarine submarine)
        {
            if (submarine == null)
            {
                throw new ArgumentNullException();
            }

            this.submarine = submarine;

            Health = submarine.Health;
            Armor = submarine.Armor;
            Speed = submarine.Speed;
            Ammunition = submarine.Ammunition;
            BasicType = submarine.BasicType;

            foreach (GameComponents goc in submarine.Components)
            {
                this.Components.Add(goc);               
            }
        } 
    }
}
