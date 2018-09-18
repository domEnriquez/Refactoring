namespace TDDMicroExercises.TelemetrySystem
{
    public interface TelemetryClientInterface
    {
        bool OnlineStatus { get; }
        void Connect(string telemetryServerConnectionString);
        void Disconnect();
        string Receive();
        void Send(string message);
        string DiagnosticRequestMessage();
    }
}