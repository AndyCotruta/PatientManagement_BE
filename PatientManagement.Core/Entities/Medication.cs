namespace PatientManagement.Core.Entities
{
    /// <summary>
    /// Represents a medication prescribed to a patient.
    /// Tracks both active and historical medications with their prescribing details.
    /// </summary>
    /// <remarks>
    /// Medication tracking is critical for:
    /// <list type="bullet">
    /// <item>Patient safety through drug interaction checking</item>
    /// <item>Medication compliance monitoring</item>
    /// <item>Prescription history maintenance</item>
    /// <item>Supporting clinical decision making</item>
    /// <item>Integration with e-prescribing systems</item>
    /// </list>
    /// The system maintains a complete history of all medications, including
    /// discontinued and completed prescriptions.
    /// </remarks>
    public class Medication : BaseEntity
    {
        /// <summary>
        /// Reference to the patient receiving the medication.
        /// </summary>
        public required Guid PatientId { get; set; }

        /// <summary>
        /// Name of the prescribed medication.
        /// Should use standardized drug nomenclature.
        /// </summary>
        public required string MedicationName { get; set; }

        /// <summary>
        /// Prescribed dosage including strength and form.
        /// Example: "20mg tablet"
        /// </summary>
        public required string Dosage { get; set; }

        /// <summary>
        /// Instructions for medication administration.
        /// Example: "Take once daily with food"
        /// </summary>
        public required string Frequency { get; set; }

        /// <summary>
        /// Date when the medication should begin.
        /// </summary>
        public required DateTime StartDate { get; set; }

        /// <summary>
        /// Optional end date for the medication.
        /// Null indicates indefinite or as-needed medication.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Reference to the healthcare provider who prescribed the medication.
        /// </summary>
        public required Guid PrescribingProviderId { get; set; }

        /// <summary>
        /// Current status of the medication.
        /// Maps to MedicationStatus enum.
        /// </summary>
        public required string Status { get; set; }

        // Navigation properties
        /// <summary>
        /// Reference navigation property to the patient.
        /// Required for medication tracking.
        /// </summary>
        public required Patient Patient { get; set; }

        /// <summary>
        /// Reference navigation property to the prescribing provider.
        /// Required for prescription accountability.
        /// </summary>
        public required User PrescribingProvider { get; set; }
    }
}
