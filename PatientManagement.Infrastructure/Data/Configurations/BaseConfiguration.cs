using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;
using PatientManagement.Infrastructure.Data.Constants;

namespace PatientManagement.Infrastructure.Data.Configurations
{
    /// <summary>
    /// Base configuration class providing common configuration patterns.
    /// </summary>
    /// <typeparam name="TEntity">The entity type being configured.</typeparam>
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// Gets the table name for the entity.
        /// </summary>
        protected abstract string TableName { get; }

        /// <summary>
        /// Gets the schema name for the entity.
        /// Defaults to public schema if not overridden.
        /// </summary>
        protected virtual string SchemaName => SchemaNames.Default;

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Set table name with schema
            builder.ToTable(TableName, SchemaName);

            // Configure base entity properties
            builder.HasKey(e => e.Id);

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .IsRequired();
        }
    }
}
