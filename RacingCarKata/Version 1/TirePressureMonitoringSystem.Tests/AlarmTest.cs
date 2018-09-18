using NUnit.Framework;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    [TestFixture]
    public class AlarmTest
    {
        Alarm alarm;
        FakeSensor fs;

        [SetUp]
        public void SetUp()
        {
            fs = new FakeSensor();
        }

        [Test]
        public void GivenANewAlarm_WhenInitializedAlarm_ThenAlarmIsOff()
        {
            alarm = new Alarm(fs);
            Assert.AreEqual(false, alarm.AlarmOn);
        }

        [Test]
        public void GivenWithinPressureThreshold_WhenAlarmCheck_ThenAlarmIsOff()
        {
            fs.SetPressures(18);
            alarm = new Alarm(fs);

            alarm.Check();

            Assert.AreEqual(false, alarm.AlarmOn);
            Assert.AreEqual(0, alarm.AlarmCount);
        }

        [Test]
        public void GivenBelowPressureThreshold_WhenAlarmCheck_ThenTurnAlamrOn()
        {
            fs.SetPressures(16);
            alarm = new Alarm(fs);

            alarm.Check();

            Assert.AreEqual(true, alarm.AlarmOn);
            Assert.AreEqual(1, alarm.AlarmCount);
        }

        [Test]
        public void GivenAbovePressureThreshold_WhenAlarmCheck_ThenTurnAlarmOn()
        {
            fs.SetPressures(22);
            alarm = new Alarm(fs);

            alarm.Check();

            Assert.AreEqual(true, alarm.AlarmOn);
            Assert.AreEqual(1, alarm.AlarmCount);
        }

        [Test]
        public void GivenMultipleChangesInPressure_WhenAlarmCheck_ThenAlarmRespondsCorrectly()
        {
            fs = new FakeSensor();
            fs.SetPressures(18, 16, 22, 20);
            alarm = new Alarm(fs);

            alarm.Check();
            Assert.AreEqual(false, alarm.AlarmOn);
            alarm.Check();
            Assert.AreEqual(true, alarm.AlarmOn);
            alarm.Check();
            Assert.AreEqual(true, alarm.AlarmOn);
            alarm.Check();
            Assert.AreEqual(false, alarm.AlarmOn);

            Assert.AreEqual(2, alarm.AlarmCount);
        }
    }
}