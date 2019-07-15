using System;

namespace DataAccessLayer.Exceptions
{
    public class NullEventException : ApplicationException
    {
        public NullEventException(string message) : base(message)
        {
        }
    }
}
