using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UILHost.Common;
using UILHost.Infrastructure.Data.Operational;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Data.Operational
{
    internal class OperationalDataContextInitializer :
        System.Data.Entity.DropCreateDatabaseIfModelChanges<OperationalDataContext>
    {
        protected override void Seed(OperationalDataContext context)
        {
            #region states
            var states = new List<State>
            {
                new State { StateCode = "AL", StateName = "Alabama", StateNum =1 },
                new State { StateCode = "AK", StateName = "Alaska", StateNum =2 },
                new State { StateCode = "AZ", StateName = "Arizona", StateNum =3 },
                new State { StateCode = "AR", StateName = "Arkansas", StateNum =4 },
                new State { StateCode = "CA", StateName = "California", StateNum =5 },
                new State { StateCode = "CO", StateName = "Colorado", StateNum =6 },
                new State { StateCode = "CT", StateName = "Connecticut", StateNum =7 },
                new State { StateCode = "DE", StateName = "Delaware", StateNum =8 },
                new State { StateCode = "FL", StateName = "Florida", StateNum =9 },
                new State { StateCode = "GA", StateName = "Georgia", StateNum =10 },
                new State { StateCode = "HI", StateName = "Hawaii", StateNum =11 },
                new State { StateCode = "ID", StateName = "Idaho", StateNum =12 },
                new State { StateCode = "IL", StateName = "Illinois", StateNum =13 },
                new State { StateCode = "IN", StateName = "Indiana", StateNum =14 },
                new State { StateCode = "IA", StateName = "Iowa", StateNum =15 },
                new State { StateCode = "KS", StateName = "Kansas", StateNum =16 },
                new State { StateCode = "KY", StateName = "Kentucky", StateNum =17 },
                new State { StateCode = "LA", StateName = "Louisiana", StateNum =18 },
                new State { StateCode = "ME", StateName = "Maine", StateNum =19 },
                new State { StateCode = "MD", StateName = "Maryland", StateNum =20 },
                new State { StateCode = "MA", StateName = "Massachusetts", StateNum =21 },
                new State { StateCode = "MI", StateName = "Michigan", StateNum =22 },
                new State { StateCode = "MN", StateName = "Minnesota", StateNum =23 },
                new State { StateCode = "MS", StateName = "Mississippi", StateNum =24 },
                new State { StateCode = "MO", StateName = "Missouri", StateNum =25 },
                new State { StateCode = "MT", StateName = "Montana", StateNum =26 },
                new State { StateCode = "NE", StateName = "Nebraska", StateNum =27 },
                new State { StateCode = "NV", StateName = "Nevada", StateNum =28 },
                new State { StateCode = "NH", StateName = "New Hampshire", StateNum =29 },
                new State { StateCode = "NJ", StateName = "New Jersey", StateNum =30 },
                new State { StateCode = "NM", StateName = "New Mexico", StateNum =31 },
                new State { StateCode = "NY", StateName = "New York", StateNum =32 },
                new State { StateCode = "NC", StateName = "North Carolina", StateNum =33 },
                new State { StateCode = "ND", StateName = "North Dakota", StateNum =34 },
                new State { StateCode = "OH", StateName = "Ohio", StateNum =35 },
                new State { StateCode = "OK", StateName = "Oklahoma", StateNum =36 },
                new State { StateCode = "OR", StateName = "Oregon", StateNum =37 },
                new State { StateCode = "PA", StateName = "Pennsylvania", StateNum =38 },
                new State { StateCode = "RI", StateName = "Rhode Island", StateNum =39 },
                new State { StateCode = "SC", StateName = "South Carolina", StateNum =40 },
                new State { StateCode = "SD", StateName = "South Dakota", StateNum =41 },
                new State { StateCode = "TN", StateName = "Tennessee", StateNum =42 },
                new State { StateCode = "TX", StateName = "Texas", StateNum =43 },
                new State { StateCode = "UT", StateName = "Utah", StateNum =44 },
                new State { StateCode = "VT", StateName = "Vermont", StateNum =45 },
                new State { StateCode = "VA", StateName = "Virginia", StateNum =46 },
                new State { StateCode = "WA", StateName = "Washington", StateNum =47 },
                new State { StateCode = "WV", StateName = "West Virginia", StateNum =48 },
                new State { StateCode = "WI", StateName = "Wisconsin", StateNum =49 },
                new State { StateCode = "WY", StateName = "Wyoming", StateNum =50 },

                new State { StateCode = "AS", StateName = "American Somoa", StateNum =51 },
                new State { StateCode = "DC", StateName = "District of Columbia", StateNum =52 },
                new State { StateCode = "GU", StateName = "Guam", StateNum =53 },
                new State { StateCode = "PR", StateName = "Puerto Rico", StateNum =54 },
                new State { StateCode = "VI", StateName = "Virgin Islands", StateNum =55 }
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

            var users = new List<UserProfile>
            {
                new UserProfile
                {
                    Email = "giddyup@gmail.com",
                    FirstName = "Chuck",
                    LastName = "Thompson",
                    UserProfilePermissionFlag = UserProfilePermissionFlag.All
                },
                new UserProfile
                {
                    Email = "kashleec@gmail.com",
                    FirstName = "Kash",
                    LastName = "Cummigns",
                    UserProfilePermissionFlag = UserProfilePermissionFlag.All
                }
            };

            #endregion users

            #region schools

            var schools = new List<School>
            {
                new School()
                {
                    Name = "Holliday High School",
                    Address = addresses.ElementAt(1),
                    Classification = Classification.AA,
                    MeetLeader = users.ElementAt(1),
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
                new Student {
                    FirstName = "Yan", 
                    LastName = "Li", 
                    Grade = new Random().Next(9, 13),
                    School = schools.ElementAt(new Random().Next(0, 2)),},
                new Student
                {
                    FirstName = "Peggy",
                    LastName = "Justice",
                    Grade = new Random().Next(9, 13),
                    School = schools.ElementAt(new Random().Next(0, 2)),
                },
                new Student {
                    FirstName = "Laura", 
                    LastName = "Norman", 
                    Grade = new Random().Next(9, 13),
                    School = schools.ElementAt(new Random().Next(0, 2)),},
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

            var meet = new Meet
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(5),
                Events = events.Select(e => new MeetEvent
                {
                    Event = e,
                    Students = students.Select(o => new EventStudent
                    {
                        Student = o,
                        Event = e,
                        Score = null,
                    }).ToList(),

                }).ToList(),
                HostSchool = schools.ElementAt(0),
                Schools = schools,
                Students = students,
            };

            #endregion meet

            states.ForEach(o => context.States.Add(o));
            addresses.ForEach(s => context.Addresses.Add(s));
            users.ForEach(s => context.UserProfiles.Add(s));
            schools.ForEach(s => context.Schools.Add(s));
            students.ForEach(s => context.Students.Add(s));
            events.ForEach(s => context.Events.Add(s));
            context.Meets.Add(meet);

            context.SaveChanges();
        }
    }
}
