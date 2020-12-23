using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// enum of ExceptionType Contain Constants
        /// </summary>
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDE,
            INVALID_USER_ID
        }

        ExceptionType type;

        /// <summary>
        /// Parameterized Constructor Initializes a new instance of the <see cref="CabInvoiceException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="message">The message.</param>
        public CabInvoiceException(ExceptionType type,string message) : base(message)
        {
            this.type = type;
        }
    }
}
