using Microsoft.EntityFrameworkCore;
using SuitAlteration.Application.Interfaces;
using SuitAlteration.Domain.Entities;
using SuitAlteration.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Infrastructure.Repositories
{
    public class AlterationRepository : Repository<Alteration>, IAlterationRepository
    {
        public AlterationRepository(SuitApplicationDbContext context)
         : base(context)
        { }
        private SuitApplicationDbContext context
        {
            get { return Context as SuitApplicationDbContext; }
        }

        public IQueryable<Alteration> GetAlterationsByCustomerId(AlterationStatus status )
        {
            return context.Alterations.Where(a => a.Status == status)
                       .Include(a => a.PieceTypeDetails).AsQueryable();
        }
    }
}
