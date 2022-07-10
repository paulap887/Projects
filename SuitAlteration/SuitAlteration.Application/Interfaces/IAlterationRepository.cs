using SuitAlteration.Domain.Entities;
using SuitAlteration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Interfaces 
{
    public interface IAlterationRepository : IRepository<Alteration>
    {
        IQueryable<Alteration> GetAlterationsByCustomerId(AlterationStatus status);
    }
}
