using System;

namespace AirTickedSales.Uilities.Exceptions
{
    public class AirTicketException : Exception
    {
        public AirTicketException()
        {
        }

        public AirTicketException(string message)
            : base(message)
        {
        }

        public AirTicketException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
