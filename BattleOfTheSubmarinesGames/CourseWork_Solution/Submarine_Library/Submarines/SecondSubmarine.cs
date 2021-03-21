using Submarine_Library.Torpedos;
using System.Collections.Generic;

namespace Submarine_Library.Submarines
{
    /// <summary>
    /// Подводная лодка второго игрока.
    /// </summary>
    public class SecondSubmarine : Submarine
    {
        /// <summary>
        ///  Конструктор лодки.
        /// </summary>
        /// <param name="life"> Жизни. </param>
        /// <param name="speed"> Скорость. </param>
        /// <param name="armor"> Броня. </param>
        /// <param name="ammunition"> Торпеды. </param>
        public SecondSubmarine(int life, double speed, int armor, List<Torpedo> ammunition) : base(life, speed, armor, ammunition) { }
    }
}
