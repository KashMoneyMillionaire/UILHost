using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    class AddressMapping : EntityTypeConfiguration<Address>
    {
        public AddressMapping()
        {
            // PRIMARY KEY

            HasKey(c => c.Id);

            // PROPERTIES

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Line1)
                .IsOptional();

            Property(c => c.Line2)
                .IsOptional();

            Property(c => c.City)
                .IsOptional();

            HasOptional(r => r.State);

            Property(c => c.ZipCode)
                .IsOptional();

            Property(c => c.County)
                .IsOptional();
        }
    }
}
