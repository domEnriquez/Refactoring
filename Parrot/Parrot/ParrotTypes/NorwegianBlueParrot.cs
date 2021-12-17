using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot.ParrotTypes
{
    public class NorwegianBlueParrot : ParrotType
    {
        public override double GetSpeed(Parrot parrot)
        {
            return parrot.IsNailed() ? 0 : getBaseSpeed(parrot.GetVoltage());
        }

        private double getBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * GetBaseSpeed());
        }
    }
}
