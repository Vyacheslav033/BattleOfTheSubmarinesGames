using Submarine_Library.Submarines;

namespace Submarine_Library.SubmarineDecorator
{
    /// <summary>
    /// Пополнение боеприпасов лодки.
    /// </summary>
    public class AdditionalAmmunition : SubmarineDecorator
    {
        static int boostAmmunition = 4;

        public AdditionalAmmunition(Submarine submarine) : base(submarine)
        {
            Ammunition += boostAmmunition;
        }  
    }
}
