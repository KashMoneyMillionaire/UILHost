using System;
using System.Diagnostics;
using System.Text;

namespace UILHost.Common.Logging.System
{
    public static class ApplicationLog
    {
        private const string LOG = "Application";

        public static void WriteEventLog(string source, EventLogEntryType entryType, string message)
        {
            try
            {
                if (!EventLog.SourceExists(source))
                    EventLog.CreateEventSource(source, LOG);
                EventLog.WriteEntry(source, message, entryType);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch { /* do nothing */ }
        }

        public static void WriteEventLog(string source, string message, Exception error)
        {
            try
            {
                if (!EventLog.SourceExists(source))
                    EventLog.CreateEventSource(source, LOG);
                StringBuilder stringBuilder = new StringBuilder(message);
                stringBuilder.Append(" :: ");
                stringBuilder.AppendLine(error.Message);
                stringBuilder.AppendLine(error.StackTrace);
                EventLog.WriteEntry(source, ((object)stringBuilder).ToString(), EventLogEntryType.Error);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch { /* do nothing */}
        }
    }

}
