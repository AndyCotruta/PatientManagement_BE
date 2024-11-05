namespace PatientManagement.Core.Entities
{
    /// <summary>
    /// Represents a scheduled appointment between a patient and a healthcare provider.
    /// Tracks scheduling, status, and basic visit information.
    /// </summary>
    /// <remarks>
    /// Appointments are central to patient scheduling and visit tracking:
    /// <list type="bullet">
    /// <item>Links patients with providers</item>
    /// <item>Manages scheduling and time slots</item>
    /// <item>Tracks appointment status throughout the visit lifecycle</item>
    /// <item>Supports different appointment types for various medical services</item>
    /// </list>
    /// </remarks>
    public class Appointment : BaseEntity
    {
        /// <summary>
        /// Reference to the patient who is scheduled for the appointment.
        /// </summary>
        public required Guid PatientId { get; set; }

        /// <summary>
        /// Reference to the healthcare provider who will see the patient.
        /// </summary>
        public required Guid ProviderId { get; set; }

        /// <summary>
        /// Scheduled date and time for the appointment.
        /// </summary>
        public required DateTime AppointmentDate { get; set; }

        /// <summary>
        /// Duration of the appointment in minutes.
        /// Used for scheduling and resource allocation.
        /// </summary>
        public required int DurationMinutes { get; set; }

        /// <summary>
        /// Current status of the appointment.
        /// Maps to AppointmentStatus enum.
        /// </summary>
        public required string Status { get; set; }

        /// <summary>
        /// Type of appointment (e.g., New Patient, Follow-up, Consultation).
        /// </summary>
        public required string AppointmentType { get; set; }

        /// <summary>
        /// Optional notes about the appointment.
        /// Can include preparation instructions or special requirements.
        /// </summary>
        public string? Notes { get; set; }

        // Navigation properties
        /// <summary>
        /// Reference navigation property to the patient.
        /// Required for appointment validity.
        /// </summary>
        public required Patient Patient { get; set; }

        /// <summary>
        /// Reference navigation property to the provider.
        /// Required for appointment validity.
        /// </summary>
        public required User Provider { get; set; }
    }
}
