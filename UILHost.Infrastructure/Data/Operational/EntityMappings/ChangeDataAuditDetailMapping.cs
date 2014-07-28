using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational.EntityMappings
{
    class ChangeDataAuditDetailMapping : EntityTypeConfiguration<ChangeDataAuditDetail>
    {
        public ChangeDataAuditDetailMapping()
        {
            // PRIMARY KEY

            this.HasKey(d => d.Id);

            // PROPERTIES

            this.Property(d => d.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(d => d.EntityType)
                .IsRequired();

            this.Property(d => d.EntityId)
                .IsRequired();

            this.Property(d => d.Property)
                .IsRequired();

            this.Property(d => d.OldValue)
                .IsOptional();

            this.Property(d => d.NewValue)
                .IsOptional();
        }
    }
}
