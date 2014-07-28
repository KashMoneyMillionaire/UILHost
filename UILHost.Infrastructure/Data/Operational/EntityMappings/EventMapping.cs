using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    class EventMapping :EntityTypeConfiguration<Event>
    {
        public EventMapping()
        {
            // PRIMARY KEY

            HasKey(c => c.Id);

            // PROPERTIES

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Name);
            Property(c => c.Nickname);
            Property(c => c.EventType);
            Property(c => c.TestLength);
            Property(r => r.IndividualMedalCount);
            Property(c => c.TeamMedalCount);
            Property(c => c.IndividualAdvancingCount);
            Property(c => c.TeamAdvancingCount);
        }
    }
}
