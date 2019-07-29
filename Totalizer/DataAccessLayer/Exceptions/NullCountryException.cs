using System;

namespace DataAccessLayer.Exceptions
{
    public class NullCountryException : ApplicationException
    {
        public NullCountryException(string message) : base(message)
        {
        }
    }
}
