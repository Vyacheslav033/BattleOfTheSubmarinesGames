using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submarine_Library.Torpedos
{
    /// <summary>
    /// Ледяная торпеда.
    /// </summary>
    public class IceTorpedo : Torpedo
    {
        /// <summary>
        /// Конструктор торпеды.
        /// </summary>  
        public IceTorpedo() : base(15, 10, 15) { }
    }
}
