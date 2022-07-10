using SuitAlteration.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SuitAlteration.Messaging.Receive.DbContext
{
    public class AlterationPieceTypeDetail : BaseAuditableEntity
    {
        public int Id { get; set; }
        public int AlterationId { get; set; }
        public SuitPieceType SuitPieceType { get; set; } 
        public SuitPieceTypeSide SuitPieceTypeSide { get; set; }
        public decimal AdjustmentInCms { get; set; }
        public Alteration Alteration { get; set; }

        public bool IsMeasurementValid() 
        {
            return AdjustmentInCms > 0 && AdjustmentInCms <= 5;
        }
    }
}
