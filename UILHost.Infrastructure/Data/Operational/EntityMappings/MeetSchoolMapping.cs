using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    class MeetSchoolMapping :EntityTypeConfiguration<MeetSchool>
    {
        public MeetSchoolMapping()
        {
            // PRIMARY KEY

            HasKey(p => p.Id);

            // PROPERTIES

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(m => m.Meet)
                .WithMany(m => m.CompetingSchools)
                .WillCascadeOnDelete(true);
            HasRequired(m => m.School)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
