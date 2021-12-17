using Parrot.ParrotTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot
{
    public abstract class ParrotType
    {
        public abstract double GetSpeed(Parrot parrot);

        public static ParrotType NewType(ParrotTypeEnum typeCode)
        {
            switch (typeCode)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return new EuropeanParrot();
                case ParrotTypeEnum.AFRICAN:
                    return new AfricanParrot();
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return new NorwegianBlueParrot();
                default:
                    throw new ArgumentException("Incorrect parrot code");
            }
        }

        protected double GetBaseSpeed()
        {
            return 12.0;
        }
    }
}
