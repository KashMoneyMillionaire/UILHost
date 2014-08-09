using System;

namespace UILHost.Common
{
    public enum BooleanCode
    {
        Undefined = 0,
        Yes = 1,
        No = 2
    }

    [Flags]
    public enum Classification : long
    {
        Undefined = 0,
        
        A = 1,
        AA = 2,
        AAA = 3,
        AAAA = 4,
        AAAAA = 5,
        AAAAAA = 6,

        SmallSchool = A+AA+AAA,
        BigSchool = AAAA + AAAAA + AAAAAA
    }
}
