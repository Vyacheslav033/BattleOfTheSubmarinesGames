using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Увеличение скорость лодки.
    /// </summary>
    public class Speed : SubmarineDecorator
    {
        private double boostSpeed = 1;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="submarine"> Декорируемая лодка. </param>
        public Speed(Submarine submarine) : base(submarine)
        {
            //if (boostSpeed < 0)
            //{
            //    throw new ArgumentException("Нельзя понижать скорость лодки", nameof(boostSpeed));
            //}
        }

        public override double GetSpeed()
        {
            return base.GetSpeed() + boostSpeed;
        }
    }
}
