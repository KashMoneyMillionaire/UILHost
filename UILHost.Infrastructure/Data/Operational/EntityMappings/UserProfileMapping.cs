using UILHost.Infrastructure.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    public class UserProfileMapping : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMapping()
        {
            // PRIMARY KEY

            this.HasKey(u => u.Id);

            // PROPERTIES

            this.Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(u => u.PasswordSalt)
                .IsRequired()
                .HasMaxLength(100);

            //this.Property(u => u.LastUnsuccessfulLoginAttempt)
            //    .IsOptional();

            //this.Property(u => u.CurrentUnsuccessfulLoginCount)
            //    .IsOptional();

            //this.Property(u => u.Flags)
            //    .IsRequired();

            //this.Property(u => u.DataMigrationProvider)
            //    .IsOptional();

            //this.HasMany(u => u.UserProfileSecurityQuestions);

            //this.HasMany(u => u.ClientUserProfiles)
            //    .WithRequired(c => c.UserProfile);
        }
    }
}
