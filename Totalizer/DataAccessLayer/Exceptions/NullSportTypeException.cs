using System;

namespace DataAccessLayer.Exceptions
{
    public class NullSportTypeException : ApplicationException
    {
        public NullSportTypeException(string message) : base(message)
        {
        }
    }
}
