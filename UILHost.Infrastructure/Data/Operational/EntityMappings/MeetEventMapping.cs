using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    class MeetEventMapping : EntityTypeConfiguration<MeetEvent>
    {
        public MeetEventMapping()
        {
            // PRIMARY KEY

            HasKey(p => p.Id);

            // PROPERTIES

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(p => p.Meet)
                .WithMany(m => m.MeetEvents)
                .WillCascadeOnDelete(true);

            HasRequired(p => p.Event)
                .WithMany()
                .WillCascadeOnDelete(false);

            HasMany(o => o.EventStudents);


        }
    }
}
