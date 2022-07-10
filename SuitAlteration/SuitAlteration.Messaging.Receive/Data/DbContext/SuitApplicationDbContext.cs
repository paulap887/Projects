using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Messaging.Receive.DbContext
{
    public class SuitApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbSet<Alteration> Alterations { get; set; }
        public SuitApplicationDbContext(DbContextOptions<SuitApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
