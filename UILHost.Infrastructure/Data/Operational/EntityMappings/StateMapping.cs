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

            Property(c => c.Number)
                .IsRequired();

            Property(c => c.Code)
                .IsRequired();

            Property(c => c.Name)
                .IsRequired();
        }
    }
}
