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
    public class AlterationConfiguration : IEntityTypeConfiguration<Alteration>
    { 
        public void Configure(EntityTypeBuilder<Alteration> builder)
        {
            builder.ToTable("Alterations");

            builder.HasKey(c => c.Id); 

            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder
                .Property(m => m.Remarks)
                .IsRequired()
                .HasMaxLength(300); 
        }
    }
}
