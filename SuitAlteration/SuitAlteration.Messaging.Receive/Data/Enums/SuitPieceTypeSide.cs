using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Domain.Enums
{
    public enum SuitPieceTypeSide
    {
        [Description("Left")]
        Left = 1,
        [Description("Right")]
        Right = 2,
        [Description("Both")]
        Both = 3
    }
}
