using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILHost.Common
{
    public static class TraceLoggers
    {
        public static void LogExecutionTime(Action action, string message)
        {

#if DEBUG

            var stopWatch = new Stopwatch();

            stopWatch.Start();
            action();
            stopWatch.Stop();

            Trace.WriteLine(string.Format("[EXECUTION TIME] {0} :: {1}", message, stopWatch.Elapsed.TotalSeconds));

#else
            action();
#endif

        }
    }
}
