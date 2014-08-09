using System.Data.Entity;
using UILHost.Infrastructure.Data.Operational.EntityMappings;
using UILHost.Infrastructure.Domain;
using UILHost.Patterns.Repository.EF6;

namespace UILHost.Infrastructure.Data
{
    public class OperationalDataContext : DataContext
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

        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Event> Events { get; set; }
        public IDbSet<EventStudent> EventStudents { get; set; }
        public IDbSet<MeetEvent> MeetEvents { get; set; }
        public IDbSet<Meet> Meets { get; set; }
        public IDbSet<School> Schools { get; set; }
        public IDbSet<State> States { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Teacher> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TeacherMapping());
            modelBuilder.Configurations.Add(new StateMapping());
            modelBuilder.Configurations.Add(new EventMapping());
            modelBuilder.Configurations.Add(new SchoolMapping());
            modelBuilder.Configurations.Add(new StudentMapping());
            modelBuilder.Configurations.Add(new AddressMapping());
            modelBuilder.Configurations.Add(new MeetMapping());
            modelBuilder.Configurations.Add(new MeetEventMapping());
            modelBuilder.Configurations.Add(new EventStudentMapping());
            modelBuilder.Configurations.Add(new MeetSchoolMapping());
            
        }

    }
}
