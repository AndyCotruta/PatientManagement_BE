using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManagement.Core.Entities;
using PatientManagement.Infrastructure.Data.Constants;

namespace PatientManagement.Infrastructure.Data.Configurations
{
    public class PatientConfiguration : BaseConfiguration<Patient>
    {
        protected override string TableName => TableNames.Patients;
        public override void Configure(EntityTypeBuilder<Patient> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Mrn)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(p => p.Mrn)
                .IsUnique();

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.DateOfBirth)
                .IsRequired();

            builder.Property(p => p.Gender)
                .IsRequired()
                .HasMaxLength(50)
                .HasConversion<string>();

            // Optional fields
            builder.Property(p => p.AddressLine1)
                .HasMaxLength(255);

            builder.Property(p => p.AddressLine2)
                .HasMaxLength(255);

            builder.Property(p => p.City)
                .HasMaxLength(100);

            builder.Property(p => p.State)
                .HasMaxLength(50);

            builder.Property(p => p.PostalCode)
                .HasMaxLength(20);

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(p => p.Email)
                .HasMaxLength(255);

            builder.Property(p => p.EmergencyContactName)
                .HasMaxLength(200);

            builder.Property(p => p.EmergencyContactPhone)
                .HasMaxLength(20);
        }
    }
}
