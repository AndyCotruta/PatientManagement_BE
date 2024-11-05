using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;
using PatientManagement.Infrastructure.Data.Constants;

namespace PatientManagement.Infrastructure.Data.Configurations
{
    /// <summary>
    /// Configuration class for the MedicalRecord entity.
    /// Defines database constraints and relationships.
    /// </summary>
    public class MedicalRecordConfiguration : BaseConfiguration<MedicalRecord>
    {
        protected override string TableName => TableNames.MedicalRecords;
        public override void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            base.Configure(builder);

            builder.Property(mr => mr.ChiefComplaint)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(mr => mr.Diagnosis)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(mr => mr.TreatmentPlan)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(mr => mr.Notes)
                .HasMaxLength(2000);

            builder.Property(mr => mr.VisitDate)
                .IsRequired();

            // Relationships
            builder.HasOne(mr => mr.Patient)
                .WithMany(p => p.MedicalRecords)
                .HasForeignKey(mr => mr.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mr => mr.Provider)
                .WithMany(u => u.MedicalRecords)
                .HasForeignKey(mr => mr.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Index for faster queries
            builder.HasIndex(mr => new { mr.PatientId, mr.VisitDate });
        }
    }
}
