namespace PatientManagement.Core.Enums
{
    /// <summary>
    /// Defines the possible roles a user can have in the system.
    /// Used for role-based access control (RBAC).
    /// </summary>
    /// <remarks>
    /// Each role has specific permissions and access levels:
    /// <list type="bullet">
    /// <item>Administrator: Full system access</item>
    /// <item>Physician: Clinical operations and patient care</item>
    /// <item>Nurse: Patient care and clinical support</item>
    /// <item>LabTechnician: Lab orders and results management</item>
    /// <item>Receptionist: Appointment and patient information management</item>
    /// </list>
    /// </remarks>
    public enum UserRole
    {
        /// <summary>
        /// System administrator with full access to all features.
        /// </summary>
        Administrator,

        /// <summary>
        /// Medical doctor or primary care provider.
        /// Can diagnose, prescribe, and manage patient care.
        /// </summary>
        Physician,

        /// <summary>
        /// Nursing staff providing patient care support.
        /// Can update patient records and manage care plans.
        /// </summary>
        Nurse,

        /// <summary>
        /// Laboratory staff managing test orders and results.
        /// Limited to lab-related functions.
        /// </summary>
        LabTechnician,

        /// <summary>
        /// Front desk staff managing appointments and registration.
        /// Limited to non-clinical functions.
        /// </summary>
        Receptionist
    }
}
