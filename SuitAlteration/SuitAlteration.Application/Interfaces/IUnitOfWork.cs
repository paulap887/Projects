using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Interfaces 
{
    public interface  IUnitOfWork
    {
        IAlterationRepository Alterations { get; } 
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
