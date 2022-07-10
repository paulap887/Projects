using Microsoft.EntityFrameworkCore;
using SuitAlteration.Messaging.Receive.DbContext;
using SuitAlteration.Messaging.Receive.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Messaging.Receive.Service
{
    public class AlterationService : IAlterationService
    {
        private readonly SuitApplicationDbContext _context; 

        public AlterationService(SuitApplicationDbContext context)
        {
            _context = context;
        }
        public async Task UpdateAlterationAsPaid(int alterationId)
        {
            Alteration alteration = await _context.Alterations.FirstOrDefaultAsync(a => a.Id == alterationId);

            if(alteration != null)
            {
                alteration.Status = Domain.Enums.AlterationStatus.Paid;
                alteration.LastModified = DateTime.UtcNow;
            }
            await _context.SaveChangesAsync();
        }
    }
}
