using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILHost.Common.PayrollApplication
{
    public enum ReportResponseFileType
    {
        /// <summary>
        /// Performs the default file processing on the original file.
        /// Currently, this only applies to PCLs, which will be converted to PDF if this enum is present.
        /// The default for all other file types is the same as original - the original file is returned.
        /// </summary>
        Default,

        /// <summary>
        /// Returns the original file as dropped by PAM
        /// </summary>
        Original
    }

    public interface IPayrollApplicationReportingService
    {
        FileStream ExecuteStandardAndTaxReportRequest(
            PayrollApplicationReportingMessageType messageType,
            IReportItem report,
            ReportResponseFileType fileType,
            out string fileExtension);

        FileStream ExecuteOnDemandReportRequest(
            PayrollApplicationReportingMessageType messageType,
            PAMLocation location,
            int clientId,
            DateTime beginDate,
            DateTime endDate,
            ReportType reportType,
            string parameters,
            string[] employeeNums,
            out string fileExtension);

        Task<List<IReportItem>> ExecuteStandardAndTaxReportListingRequest(
            PAMLocation location,
            int clientId,
            DateTime? startDate = null,
            DateTime? endDate = null);
    }
}
