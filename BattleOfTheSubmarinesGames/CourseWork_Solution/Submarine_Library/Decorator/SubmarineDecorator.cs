using Submarine_Library.Submarines;
using Submarine_Library.GameObjectComponent;

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
            this.submarine = submarine;

            foreach (GameComponents goc in submarine.Components)
            {
                this.Components.Add(goc);
            }
        }

        public override int Health
        {
            get => submarine.Health;
        }

        public override int Armor
        {
            get => submarine.Armor;
        }

        public override float Speed
        {
            get => submarine.Speed;
        }

        public override int Ammunition
        {
            get => submarine.Ammunition;
        }
    }
}
