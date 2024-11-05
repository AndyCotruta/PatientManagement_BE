namespace PatientManagement.Core.Entities
{
    /// <summary>
    /// Represents a medical record entry documenting a patient visit or consultation.
    /// Contains clinical information, diagnoses, and treatment plans.
    /// </summary>
    /// <remarks>
    /// Medical records are crucial clinical documentation that:
    /// <list type="bullet">
    /// <item>Provide a legal record of patient care</item>
    /// <item>Track patient health history</item>
    /// <item>Support continuity of care</item>
    /// <item>Must comply with HIPAA requirements</item>
    /// <item>Serve as basis for billing and insurance claims</item>
    /// </list>
    /// Each record is immutable once created, with changes tracked through the audit system.
    /// </remarks>
    public class MedicalRecord : BaseEntity
    {
        /// <summary>
        /// Reference to the patient this medical record belongs to.
        /// </summary>
        public required Guid PatientId { get; set; }

        /// <summary>
        /// Reference to the healthcare provider who created this record.
        /// </summary>
        public required Guid ProviderId { get; set; }

        /// <summary>
        /// Date and time when the visit or consultation occurred.
        /// May be different from record creation time.
        /// </summary>
        public required DateTime VisitDate { get; set; }

        /// <summary>
        /// Primary reason for the visit as reported by the patient.
        /// Essential for clinical documentation and billing.
        /// </summary>
        public required string ChiefComplaint { get; set; }

        /// <summary>
        /// Clinical diagnosis or diagnoses made during the visit.
        /// Should use standardized diagnostic codes when applicable.
        /// </summary>
        public required string Diagnosis { get; set; }

        /// <summary>
        /// Detailed plan for treating the diagnosed condition(s).
        /// Includes medications, procedures, and follow-up instructions.
        /// </summary>
        public required string TreatmentPlan { get; set; }

        /// <summary>
        /// Additional clinical notes or observations.
        /// Optional supplementary information not fitting other categories.
        /// </summary>
        public string? Notes { get; set; }

        // Navigation properties
        /// <summary>
        /// Reference navigation property to the patient.
        /// Required for maintaining medical record integrity.
        /// </summary>
        public required Patient Patient { get; set; }

        /// <summary>
        /// Reference navigation property to the provider.
        /// Required for maintaining medical record integrity and accountability.
        /// </summary>
        public required User Provider { get; set; }
    }
}
