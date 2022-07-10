using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Alterations.Commands.FinishAlteration
{ 
    public record FinishAlterationCommand : IRequest<int>
    {
        public int AlterationId { get; set; } 
    }

}
