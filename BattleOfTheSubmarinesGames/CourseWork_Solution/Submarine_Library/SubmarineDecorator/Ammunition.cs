using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Пополнение боеприпасов лодки.
    /// </summary>
    public class Ammunition : SubmarineDecorator
    {
        private int boostAmmunition = 1;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="ammunition"> Торпеды. </param>
        /// <param name="submarine"> Декорируемая лодка. </param>
        public Ammunition(Submarine submarine) : base(submarine) { }

        public override int GetAmmunition()
        {
            return base.GetAmmunition() + boostAmmunition;
        }
    }
}
