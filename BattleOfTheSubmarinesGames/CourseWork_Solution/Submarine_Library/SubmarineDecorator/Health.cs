using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Увеличение жизней лодки.
    /// </summary>
    public class Health : SubmarineDecorator
    {
        private int boostLife = 1;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="submarine"> Декорируемая лодка. </param>
        public Health(Submarine submarine) : base(submarine)
        {
            //if (boostLife < 0)
            //{
            //    throw new ArgumentException("Нельзя понижать жизни лодки", nameof(boostLife));
            //}

        }

        public override int GetHealth()
        {
            return base.GetHealth() + boostLife;
        }
    }
}
