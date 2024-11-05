using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;
using PatientManagement.Infrastructure.Data.Constants;

namespace PatientManagement.Infrastructure.Data.Configurations
{
    public class AppointmentConfiguration : BaseConfiguration<Appointment>
    {
        protected override string TableName => TableNames.Appointments;
        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasConversion<string>();

            builder.Property(a => a.AppointmentType)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Notes)
                .HasMaxLength(1000);

            // Relationships
            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Provider)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
