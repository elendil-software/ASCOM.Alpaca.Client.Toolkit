using System;
using System.Runtime.Serialization;

namespace ES.AscomAlpaca.Exceptions
{
    [Serializable]
    public class AlpacaNotConnectedException : AlpacaInvalidOperationException
    {
        public AlpacaNotConnectedException() : base(ErrorCodes.NotConnected)
        {
        }

        public AlpacaNotConnectedException(string message) : base(message,  ErrorCodes.NotConnected)
        {
        }

        public AlpacaNotConnectedException(string message, Exception innerException) : base(message,  ErrorCodes.NotConnected, innerException)
        {
        }

        protected AlpacaNotConnectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}