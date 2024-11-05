namespace PatientManagement.Infrastructure.Data.Constants
{
    /// <summary>
    /// Constants for database table names.
    /// Centralizes table naming to prevent typos and ensure consistency.
    /// </summary>
    public static class TableNames
    {
        public const string Users = "users";
        public const string Patients = "patients";
        public const string Appointments = "appointments";
        public const string MedicalRecords = "medical_records";
        public const string Medications = "medications";
        public const string LabResults = "lab_results";
        public const string AuditLogs = "audit_logs";
    }

    /// <summary>
    /// Constants for database schema names.
    /// Useful when organizing tables into different schemas.
    /// </summary>
    public static class SchemaNames
    {
        public const string Default = "public";
        public const string Audit = "audit";
    }
}
