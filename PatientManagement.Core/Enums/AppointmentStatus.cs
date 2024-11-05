namespace PatientManagement.Core.Enums
{
    /// <summary>
    /// Defines the possible states of an appointment.
    /// Tracks the appointment through its lifecycle.
    /// </summary>
    public enum AppointmentStatus
    {
        /// <summary>
        /// Initial state when appointment is first created.
        /// </summary>
        Scheduled,

        /// <summary>
        /// Patient has confirmed they will attend.
        /// </summary>
        Confirmed,

        /// <summary>
        /// Patient has arrived and checked in.
        /// </summary>
        CheckedIn,

        /// <summary>
        /// Patient is currently with the provider.
        /// </summary>
        InProgress,

        /// <summary>
        /// Appointment has been completed.
        /// </summary>
        Completed,

        /// <summary>
        /// Appointment was cancelled before completion.
        /// </summary>
        Cancelled,

        /// <summary>
        /// Patient didn't show up for the appointment.
        /// </summary>
        NoShow
    }
}
