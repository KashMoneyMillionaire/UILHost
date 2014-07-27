using UILHost.Infrastructure.Data.Operational.EntityMappings;
using UILHost.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILHost.Infrastructure.Data.Operational
{
    public class OperationalDataContext : DbContext
    {
        static OperationalDataContext()
        {
            Database.SetInitializer<OperationalDataContext>(null);
        }

        public OperationalDataContext() : base("Name=OperationalDataContext") { }
        public OperationalDataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            // base.Configuration.AutoDetectChangesEnabled = false;
        }

        public IDbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserProfileMapping());
        }

    }
}
