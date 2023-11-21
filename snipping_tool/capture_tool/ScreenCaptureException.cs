using System;
using System.Runtime.Serialization;

namespace capture_tool.ScreenCapture
{
    [Serializable]
    internal class ScreenCaptureException : Exception
    {
        public ScreenCaptureException()
        {
        }

        public ScreenCaptureException(string message) : base(message)
        {
        }

        public ScreenCaptureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ScreenCaptureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}