using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UILHost.Common.PayrollApplication
{
    public enum ReportItemType : int
    {
        Undefined = 0,
        Standard = 1,
        TaxReport = 2,
        DataFile = 4
    }


    public interface IReportItem
    {
        ReportItemType ItemType { get; }
        PAMLocation Location { get; }
        int ClientId { get; }
        ReportType ReportType { get; }
        DateTime CheckDate { get; }
        string Arg1 { get; }
        string Arg2 { get; }
    }
}
