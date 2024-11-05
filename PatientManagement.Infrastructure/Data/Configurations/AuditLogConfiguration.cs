using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;
using PatientManagement.Infrastructure.Data.Constants;

namespace PatientManagement.Infrastructure.Data.Configurations
{
    /// <summary>
    /// Configuration class for the AuditLog entity.
    /// Defines database constraints and relationships.
    /// </summary>
    public class AuditLogConfiguration : BaseConfiguration<AuditLog>
    {
        protected override string TableName => TableNames.AuditLogs;
        protected override string SchemaName => SchemaNames.Audit;
        public override void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            base.Configure(builder);

            builder.Property(al => al.ActionType)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(al => al.TableName)
                .IsRequired()
                .HasMaxLength(50);

            // Using JSON columns for old and new values
            builder.Property(al => al.OldValues)
                .HasColumnType("jsonb");

            builder.Property(al => al.NewValues)
                .HasColumnType("jsonb");

            builder.Property(al => al.IpAddress)
                .HasMaxLength(45);  // IPv6 addresses can be up to 45 characters

            // Relationship with User (optional)
            builder.HasOne(al => al.User)
                .WithMany()  // No navigation property on User
                .HasForeignKey(al => al.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // Indexes for faster querying
            builder.HasIndex(al => al.CreatedAt);
            builder.HasIndex(al => new { al.TableName, al.RecordId });
            builder.HasIndex(al => al.UserId);
        }
    }
}
