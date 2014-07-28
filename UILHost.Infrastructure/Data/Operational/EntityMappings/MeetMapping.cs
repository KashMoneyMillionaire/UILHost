using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    class MeetMapping : EntityTypeConfiguration<Meet>
    {
        public MeetMapping()
        {
            // PRIMARY KEY

            HasKey(p => p.Id);

            // PROPERTIES

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(o => o.HostSchool);
            Property(o => o.StartTime);
            Property(o => o.EndTime);

            HasMany(o => o.Schools)
                .WithMany();
            HasMany(o => o.Events)
                .WithMany();
            HasMany(o => o.Students)
                .WithMany();
            
        }
    }
}
