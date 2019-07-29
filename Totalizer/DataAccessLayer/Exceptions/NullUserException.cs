using System;

namespace DataAccessLayer.Exceptions
{
    public class NullUserException : ApplicationException
    {
        public NullUserException(string message) : base(message)
        {
        }
    }
}
