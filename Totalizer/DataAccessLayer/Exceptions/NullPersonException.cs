using System;

namespace DataAccessLayer.Exceptions
{
    public class NullPersonException : ApplicationException
    {
        public NullPersonException(string message) : base(message)
        {
        }
    }
}
