using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    class ChangeDataAuditMapping : EntityTypeConfiguration<ChangeDataAudit>
    {
        public ChangeDataAuditMapping()
        {
            // PRIMARY KEY

            this.HasKey(a => a.Id);

            // PROPERTIES

            this.Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(a => a.Username)
                .IsOptional();

            this.Property(a => a.TimeUpdated)
                .IsRequired();

            this.HasMany(a => a.Details)
                .WithRequired();
        }
    }
}
