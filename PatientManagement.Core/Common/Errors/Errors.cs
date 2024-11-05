using ErrorOr;

namespace PatientManagement.Core.Common.Errors
{
    /// <summary>
    /// Defines all possible errors in the domain.
    /// </summary>
    public static class Errors
    {
        public static class Patient
        {
            public static readonly Error NotFound = Error.NotFound(
                code: "Patient.NotFound",
                description: "Patient with specified identifier was not found.");

            public static readonly Error DuplicateMrn = Error.Conflict(
                code: "Patient.DuplicateMrn",
                description: "A patient with this MRN already exists.");

            public static readonly Error InvalidDateOfBirth = Error.Validation(
                code: "Patient.InvalidDateOfBirth",
                description: "Date of birth cannot be in the future.");
        }

        public static class General
        {
            public static readonly Error ConcurrencyConflict = Error.Conflict(
                code: "General.ConcurrencyConflict",
                description: "The record was modified by another user.");

            public static readonly Error DatabaseError = Error.Failure(
                code: "General.DatabaseError",
                description: "An error occurred while accessing the database.");

            public static readonly Error ValidationError = Error.Validation(
                code: "General.ValidationError",
                description: "One or more validation errors occurred.");
        }
    }
}
