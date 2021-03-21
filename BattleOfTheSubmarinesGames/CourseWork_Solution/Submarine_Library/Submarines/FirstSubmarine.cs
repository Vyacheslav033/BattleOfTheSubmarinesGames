using Submarine_Library.Torpedos;
using System.Collections.Generic;

namespace Submarine_Library.Submarines
{
    /// <summary>
    /// Подводная лодка первого игрока.
    /// </summary>
    public class FirstSubmarine : Submarine
    {
        /// <summary>
        ///  Конструктор лодки.
        /// </summary>
        /// <param name="life"> Жизни. </param>
        /// <param name="speed"> Скорость. </param>
        /// <param name="armor"> Броня. </param>
        /// <param name="ammunition"> Торпеды. </param>
        public FirstSubmarine(int life, double speed, int armor, List<Torpedo> ammunition) : base (life, speed, armor, ammunition) { }
    }
}
