using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILHost.Infrastructure.Domain;

namespace UILHost.Infrastructure.Domain
{
    public enum Classification : long
    {
        Undefined = 0,
        A = 1 << 0,
        AA = 1 << 1,
        AAA = 1 << 2,
        AAAA = 1 << 3,
        AAAAA = 1 << 4,

        SmallSchool = A + AA + AAA,
        BigSchool = AAAA + AAAAA,

    }

    public class School
    {
        public string Name { get; set; }
        public Classification Classification { get; set; }
        public string S { get; set; }

    }
}
