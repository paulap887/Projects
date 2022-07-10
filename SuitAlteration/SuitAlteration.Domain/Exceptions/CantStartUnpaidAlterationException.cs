using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Domain.Exceptions
{ 
    public class CantStartUnpaidAlterationException : Exception
    {
        public CantStartUnpaidAlterationException()
            : base($"Couldn't start this unpaid Alteration")
        {
        }
    }
}
