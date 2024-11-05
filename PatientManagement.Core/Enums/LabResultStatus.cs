namespace PatientManagement.Core.Enums
{
    /// <summary>
    /// Defines the possible states of a laboratory test result.
    /// </summary>
    public enum LabResultStatus
    {
        /// <summary>
        /// Test has been ordered but not yet performed.
        /// </summary>
        Ordered,

        /// <summary>
        /// Sample is being processed.
        /// </summary>
        InProgress,

        /// <summary>
        /// Test has been completed and results are available.
        /// </summary>
        Completed,

        /// <summary>
        /// Test was cancelled before completion.
        /// </summary>
        Cancelled,

        /// <summary>
        /// Results are outside normal ranges.
        /// Requires provider attention.
        /// </summary>
        Abnormal
    }
}
