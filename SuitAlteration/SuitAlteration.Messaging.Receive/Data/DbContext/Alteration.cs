using SuitAlteration.Domain.Enums;
using System.Collections.Generic;

namespace SuitAlteration.Messaging.Receive.DbContext
{
    public class Alteration : BaseAuditableEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public AlterationStatus Status  { get; set; }
        public int SalesAssociateId { get; set; } 
        public string Remarks { get; set; }
        public decimal Amount { get; set; } = 0; 
        public string Currency { get; set; } = "USD";
        public List<AlterationPieceTypeDetail> PieceTypeDetails { get; set; }
    }
}
