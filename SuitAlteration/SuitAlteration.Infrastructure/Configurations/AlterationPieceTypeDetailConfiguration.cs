using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuitAlteration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Infrastructure.Configurations
{ 
    public class AlterationPieceTypeDetailConfiguration : IEntityTypeConfiguration<AlterationPieceTypeDetail>
    {
        public void Configure(EntityTypeBuilder<AlterationPieceTypeDetail> builder)
        {
            builder.ToTable("AlterationPieceTypeDetails");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedOnAdd(); 
        }
    }
}
