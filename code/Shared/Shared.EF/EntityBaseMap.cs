using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain;

namespace Shared.EF
{
    public abstract class EntityBaseMap<T,TKey> : IEntityTypeConfiguration<T> where T : EntityBase<TKey>
    {
        private readonly string _tableName;

        protected EntityBaseMap(string tableName)
        {
            _tableName = tableName;
        }

        protected abstract void ConfigureMap(EntityTypeBuilder<T> builder);

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(_tableName);

            //builder.HasKey(a => a.Id);
            //builder.Property(a => a.Id).HasColumnName("Id");

            ConfigureMap(builder);
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
