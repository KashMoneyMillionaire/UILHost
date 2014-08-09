using UILHost.Infrastructure.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    public class TeacherMapping : EntityTypeConfiguration<Teacher>
    {
        public TeacherMapping()
        {
            // PRIMARY KEY

            HasKey(u => u.Id);

            // PROPERTIES

            Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(u => u.School)
                .WithMany(s => s.Teachers)
                .WillCascadeOnDelete(true);

            Property(u => u.UserProfilePermissionFlag);

            Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.PasswordSalt)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
