namespace PatientManagement.Core.Enums
{
    /// <summary>
    /// Defines the possible states of a medication prescription.
    /// </summary>
    public enum MedicationStatus
    {
        /// <summary>
        /// Medication is currently being taken.
        /// </summary>
        Active,

        /// <summary>
        /// Medication was stopped before completion.
        /// </summary>
        Discontinued,

        /// <summary>
        /// Full course of medication was completed.
        /// </summary>
        Completed,

        /// <summary>
        /// Medication temporarily suspended.
        /// </summary>
        OnHold
    }
}
