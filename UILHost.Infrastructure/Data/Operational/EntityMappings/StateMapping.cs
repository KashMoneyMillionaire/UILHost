using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    public class StateMapping : EntityTypeConfiguration<State>
    {
        public StateMapping()
        {
            // PRIMARY KEY

            HasKey(c => c.Id);

            // PROPERTIES

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.StateNum)
                .IsRequired();

            Property(c => c.StateCode)
                .IsRequired();

            Property(c => c.StateName)
                .IsRequired();
        }
    }
}
