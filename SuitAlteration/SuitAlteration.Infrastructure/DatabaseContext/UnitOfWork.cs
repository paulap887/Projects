using MediatR;
using SuitAlteration.Application.Interfaces;
using SuitAlteration.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Infrastructure
{ 
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMediator _mediator;
        private readonly SuitApplicationDbContext _context;
        private AlterationRepository _alterationRepository;

        public UnitOfWork()
        {
        }
        public UnitOfWork(SuitApplicationDbContext context, IMediator mediator)
        {
            _mediator = mediator; 
            this._context = context;
        }

        public IAlterationRepository Alterations => _alterationRepository = _alterationRepository ?? new AlterationRepository(_context);
         
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(_context);

            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
