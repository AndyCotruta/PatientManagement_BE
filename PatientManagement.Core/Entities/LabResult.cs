using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.Core.Entities
{
    /// <summary>
    /// Represents a laboratory test result for a patient.
    /// Tracks both the order and results of diagnostic tests.
    /// </summary>
    /// <remarks>
    /// Lab results management is essential for:
    /// <list type="bullet">
    /// <item>Clinical decision making</item>
    /// <item>Patient diagnosis and monitoring</item>
    /// <item>Treatment effectiveness evaluation</item>
    /// <item>Historical health tracking</item>
    /// </list>
    /// The system maintains both pending and completed lab results,
    /// supporting the full lifecycle of laboratory testing.
    /// </remarks>
    public class LabResult : BaseEntity
    {
        /// <summary>
        /// Reference to the patient for whom the test was ordered.
        /// </summary>
        public required Guid PatientId { get; set; }

        /// <summary>
        /// Reference to the healthcare provider who ordered the test.
        /// </summary>
        public required Guid OrderingProviderId { get; set; }

        /// <summary>
        /// Name or type of the laboratory test.
        /// Should use standardized test codes when applicable.
        /// </summary>
        public required string TestName { get; set; }

        /// <summary>
        /// Date and time when the test was performed.
        /// </summary>
        public required DateTime TestDate { get; set; }

        /// <summary>
        /// Actual result value of the test.
        /// Format depends on the type of test.
        /// </summary>
        public required string Result { get; set; }

        /// <summary>
        /// Unit of measurement for the result.
        /// Optional as some tests may be qualitative.
        /// </summary>
        public string? Unit { get; set; }

        /// <summary>
        /// Normal range or expected values for the test.
        /// Optional as some tests may not have standard ranges.
        /// </summary>
        public string? ReferenceRange { get; set; }

        /// <summary>
        /// Current status of the lab result.
        /// Maps to LabResultStatus enum.
        /// </summary>
        public required string Status { get; set; }

        /// <summary>
        /// Additional comments or interpretation of results.
        /// </summary>
        public string? Notes { get; set; }

        // Navigation properties
        /// <summary>
        /// Reference navigation property to the patient.
        /// Required for maintaining result integrity.
        /// </summary>
        public required Patient Patient { get; set; }

        /// <summary>
        /// Reference navigation property to the ordering provider.
        /// Required for maintaining order accountability.
        /// </summary>
        public required User OrderingProvider { get; set; }
    }
}
