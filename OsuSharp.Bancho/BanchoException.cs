using System;
using System.Runtime.Serialization;

namespace OsuSharp.Bancho
{
    public class BanchoException : Exception
    {
        public BanchoException() : base()
        {

        }

        public BanchoException(string message) : base(message)
        {

        }

        public BanchoException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public BanchoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
