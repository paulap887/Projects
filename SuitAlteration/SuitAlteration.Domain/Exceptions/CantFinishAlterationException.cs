using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Domain.Exceptions
{ 
    public class CantFinishAlterationException : Exception
    {
        public CantFinishAlterationException()
            : base($"Couldn't start this unpaid Alteration")
        {
        }
    }
}
