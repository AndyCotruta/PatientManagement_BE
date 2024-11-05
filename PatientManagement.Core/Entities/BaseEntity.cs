namespace PatientManagement.Core.Entities
{
    /// <summary>
    /// Base abstract class for all entities in the system.
    /// Provides common properties for tracking entity identity and timestamps.
    /// </summary>
    /// <remarks>
    /// This base class implements the concept of an "audit trail" by tracking
    /// when entities are created and modified. It uses required properties to ensure
    /// these essential tracking fields are always populated.
    /// </remarks>
    public abstract class BaseEntity
    {
            /// <summary>
            /// Unique identifier for the entity using GUID to support distributed systems
            /// and prevent sequential ID enumeration.
            /// </summary>
            public required Guid Id { get; set; }

            /// <summary>
            /// Timestamp when the entity was first created in the system.
            /// </summary>
            public required DateTime CreatedAt { get; set; }

            /// <summary>
            /// Timestamp when the entity was last modified.
            /// Updated automatically by the database trigger.
            /// </summary>
            public required DateTime UpdatedAt { get; set; }
    }
}
