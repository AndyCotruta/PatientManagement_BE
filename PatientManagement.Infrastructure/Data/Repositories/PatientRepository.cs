using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PatientManagement.Core.Common.Errors;
using PatientManagement.Core.Entities;
using PatientManagement.Core.Interfaces.Repositories;
using PatientManagement.Core.Models;

namespace PatientManagement.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Implementation of patient-specific repository operations with ErrorOr pattern.
    /// </summary>
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly PatientManagementDbContext _newContext;

        public PatientRepository(PatientManagementDbContext context) : base(context)
        {
            _newContext = context;
        }

        protected override IQueryable<Patient> AddIncludes(IQueryable<Patient> query)
        {
            return query
                .Include(p => p.Appointments)
                .Include(p => p.MedicalRecords)
                .Include(p => p.Medications)
                .Include(p => p.LabResults);
        }

        public async Task<ErrorOr<Patient>> GetByMrnAsync(
            string mrn,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var patient = await _dbSet
                    .FirstOrDefaultAsync(p => p.Mrn == mrn, cancellationToken);

                if (patient is null)
                {
                    return Errors.Patient.NotFound;
                }

                return patient;
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }

        public async Task<ErrorOr<IReadOnlyList<Patient>>> SearchAsync(
            string? searchTerm,
            string? gender = null,
            DateTime? dobStart = null,
            DateTime? dobEnd = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var query = _dbSet.AsQueryable();

                // Apply search criteria
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.Trim().ToLower();
                    query = query.Where(p =>
                        p.FirstName.ToLower().Contains(searchTerm) ||
                        p.LastName.ToLower().Contains(searchTerm) ||
                        p.Mrn.ToLower().Contains(searchTerm));
                }

                if (!string.IsNullOrWhiteSpace(gender))
                {
                    query = query.Where(p => p.Gender == gender);
                }

                if (dobStart.HasValue)
                {
                    query = query.Where(p => p.DateOfBirth >= dobStart.Value);
                }

                if (dobEnd.HasValue)
                {
                    query = query.Where(p => p.DateOfBirth <= dobEnd.Value);
                }

                // Execute query
                var patients = await query
                    .OrderBy(p => p.LastName)
                    .ThenBy(p => p.FirstName)
                    .ToListAsync(cancellationToken);

                return patients;
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }

        public async Task<ErrorOr<IReadOnlyList<Appointment>>> GetPatientAppointmentsAsync(
            Guid patientId,
            DateTime? startDate = null,
            DateTime? endDate = null,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // First verify patient exists
                var patientExists = await _dbSet.AnyAsync(p => p.Id == patientId, cancellationToken);
                if (!patientExists)
                {
                    return Errors.Patient.NotFound;
                }

                // Fix the Include query
                var query = _newContext.Appointments
                    .Where(a => a.PatientId == patientId);

                // Properly chain the Include
                var queryWithIncludes = query.Include(a => a.Provider);

                if (startDate.HasValue)
                {
                    queryWithIncludes = (IIncludableQueryable<Appointment,User>)queryWithIncludes.Where(a => a.AppointmentDate >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    queryWithIncludes = (IIncludableQueryable<Appointment, User>)queryWithIncludes.Where(a => a.AppointmentDate <= endDate.Value);
                }

                var appointments = await queryWithIncludes
                    .OrderByDescending(a => a.AppointmentDate)
                    .ToListAsync(cancellationToken);

                return appointments;
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }

        public async Task<ErrorOr<PatientMedicalHistory>> GetMedicalHistoryAsync(
            Guid patientId,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var patient = await _dbSet
                    .Include(p => p.MedicalRecords!)
                        .ThenInclude(mr => mr.Provider)
                    .Include(p => p.Medications!)
                        .ThenInclude(m => m.PrescribingProvider)
                    .Include(p => p.LabResults!)
                        .ThenInclude(lr => lr.OrderingProvider)
                    .Include(p => p.Appointments!)
                        .ThenInclude(a => a.Provider)
                    .FirstOrDefaultAsync(p => p.Id == patientId, cancellationToken);

                if (patient is null)
                {
                    return Errors.Patient.NotFound;
                }

                var medicalHistory = new PatientMedicalHistory
                {
                    Patient = patient,
                    MedicalRecords = patient.MedicalRecords?
                        .OrderByDescending(mr => mr.VisitDate)
                        .ToList() ?? new List<MedicalRecord>(),
                    Medications = patient.Medications?
                        .OrderByDescending(m => m.StartDate)
                        .ToList() ?? new List<Medication>(),
                    LabResults = patient.LabResults?
                        .OrderByDescending(lr => lr.TestDate)
                        .ToList() ?? new List<LabResult>(),
                    Appointments = patient.Appointments?
                        .OrderByDescending(a => a.AppointmentDate)
                        .ToList() ?? new List<Appointment>()
                };

                return medicalHistory;
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }

        public override async Task<ErrorOr<Patient>> AddAsync(
            Patient patient,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Check for duplicate MRN
                var existingPatient = await _dbSet
                    .FirstOrDefaultAsync(p => p.Mrn == patient.Mrn, cancellationToken);

                if (existingPatient is not null)
                {
                    return Errors.Patient.DuplicateMrn;
                }

                // Validate date of birth
                if (patient.DateOfBirth > DateTime.UtcNow)
                {
                    return Errors.Patient.InvalidDateOfBirth;
                }

                return await base.AddAsync(patient, cancellationToken);
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }

        public override async Task<ErrorOr<Patient>> UpdateAsync(
            Patient patient,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Check for duplicate MRN but exclude current patient
                var existingPatient = await _dbSet
                    .FirstOrDefaultAsync(p =>
                        p.Mrn == patient.Mrn && p.Id != patient.Id,
                        cancellationToken);

                if (existingPatient is not null)
                {
                    return Errors.Patient.DuplicateMrn;
                }

                // Validate date of birth
                if (patient.DateOfBirth > DateTime.UtcNow)
                {
                    return Errors.Patient.InvalidDateOfBirth;
                }

                return await base.UpdateAsync(patient, cancellationToken);
            }
            catch (Exception)
            {
                return Errors.General.DatabaseError;
            }
        }
    }
}
