using Parrot.ParrotTypes;
using System;

namespace Parrot
{
    public class Parrot
    {
        private readonly bool _isNailed;
        private readonly int _numberOfCoconuts;
        private ParrotType _type;
        private readonly double _voltage;

        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            _type = ParrotType.NewType(type);
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public int GetNumberOfCoconuts()
        {
            return _numberOfCoconuts;
        }

        public bool IsNailed()
        {
            return _isNailed;
        }

        public double GetVoltage()
        {
            return _voltage;
        }

        public double GetSpeed()
        {
            return _type.GetSpeed(this);
        }

    }
}