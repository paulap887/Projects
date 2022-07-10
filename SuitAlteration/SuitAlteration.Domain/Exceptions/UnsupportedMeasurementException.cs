using SuitAlteration.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Domain.Exceptions
{
    public class UnsupportedMeasurementException : Exception
    {
        public UnsupportedMeasurementException(string code)
            : base($"Measurement can be up to + or – {EntityRules.MaximumMeasurementForAltering.ToString()} cm(s) ")
        {
        }
    }

}

