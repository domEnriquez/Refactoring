using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    public class FakeTelemetryDiagnosticControls : TelemetryDiagnosticControls
    {
        public FakeTelemetryDiagnosticControls(TelemetryClientInterface tc) : base(tc)
        {
        }

        protected override string getDiagnosticMessageRequest()
        {
            return "Wrong Request";
        }
    }
}
