using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;
using PatientManagement.Infrastructure.Data.Constants;

namespace PatientManagement.Infrastructure.Data.Configurations
{
    /// <summary>
    /// Configuration class for the LabResult entity.
    /// Defines database constraints and relationships.
    /// </summary>
    public class LabResultConfiguration : BaseConfiguration<LabResult>
    {
        protected override string TableName => TableNames.LabResults;
        public override void Configure(EntityTypeBuilder<LabResult> builder)
        {
            base.Configure(builder);

            builder.Property(lr => lr.TestName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(lr => lr.Result)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(lr => lr.Unit)
                .HasMaxLength(50);

            builder.Property(lr => lr.ReferenceRange)
                .HasMaxLength(100);

            builder.Property(lr => lr.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasConversion<string>();

            builder.Property(lr => lr.Notes)
                .HasMaxLength(1000);

            builder.Property(lr => lr.TestDate)
                .IsRequired();

            // Relationships
            builder.HasOne(lr => lr.Patient)
                .WithMany(p => p.LabResults)
                .HasForeignKey(lr => lr.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(lr => lr.OrderingProvider)
                .WithMany(u => u.OrderedLabResults)
                .HasForeignKey(lr => lr.OrderingProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes for faster queries
            builder.HasIndex(lr => new { lr.PatientId, lr.TestDate });
            builder.HasIndex(lr => new { lr.PatientId, lr.Status });
        }
    }
}
