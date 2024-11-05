using Microsoft.EntityFrameworkCore;
using PatientManagement.Infrastructure.Data.Configurations;

namespace PatientManagement.Infrastructure.Data.Extensions
{
    /// <summary>
    /// Extension methods for entity configurations.
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Applies all entity configurations in one go.
        /// </summary>
        /// <param name="modelBuilder">The model builder instance.</param>
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalRecordConfiguration());
            modelBuilder.ApplyConfiguration(new MedicationConfiguration());
            modelBuilder.ApplyConfiguration(new LabResultConfiguration());
            modelBuilder.ApplyConfiguration(new AuditLogConfiguration());
        }
    }
}
