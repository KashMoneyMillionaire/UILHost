using System;
using UILHost.Infrastructure.Entity;

namespace UILHost.Infrastructure.Domain
{
    [Flags]
    public enum EventType : long
    {
        Undefined = 0,
        IsScored = 1 << 0,
        HasTeam = 1 << 1,
        IsBracketStyle = 1 << 2,
    }
    public class Event : EntityBase<long>
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public EventType EventType { get; set; }
        public TimeSpan TestLength { get; set; }
        public int NumberOfRounds { get; set; }

        public int IndividualMedalCount { get; set; }
        public int TeamMedalCount { get; set; }
        public int IndividualAdvancingCount { get; set; }
        public int TeamAdvancingCount { get; set; }

    }
}
