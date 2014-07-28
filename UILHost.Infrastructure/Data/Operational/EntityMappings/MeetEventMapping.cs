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
    class MeetEventMapping : EntityTypeConfiguration<MeetEvent>
    {
        public MeetEventMapping()
        {
            // PRIMARY KEY

            this.HasKey(p => p.Id);

            // PROPERTIES

            this.Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(p => p.Meet);
            HasRequired(p => p.Event);

            HasMany(o => o.Students);


        }
    }
}
