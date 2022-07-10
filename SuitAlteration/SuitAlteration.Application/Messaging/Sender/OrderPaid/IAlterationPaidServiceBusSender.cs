using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Messaging.Sender.OrderPaid
{
    public interface IAlterationPaidServiceBusSender
    {
        Task SendAlterationPaidIToServiceBus(int alterationId);
    }
}
