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
    class SchoolMapping :EntityTypeConfiguration<School>
    {
        public SchoolMapping()
        {
            // PRIMARY KEY

            HasKey(p => p.Id);

            // PROPERTIES

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Name);
            Property(p => p.Classification);

            HasRequired(o => o.Address);
            HasRequired(o => o.MeetLeader);

            HasMany(o => o.Students);
        }
    }
}
