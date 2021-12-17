using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot.ParrotTypes
{
    public class EuropeanParrot : ParrotType
    {
        public override double GetSpeed(Parrot parrot)
        {
            return GetBaseSpeed();
        }
    }
}
