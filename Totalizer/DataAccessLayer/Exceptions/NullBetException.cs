using System;

namespace DataAccessLayer.Exceptions
{
   public class NullBetException :ApplicationException
    {
        public NullBetException(string message) : base(message)
        {
        }
    }
}
