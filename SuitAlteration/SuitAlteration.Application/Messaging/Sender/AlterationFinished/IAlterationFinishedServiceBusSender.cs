using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.Messaging.Sender.AlterationFinished
{
    public interface IAlterationFinishedServiceBusSender
    {
        Task SendAlterationFinishedIToServiceBus(int alterationId); 
    }
}
