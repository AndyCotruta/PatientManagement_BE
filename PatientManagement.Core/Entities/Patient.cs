namespace PatientManagement.Core.Entities
{
    /// <summary>
    /// Represents a patient in the healthcare system.
    /// Contains all demographic and contact information for a patient.
    /// </summary>
    /// <remarks>
    /// The Patient entity is a central entity in the system that:
    /// <list type="bullet">
    /// <item>Links to all medical records, appointments, medications, and lab results</item>
    /// <item>Stores both required demographic data and optional contact information</item>
    /// <item>Uses MRN (Medical Record Number) as a business identifier</item>
    /// <item>Implements HIPAA compliance for PHI (Protected Health Information)</item>
    /// </list>
    /// </remarks>
    public class Patient : BaseEntity
    {
        /// <summary>
        /// Medical Record Number - unique identifier for the patient within the healthcare system.
        /// Different from the system-generated Id to support integration with external systems.
        /// </summary>
        public required string Mrn { get; set; }

        /// <summary>
        /// Patient's legal first name. Required for identification.
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Patient's legal last name. Required for identification.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Patient's date of birth. Required for identification and age calculation.
        /// </summary>
        public required DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Patient's gender identity. Required for medical purposes.
        /// Maps to Gender enum.
        /// </summary>
        public required string Gender { get; set; }

        // Optional contact information
        /// <summary>
        /// Primary street address. Optional to support patients without fixed address.
        /// </summary>
        public string? AddressLine1 { get; set; }

        /// <summary>
        /// Secondary address information (apt, unit, etc.).
        /// </summary>
        public string? AddressLine2 { get; set; }

        /// <summary>
        /// City of residence.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// State or province of residence.
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// Postal code for patient's address.
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// Primary contact phone number.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Email address for communications and portal access.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Name of emergency contact person.
        /// </summary>
        public string? EmergencyContactName { get; set; }

        /// <summary>
        /// Phone number for emergency contact.
        /// </summary>
        public string? EmergencyContactPhone { get; set; }

        // Navigation properties
        /// <summary>
        /// Collection of all appointments for this patient.
        /// Supports historical tracking and future scheduling.
        /// </summary>
        public ICollection<Appointment>? Appointments { get; set; }

        /// <summary>
        /// Collection of all medical records for this patient.
        /// Provides complete medical history.
        /// </summary>
        public ICollection<MedicalRecord>? MedicalRecords { get; set; }

        /// <summary>
        /// Collection of all medications prescribed to this patient.
        /// Includes both active and historical medications.
        /// </summary>
        public ICollection<Medication>? Medications { get; set; }

        /// <summary>
        /// Collection of all lab results for this patient.
        /// Includes both completed and pending lab tests.
        /// </summary>
        public ICollection<LabResult>? LabResults { get; set; }
    }
}
