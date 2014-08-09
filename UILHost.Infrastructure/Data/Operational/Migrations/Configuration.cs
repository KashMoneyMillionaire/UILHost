using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using UILHost.Common;
using UILHost.Infrastructure.Domain;
using UILHost.Patterns.Repository.Infrastructure;

namespace UILHost.Infrastructure.Data.Operational.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<OperationalDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Data\Operational\Migrations";
            MigrationsNamespace = typeof(Configuration).Namespace;
        }

        protected override void Seed(OperationalDataContext context)
        {
            #region states

            var states = new List<State>
                {
                    new State {Code = "AL", Name = "Alabama", Number = 1},
                    new State {Code = "AK", Name = "Alaska", Number = 2},
                    new State {Code = "AZ", Name = "Arizona", Number = 3},
                    new State {Code = "AR", Name = "Arkansas", Number = 4},
                    new State {Code = "CA", Name = "California", Number = 5},
                    new State {Code = "CO", Name = "Colorado", Number = 6},
                    new State {Code = "CT", Name = "Connecticut", Number = 7},
                    new State {Code = "DE", Name = "Delaware", Number = 8},
                    new State {Code = "FL", Name = "Florida", Number = 9},
                    new State {Code = "GA", Name = "Georgia", Number = 10},
                    new State {Code = "HI", Name = "Hawaii", Number = 11},
                    new State {Code = "ID", Name = "Idaho", Number = 12},
                    new State {Code = "IL", Name = "Illinois", Number = 13},
                    new State {Code = "IN", Name = "Indiana", Number = 14},
                    new State {Code = "IA", Name = "Iowa", Number = 15},
                    new State {Code = "KS", Name = "Kansas", Number = 16},
                    new State {Code = "KY", Name = "Kentucky", Number = 17},
                    new State {Code = "LA", Name = "Louisiana", Number = 18},
                    new State {Code = "ME", Name = "Maine", Number = 19},
                    new State {Code = "MD", Name = "Maryland", Number = 20},
                    new State {Code = "MA", Name = "Massachusetts", Number = 21},
                    new State {Code = "MI", Name = "Michigan", Number = 22},
                    new State {Code = "MN", Name = "Minnesota", Number = 23},
                    new State {Code = "MS", Name = "Mississippi", Number = 24},
                    new State {Code = "MO", Name = "Missouri", Number = 25},
                    new State {Code = "MT", Name = "Montana", Number = 26},
                    new State {Code = "NE", Name = "Nebraska", Number = 27},
                    new State {Code = "NV", Name = "Nevada", Number = 28},
                    new State {Code = "NH", Name = "New Hampshire", Number = 29},
                    new State {Code = "NJ", Name = "New Jersey", Number = 30},
                    new State {Code = "NM", Name = "New Mexico", Number = 31},
                    new State {Code = "NY", Name = "New York", Number = 32},
                    new State {Code = "NC", Name = "North Carolina", Number = 33},
                    new State {Code = "ND", Name = "North Dakota", Number = 34},
                    new State {Code = "OH", Name = "Ohio", Number = 35},
                    new State {Code = "OK", Name = "Oklahoma", Number = 36},
                    new State {Code = "OR", Name = "Oregon", Number = 37},
                    new State {Code = "PA", Name = "Pennsylvania", Number = 38},
                    new State {Code = "RI", Name = "Rhode Island", Number = 39},
                    new State {Code = "SC", Name = "South Carolina", Number = 40},
                    new State {Code = "SD", Name = "South Dakota", Number = 41},
                    new State {Code = "TN", Name = "Tennessee", Number = 42},
                    new State {Code = "TX", Name = "Texas", Number = 43},
                    new State {Code = "UT", Name = "Utah", Number = 44},
                    new State {Code = "VT", Name = "Vermont", Number = 45},
                    new State {Code = "VA", Name = "Virginia", Number = 46},
                    new State {Code = "WA", Name = "Washington", Number = 47},
                    new State {Code = "WV", Name = "West Virginia", Number = 48},
                    new State {Code = "WI", Name = "Wisconsin", Number = 49},
                    new State {Code = "WY", Name = "Wyoming", Number = 50},

                    new State {Code = "AS", Name = "American Somoa", Number = 51},
                    new State {Code = "DC", Name = "District of Columbia", Number = 52},
                    new State {Code = "GU", Name = "Guam", Number = 53},
                    new State {Code = "PR", Name = "Puerto Rico", Number = 54},
                    new State {Code = "VI", Name = "Virgin Islands", Number = 55}
                };

            #endregion

            #region Addresses

            var addresses = new List<Address>
                {
                    new Address
                    {
                        City = "City View",
                        Line1 = "1202 Big Road",
                        Line2 = "",
                        State = states.ElementAt(42),
                        ZipCode = "75062"
                    },
                    new Address
                    {
                        City = "Holliday",
                        Line1 = "355 Main Streat",
                        Line2 = "",
                        State = states.ElementAt(42),
                        ZipCode = "75080"
                    }
                };

            #endregion addresses

            #region users

            var users = new List<Teacher>
                {
                    new Teacher
                    {
                        Email = "giddyup@gmail.com",
                        FirstName = "Chuck",
                        LastName = "Thompson",
                        UserProfilePermissionFlag = UserProfilePermissionFlag.All
                    },
                    new Teacher
                    {
                        Email = "kashleec@gmail.com",
                        FirstName = "Kash",
                        LastName = "Cummigns",
                        UserProfilePermissionFlag = UserProfilePermissionFlag.All
                    }
                };

            users.ForEach(u => u.SetPassword("enter"));

            #endregion users

            #region schools

            var schools = new List<School>
                {
                    new School()
                    {
                        Name = "Holliday High School",
                        Address = addresses.ElementAt(1),
                        Classification = Classification.AA,
                        Teachers = new List<Teacher> {users.ElementAt(1)},
                        Students = new List<Student>(),
                    },
                    new School()
                    {
                        Name = "CityView High School",
                        Address = addresses.ElementAt(0),
                        Classification = Classification.AA,
                        Teachers = new List<Teacher> {users.ElementAt(0)},
                        Students = new List<Student>(),
                    }
                };

            #endregion schools

            #region students

            var students = new List<Student>
                {
                    new Student
                    {
                        FirstName = "Carson",
                        LastName = "Alexander",
                        Grade = new Random().Next(9, 13),
                        School = schools.ElementAt(new Random().Next(0, 2)),
                    },
                    new Student
                    {
                        FirstName = "Meredith",
                        LastName = "Alonso",
                        Grade = new Random().Next(9, 13),
                        School = schools.ElementAt(new Random().Next(0, 2)),
                    },
                    new Student
                    {
                        FirstName = "Arturo",
                        LastName = "Anand",
                        Grade = new Random().Next(9, 13),
                        School = schools.ElementAt(new Random().Next(0, 2)),
                    },
                    new Student
                    {
                        FirstName = "Gytis",
                        LastName = "Barzdukas",
                        Grade = new Random().Next(9, 13),
                        School = schools.ElementAt(new Random().Next(0, 2)),
                    },
                    new Student
                    {
                        FirstName = "Yan",
                        LastName = "Li",
                        Grade = new Random().Next(9, 13),
                        School = schools.ElementAt(new Random().Next(0, 2)),
                    },
                    new Student
                    {
                        FirstName = "Peggy",
                        LastName = "Justice",
                        Grade = new Random().Next(9, 13),
                        School = schools.ElementAt(new Random().Next(0, 2)),
                    },
                    new Student
                    {
                        FirstName = "Laura",
                        LastName = "Norman",
                        Grade = new Random().Next(9, 13),
                        School = schools.ElementAt(new Random().Next(0, 2)),
                    },
                    new Student
                    {
                        FirstName = "Nino",
                        LastName = "Olivetto",
                        Grade = new Random().Next(9, 13),
                        School = schools.ElementAt(new Random().Next(0, 2)),
                    }
                };

            #endregion students

            #region events

            var events = new List<Event>
                {
                    new Event
                    {
                        Name = "Mathematics",
                        Nickname = "Math",
                        EventType = EventType.HasTeam | EventType.IsScored,
                        IndividualAdvancingCount = 3,
                        IndividualMedalCount = 6,
                        NumberOfRounds = 1,
                        TeamAdvancingCount = 1,
                        TeamMedalCount = 2,
                        TestLength = new TimeSpan(0, 30, 0)
                    },
                    new Event
                    {
                        Name = "Number Sense",
                        Nickname = "NS",
                        EventType = EventType.HasTeam | EventType.IsScored,
                        IndividualAdvancingCount = 3,
                        IndividualMedalCount = 6,
                        NumberOfRounds = 1,
                        TeamAdvancingCount = 1,
                        TeamMedalCount = 2,
                        TestLength = new TimeSpan(0, 30, 0)
                    },
                    new Event
                    {
                        Name = "Calculator Skills",
                        Nickname = "Calc",
                        EventType = EventType.HasTeam | EventType.IsScored,
                        IndividualAdvancingCount = 3,
                        IndividualMedalCount = 6,
                        NumberOfRounds = 1,
                        TeamAdvancingCount = 1,
                        TeamMedalCount = 2,
                        TestLength = new TimeSpan(0, 30, 0)
                    }
                };

            #endregion events

            #region meet


            if (System.Diagnostics.Debugger.IsAttached == false)
                System.Diagnostics.Debugger.Launch();


            var meet = new Meet
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(5),
                MeetEvents = events.Select(e =>
                {
                    var z = new MeetEvent
                    {
                        Event = e,
                        EventStudents = students.Select(o =>
                        {
                            var x = new EventStudent
                            {
                                Student = o,
                                Score = null,
                                ObjectState = ObjectState.Added,
                            };
                            return x;
                        }).ToList(),
                        ObjectState = ObjectState.Added
                    };
                    return z;
                }).ToList(),
                HostSchool = schools.ElementAt(0),
                CompetingSchools = schools.Select(s =>
                {
                    var x = new MeetSchool
                    {
                        School = s,
                        ObjectState = ObjectState.Added,
                    };
                    return x;
                }).ToList(),
            };

            #endregion meet



            states.ForEach(o =>
            {
                o.ObjectState = ObjectState.Added;
                context.States.Add(o);
            });
            addresses.ForEach(s =>
            {
                s.ObjectState = ObjectState.Added;
                context.Addresses.Add(s);
            });
            users.ForEach(s =>
            {
                s.ObjectState = ObjectState.Added;
                context.UserProfiles.Add(s);
            });
            schools.ForEach(s =>
            {
                s.ObjectState = ObjectState.Added;
                context.Schools.Add(s);
            });
            students.ForEach(s =>
            {
                s.ObjectState = ObjectState.Added;
                context.Students.Add(s);
            });
            events.ForEach(s =>
            {
                s.ObjectState = ObjectState.Added;
                context.Events.Add(s);
            });
            meet.ObjectState = ObjectState.Added;
            context.Meets.Add(meet);

            context.SaveChanges();


        }
    }
}
