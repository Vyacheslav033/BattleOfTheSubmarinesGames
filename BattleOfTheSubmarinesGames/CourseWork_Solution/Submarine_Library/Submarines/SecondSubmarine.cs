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
        /// <param name="ammunition"> Торпеды. </param>
        public SecondSubmarine(List<Torpedo> ammunition) : base( ammunition ) { }
    }
}
