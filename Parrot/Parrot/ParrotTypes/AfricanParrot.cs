using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot.ParrotTypes
{
    public class AfricanParrot : ParrotType
    {
        public override double GetSpeed(Parrot parrot)
        {
            return Math.Max(0, GetBaseSpeed() - getLoadFactor() * parrot.GetNumberOfCoconuts());
        }

        private double getLoadFactor()
        {
            return 9.0;
        }
    }
}
