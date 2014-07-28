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
    class EventStudentMapping : EntityTypeConfiguration<EventStudent>
    {
        public EventStudentMapping()
        {
            // PRIMARY KEY

            HasKey(p => p.Id);

            // PROPERTIES

            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            HasRequired(p => p.Event);
            HasRequired(p => p.Student);
            Property(p => p.Score)
                .IsOptional();
        }
    }
}
