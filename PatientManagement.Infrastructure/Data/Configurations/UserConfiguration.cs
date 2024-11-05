using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientManagement.Core.Entities;
using PatientManagement.Infrastructure.Data.Constants;

namespace PatientManagement.Infrastructure.Data.Configurations
{
    /// <summary>
    /// Configuration class for the User entity.
    /// Defines database constraints and relationships.
    /// </summary>
    public class UserConfiguration : BaseConfiguration<User>
    {
        protected override string TableName => TableNames.Users;
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(50)
                .HasConversion<string>();
        }
    }
}
