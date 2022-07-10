using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Messaging.Receive.Service.Interfaces
{
    public interface IAlterationService
    {
        Task UpdateAlterationAsPaid(int alterationId);
    }
}
