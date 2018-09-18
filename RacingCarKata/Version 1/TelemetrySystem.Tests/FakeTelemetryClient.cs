using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    public class FakeTelemetryClient : TelemetryClientInterface
    {
        private int connectTrialsCount;
        private int trialCountToConnect;
        private string diagnosticInfo;

        public bool OnlineStatus { get; private set; }

        public FakeTelemetryClient(int trialCountToConnect)
        {
            this.trialCountToConnect = trialCountToConnect;
        }

        public void Connect(string telemetryServerConnectionString)
        {
            connectTrialsCount++;

            if (connectTrialsCount == trialCountToConnect)
                OnlineStatus = true;
        }

        public void Disconnect()
        {
        }

        public string Receive()
        {
            return diagnosticInfo;
        }

        public void Send(string message)
        {
            if (message == DiagnosticRequestMessage())
                diagnosticInfo = "Fake Diagnostic Info";
            else
                diagnosticInfo = "Random Info";
        }

        public string DiagnosticRequestMessage()
        {
            return "AT#UD";
        }
    }
}
