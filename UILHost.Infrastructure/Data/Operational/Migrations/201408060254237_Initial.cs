namespace UILHost.Infrastructure.Data.Operational.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        County = c.String(),
                        State_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.State_Id)
                .Index(t => t.State_Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Nickname = c.String(),
                        EventType = c.Long(nullable: false),
                        TestLength = c.Time(nullable: false, precision: 7),
                        NumberOfRounds = c.Int(nullable: false),
                        IndividualMedalCount = c.Int(nullable: false),
                        TeamMedalCount = c.Int(nullable: false),
                        IndividualAdvancingCount = c.Int(nullable: false),
                        TeamAdvancingCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventStudents",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Score = c.Int(),
                        MeetEvent_Id = c.Long(nullable: false),
                        Student_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeetEvents", t => t.MeetEvent_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.MeetEvent_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.MeetEvents",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Event_Id = c.Long(nullable: false),
                        Meet_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .ForeignKey("dbo.Meets", t => t.Meet_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.Meet_Id);
            
            CreateTable(
                "dbo.Meets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        HostSchool_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.HostSchool_Id, cascadeDelete: true)
                .Index(t => t.HostSchool_Id);
            
            CreateTable(
                "dbo.MeetSchools",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Meet_Id = c.Long(nullable: false),
                        School_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meets", t => t.Meet_Id, cascadeDelete: true)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .Index(t => t.Meet_Id)
                .Index(t => t.School_Id);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Classification = c.Long(nullable: false),
                        Address_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Grade = c.Int(nullable: false),
                        School_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.School_Id, cascadeDelete: true)
                .Index(t => t.School_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        UserProfilePermissionFlag = c.Long(nullable: false),
                        PasswordHash = c.String(nullable: false, maxLength: 100),
                        PasswordSalt = c.String(nullable: false, maxLength: 100),
                        School_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.School_Id, cascadeDelete: true)
                .Index(t => t.School_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.EventStudents", "MeetEvent_Id", "dbo.MeetEvents");
            DropForeignKey("dbo.MeetEvents", "Meet_Id", "dbo.Meets");
            DropForeignKey("dbo.Meets", "HostSchool_Id", "dbo.Schools");
            DropForeignKey("dbo.MeetSchools", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.Teachers", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.Students", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.Schools", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.MeetSchools", "Meet_Id", "dbo.Meets");
            DropForeignKey("dbo.MeetEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Addresses", "State_Id", "dbo.States");
            DropIndex("dbo.Teachers", new[] { "School_Id" });
            DropIndex("dbo.Students", new[] { "School_Id" });
            DropIndex("dbo.Schools", new[] { "Address_Id" });
            DropIndex("dbo.MeetSchools", new[] { "School_Id" });
            DropIndex("dbo.MeetSchools", new[] { "Meet_Id" });
            DropIndex("dbo.Meets", new[] { "HostSchool_Id" });
            DropIndex("dbo.MeetEvents", new[] { "Meet_Id" });
            DropIndex("dbo.MeetEvents", new[] { "Event_Id" });
            DropIndex("dbo.EventStudents", new[] { "Student_Id" });
            DropIndex("dbo.EventStudents", new[] { "MeetEvent_Id" });
            DropIndex("dbo.Addresses", new[] { "State_Id" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Schools");
            DropTable("dbo.MeetSchools");
            DropTable("dbo.Meets");
            DropTable("dbo.MeetEvents");
            DropTable("dbo.EventStudents");
            DropTable("dbo.Events");
            DropTable("dbo.States");
            DropTable("dbo.Addresses");
        }
    }
}
