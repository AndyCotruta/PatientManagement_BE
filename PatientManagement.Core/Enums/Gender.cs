namespace PatientManagement.Core.Enums
{
    /// <summary>
    /// Defines the possible gender identities for patients.
    /// Supports inclusive gender documentation.
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Patient identifies as male.
        /// </summary>
        Male,

        /// <summary>
        /// Patient identifies as female.
        /// </summary>
        Female,

        /// <summary>
        /// Patient identifies as non-binary.
        /// </summary>
        NonBinary,

        /// <summary>
        /// Patient identifies as a gender not listed.
        /// </summary>
        Other,

        /// <summary>
        /// Patient chose not to specify gender.
        /// </summary>
        PreferNotToSay
    }
}
