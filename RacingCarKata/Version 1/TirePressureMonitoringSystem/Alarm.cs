namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private const double LOW_PRESSURE_THRESHOLD = 17;
        private const double HIGH_PRESSURE_THRESHOLD = 21;

        public bool AlarmOn
        {
            get;
            private set;
        }

        public long AlarmCount
        {
            get;
            private set;
        }

        Sensor sensor;

        public Alarm(Sensor s)
        {
            sensor = s;
        }

        public void Check()
        {
            if (outsidePressureThreshold(sensor.PopNextPressurePsiValue()))
            {
                AlarmOn = true;
                AlarmCount++;
            }
            else
                AlarmOn = false;
        }

        private bool outsidePressureThreshold(double pressure)
        {
            return pressure < LOW_PRESSURE_THRESHOLD || pressure > HIGH_PRESSURE_THRESHOLD;
        }
    }
}
