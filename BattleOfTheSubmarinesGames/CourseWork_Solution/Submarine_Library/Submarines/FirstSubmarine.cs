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
        /// <param name="ammunition"> Торпеды. </param>
        public FirstSubmarine(List<Torpedo> ammunition) : base ( ammunition ) { }
    }
}
