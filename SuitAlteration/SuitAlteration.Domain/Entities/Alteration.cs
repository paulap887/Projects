using SuitAlteration.Domain.Common;
using SuitAlteration.Domain.Enums;

namespace SuitAlteration.Domain.Entities
{
    public class Alteration : BaseAuditableEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public AlterationStatus Status  { get; set; }
        public int SalesAssociateId { get; set; } 
        public string Remarks { get; set; }
        public decimal Amount { get; set; } = 0; 
        public string Currency { get; set; } = EntityRules.DefaultCurrency;
        public List<AlterationPieceTypeDetail> PieceTypeDetails { get; set; }
    }
}
