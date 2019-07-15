using System;

namespace DataAccessLayer.Exceptions
{
    public class NullTeamException : ApplicationException
    {
        public NullTeamException(string message) : base(message)
        {
        }
    }
}
