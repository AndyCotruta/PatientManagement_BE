using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;
using PatientManagement.Infrastructure.Data.Constants;

namespace PatientManagement.Infrastructure.Data.Configurations
{
    /// <summary>
    /// Configuration class for the Medication entity.
    /// Defines database constraints and relationships.
    /// </summary>
    public class MedicationConfiguration : BaseConfiguration<Medication>
    {
        protected override string TableName => TableNames.Medications;
        public override void Configure(EntityTypeBuilder<Medication> builder)
        {
            base.Configure(builder);

            builder.Property(m => m.MedicationName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(m => m.Dosage)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Frequency)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasConversion<string>();

            builder.Property(m => m.StartDate)
                .IsRequired();

            // Relationships
            builder.HasOne(m => m.Patient)
                .WithMany(p => p.Medications)
                .HasForeignKey(m => m.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.PrescribingProvider)
                .WithMany(u => u.PrescribedMedications)
                .HasForeignKey(m => m.PrescribingProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes for faster queries
            builder.HasIndex(m => new { m.PatientId, m.Status });
            builder.HasIndex(m => new { m.PatientId, m.MedicationName });
        }
    }
}
