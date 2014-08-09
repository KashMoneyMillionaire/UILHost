using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    class EventStudentMapping : EntityTypeConfiguration<EventStudent>
    {
        public EventStudentMapping()
        {
            // PRIMARY KEY

            HasKey(p => p.Id);

            // PROPERTIES

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            HasRequired(p => p.MeetEvent)
                .WithMany(m => m.EventStudents)
                .WillCascadeOnDelete(true);

            HasRequired(p => p.Student)
                .WithMany()
                .WillCascadeOnDelete(false);

            Property(p => p.Score)
                .IsOptional();
        }
    }
}
