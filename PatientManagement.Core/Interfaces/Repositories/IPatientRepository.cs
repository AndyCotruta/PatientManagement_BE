using ErrorOr;
using PatientManagement.Core.Entities;
using PatientManagement.Core.Models;

namespace PatientManagement.Core.Interfaces.Repositories
{
    /// <summary>
    /// Repository interface for patient-specific operations.
    /// </summary>
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        /// <summary>
        /// Finds a patient by their Medical Record Number.
        /// </summary>
        Task<ErrorOr<Patient>> GetByMrnAsync(string mrn, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for patients based on various criteria.
        /// </summary>
        Task<ErrorOr<IReadOnlyList<Patient>>> SearchAsync(
            string? searchTerm,
            string? gender = null,
            DateTime? dobStart = null,
            DateTime? dobEnd = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all appointments for a patient.
        /// </summary>
        Task<ErrorOr<IReadOnlyList<Appointment>>> GetPatientAppointmentsAsync(
            Guid patientId,
            DateTime? startDate = null,
            DateTime? endDate = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets complete medical history for a patient.
        /// </summary>
        Task<ErrorOr<PatientMedicalHistory>> GetMedicalHistoryAsync(
            Guid patientId,
            CancellationToken cancellationToken = default);
    }
}
