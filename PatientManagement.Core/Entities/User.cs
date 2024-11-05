namespace PatientManagement.Core.Entities
{
    /// <summary>
    /// Represents a user in the system who can access and modify patient data.
    /// This includes medical staff, administrators, and other healthcare providers.
    /// </summary>
    /// <remarks>
    /// Users are the primary actors in the system who can:
    /// <list type="bullet">
    /// <item>Create and modify patient records</item>
    /// <item>Schedule appointments</item>
    /// <item>Prescribe medications</item>
    /// <item>Order and review lab results</item>
    /// </list>
    /// The system uses role-based access control to manage permissions.
    /// </remarks>
    public class User : BaseEntity
    {
        /// <summary>
        /// Unique email address used for system login and communications.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Hashed password stored using a secure hashing algorithm.
        /// Never store or transmit plain text passwords.
        /// </summary>
        public required string PasswordHash { get; set; }

        /// <summary>
        /// User's first name, used for display and identification purposes.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// User's last name, used for display and identification purposes.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// User's role in the system, maps to UserRole enum.
        /// Controls access permissions and available features.
        /// </summary>
        public required string Role { get; set; }

        /// <summary>
        /// Indicates if the user account is currently active.
        /// Inactive users cannot log in but their records are preserved for audit purposes.
        /// </summary>
        public required bool IsActive { get; set; }

        // Navigation properties
        /// <summary>
        /// Collection of appointments where this user is the healthcare provider.
        /// Nullable because it may not be loaded in all contexts.
        /// </summary>
        public ICollection<Appointment>? Appointments { get; set; }

        /// <summary>
        /// Collection of medical records created by this user.
        /// Nullable because it may not be loaded in all contexts.
        /// </summary>
        public ICollection<MedicalRecord>? MedicalRecords { get; set; }

        /// <summary>
        /// Collection of medications prescribed by this user.
        /// Nullable because it may not be loaded in all contexts.
        /// </summary>
        public ICollection<Medication>? PrescribedMedications { get; set; }

        /// <summary>
        /// Collection of lab results ordered by this user.
        /// Nullable because it may not be loaded in all contexts.
        /// </summary>
        public ICollection<LabResult>? OrderedLabResults { get; set; }
    }
}
