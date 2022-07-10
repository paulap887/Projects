using SuitAlteration.Domain.Common;
using SuitAlteration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Domain.Events
{ 
    public class AlterationStartedEvent : BaseEvent
    {
        public AlterationStartedEvent(Alteration item)
        {
            Item = item;
        }

        public Alteration Item { get; }
    }
}
