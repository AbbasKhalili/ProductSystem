using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Shared.EF
{
    internal class ReadOnlyContext : DbContext
    {
        private readonly Assembly _mappingAssembly;

        public ReadOnlyContext(DbContextOptions options, Assembly mappingAssembly) : base(options)
        {
            _mappingAssembly = mappingAssembly;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(_mappingAssembly);
        }
    }
}
