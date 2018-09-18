using NUnit.Framework;
using System;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    [TestFixture]
    public class TelemetryDiagnosticControlsTest
    {
        [Test]
        public void WhenCheckTransmissionAndCannotConnectAfterThreeTries_ThenThrowException()
        {
            int trialCountToConnect = 4;
            TelemetryDiagnosticControls tdc = new TelemetryDiagnosticControls(new FakeTelemetryClient(trialCountToConnect));

            Assert.Throws<Exception>(() => tdc.CheckTransmission());
        }

        [Test]
        public void WhenCheckTransmissionAndSuccessfulConnect_ThenSendRequestAndReceiveDiagnosticInfo()
        {
            int trialCountToConnect = 2;
            TelemetryDiagnosticControls tdc = new TelemetryDiagnosticControls(new FakeTelemetryClient(trialCountToConnect));

            tdc.CheckTransmission();

            Assert.AreEqual("Fake Diagnostic Info", tdc.DiagnosticInfo);
        }

        [Test]
        public void GivenWrongDiagnosticMessageRequest_WhenCheckTransmissionAndSuccessfulConnect_ThenSendRequestAndReceiveRandomInfo()
        {
            int trialCountToConnect = 2;
            TelemetryDiagnosticControls tdc = new FakeTelemetryDiagnosticControls(new FakeTelemetryClient(trialCountToConnect));

            tdc.CheckTransmission();

            Assert.AreEqual("Random Info", tdc.DiagnosticInfo);
        }
    }
}
