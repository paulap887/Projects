using Microsoft.EntityFrameworkCore;
using SuitAlteration.Domain.Entities;
using SuitAlteration.Infrastructure.Persistence.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Infrastructure
{
    public class SuitApplicationDbContext : DbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public DbSet<Alteration> Alterations { get; set; }
        public SuitApplicationDbContext(DbContextOptions<SuitApplicationDbContext> options,
              AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)  
            : base(options)
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
