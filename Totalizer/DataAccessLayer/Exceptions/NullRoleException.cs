using System;

namespace DataAccessLayer.Exceptions
{
    public class NullRoleException : ApplicationException
    {
        public NullRoleException(string message) : base(message)
        {
        }
    }
}
