namespace PatientManagement.Core.Entities
{
    /// <summary>
    /// Represents an audit trail entry for tracking system changes.
    /// Records who made what changes to which records and when.
    /// </summary>
    /// <remarks>
    /// The audit log system is crucial for:
    /// <list type="bullet">
    /// <item>HIPAA compliance requirements</item>
    /// <item>Security monitoring and breach detection</item>
    /// <item>Change tracking and accountability</item>
    /// <item>Data recovery support</item>
    /// <item>Access pattern analysis</item>
    /// </list>
    /// 
    /// Every change to sensitive data is recorded with:
    /// <list type="number">
    /// <item>The user who made the change</item>
    /// <item>What was changed (old and new values)</item>
    /// <item>When the change occurred</item>
    /// <item>The IP address of the request</item>
    /// </list>
    /// Audit logs are immutable and cannot be modified once created.
    /// </remarks>
    public class AuditLog : BaseEntity
    {
        /// <summary>
        /// Optional reference to the user who performed the action.
        /// Null for system-generated changes or anonymous access.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Type of action performed (Create, Read, Update, Delete).
        /// Required for understanding the nature of the change.
        /// </summary>
        public required string ActionType { get; set; }

        /// <summary>
        /// Name of the database table or entity type that was modified.
        /// Required for tracking what kind of data was affected.
        /// </summary>
        public required string TableName { get; set; }

        /// <summary>
        /// Optional reference to the specific record that was modified.
        /// Null for queries that don't target specific records.
        /// </summary>
        public Guid? RecordId { get; set; }

        /// <summary>
        /// JSON serialized representation of the data before changes.
        /// Null for create operations.
        /// </summary>
        public string? OldValues { get; set; }

        /// <summary>
        /// JSON serialized representation of the data after changes.
        /// Null for delete operations.
        /// </summary>
        public string? NewValues { get; set; }

        /// <summary>
        /// IP address of the client making the request.
        /// Optional as not all changes may come from network requests.
        /// </summary>
        public string? IpAddress { get; set; }

        // Navigation property
        /// <summary>
        /// Reference navigation property to the user who made the change.
        /// Optional as some changes may be system-generated.
        /// </summary>
        public User? User { get; set; }
    }
}
