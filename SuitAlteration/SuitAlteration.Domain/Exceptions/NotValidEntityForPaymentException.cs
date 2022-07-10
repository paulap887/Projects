using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Domain.Exceptions
{
    public class NotValidEntityForPaymentException : Exception
    {
        public NotValidEntityForPaymentException()
            : base($"Can't process payment for this Entity")
        {
        }
    }
}
