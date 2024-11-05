using PatientManagement.Core.Entities;

namespace PatientManagement.Core.Models
{
    /// <summary>
    /// Represents a complete medical history for a patient.
    /// </summary>
    public class PatientMedicalHistory
    {
        public required Patient Patient { get; set; }
        public IReadOnlyList<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public IReadOnlyList<Medication> Medications { get; set; } = new List<Medication>();
        public IReadOnlyList<LabResult> LabResults { get; set; } = new List<LabResult>();
        public IReadOnlyList<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
