using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;
using PatientManagement.Infrastructure.Data.Extensions;

namespace PatientManagement.Infrastructure.Data
{
    /// <summary>
    /// Database context for the Patient Management System.
    /// Handles database interactions and entity configurations.
    /// </summary>
    /// <remarks>
    /// This context:
    /// - Configures entity relationships and constraints
    /// - Implements automatic audit logging
    /// - Manages database transactions
    /// - Enforces data consistency rules
    /// </remarks>
    public class PatientManagementDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the PatientManagementDbContext.
        /// </summary>
        /// <param name="options">The options to be used by the DbContext.</param>
        public PatientManagementDbContext(DbContextOptions<PatientManagementDbContext> options)
            : base(options)
        {
        }

        // DbSet properties
        /// <summary>
        /// Gets or sets the users in the system.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the patients in the system.
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

        /// <summary>
        /// Gets or sets the appointments in the system.
        /// </summary>
        public DbSet<Appointment> Appointments { get; set; }

        /// <summary>
        /// Gets or sets the medical records in the system.
        /// </summary>
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        /// <summary>
        /// Gets or sets the medications in the system.
        /// </summary>
        public DbSet<Medication> Medications { get; set; }

        /// <summary>
        /// Gets or sets the lab results in the system.
        /// </summary>
        public DbSet<LabResult> LabResults { get; set; }

        /// <summary>
        /// Gets or sets the audit logs in the system.
        /// </summary>
        public DbSet<AuditLog> AuditLogs { get; set; }

        /// <summary>
        /// Configures the database model and relationships.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations from separate configuration classes
            modelBuilder.ApplyAllConfigurations();
        }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Set CreatedAt for new entities
            foreach (var entry in ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added))
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            // Set UpdatedAt for modified entities
            foreach (var entry in ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Modified))
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
