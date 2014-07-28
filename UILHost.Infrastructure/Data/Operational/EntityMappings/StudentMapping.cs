using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    class StudentMapping :EntityTypeConfiguration<Student>
    {
        public StudentMapping()
        {
            // PRIMARY KEY

            HasKey(c => c.Id);

            // PROPERTIES

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.FirstName);
            Property(c => c.MiddleName);
            Property(c => c.LastName);
            Property(c => c.Grade);

            HasRequired(o => o.School);
        }
    }
}
