using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class FakeSensor : Sensor
    {
        private double[] pressures;
        private int count = 0;

        public FakeSensor()
        {
        }

        public double PopNextPressurePsiValue()
        {
            return pressures[count++];
        }

        public void SetPressures(params double[] pressures)
        {
            this.pressures = pressures;
        }
    }
}
