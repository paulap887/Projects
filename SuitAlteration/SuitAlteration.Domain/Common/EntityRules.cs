using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Domain.Common
{
    public static class EntityRules
    {
        #region Alteration
        public static decimal MinimumMeasurementForAltering = -5;
        public static decimal MaximumMeasurementForAltering = 5;
        public static int MaxLengthOfAnyReasonText = 300;
        public static string DefaultCurrency = "USD";
        #endregion
    }
}
