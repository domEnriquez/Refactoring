
using System;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls
    {
        private const string DiagnosticChannelConnectionString = "*111#";
        
        private readonly TelemetryClientInterface _telemetryClient;
        private string _diagnosticInfo = string.Empty;

        public TelemetryDiagnosticControls(TelemetryClientInterface tc)
        {
            _telemetryClient = tc;
        }

        public string DiagnosticInfo
        {
            get { return _diagnosticInfo; }
            set { _diagnosticInfo = value; }
        }

        public void CheckTransmission()
        {
            _diagnosticInfo = string.Empty;

            _telemetryClient.Disconnect();

            attemptConnect(3);

            if (!connected())
                throw new Exception("Unable to connect.");

            _telemetryClient.Send(getDiagnosticMessageRequest());
            _diagnosticInfo = _telemetryClient.Receive();
        }

        private void attemptConnect(int retryCount)
        {
            while (_telemetryClient.OnlineStatus == false && retryCount > 0)
            {
                _telemetryClient.Connect(DiagnosticChannelConnectionString);
                retryCount -= 1;
            }
        }

        private bool connected()
        {
            return _telemetryClient.OnlineStatus == true;
        }

        protected virtual string getDiagnosticMessageRequest()
        {
            return _telemetryClient.DiagnosticRequestMessage();
        }
    }
}
