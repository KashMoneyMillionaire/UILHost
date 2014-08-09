using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
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

            HasMany(o => o.Teachers)
                .WithOptional()
                .WillCascadeOnDelete(false);

            HasMany(o => o.Students);

            HasMany(s => s.HostedMeets);
        }
    }
}
