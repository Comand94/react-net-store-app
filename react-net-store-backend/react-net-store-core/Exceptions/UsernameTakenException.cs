using System.Runtime.Serialization;

namespace react_net_store_core.Exceptions
{
    public class UsernameTakenException : Exception
    {
        public UsernameTakenException()
        {
        }

        public UsernameTakenException(string message) : base(message)
        {
        }

        public UsernameTakenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UsernameTakenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
