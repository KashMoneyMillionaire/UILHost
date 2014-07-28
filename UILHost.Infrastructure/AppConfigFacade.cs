using System;
using System.Configuration;

namespace UILHost.Infrastructure
{
    public static class AppConfigFacade
    {
        //private const string KEY_LAST_BAD_LOGIN_TIME_PERIOD_THRESHOLD = "UILHost.LastBadLoginTimePeriodThreshold";
        //private const string DEFAULT_LAST_BAD_LOGIN_TIME_PERIOD_THRESHOLD = "3600000"; // 1 hour

        //private const string KEY_LAST_BAD_LOGIN_ATTEMPTS_THRESHOLD = "UILHost.LastBadLoginAttemptsThreshold";
        //private const string DEFAULT_LAST_BAD_LOGIN_ATTEMPTS_THRESHOLD = "3";

        //private const string KEY_REPORT_LISTING_REQUEST_CACHE_EXPIRATION = "UILHost.LastBadLoginAttemptsThreshold";
        //private const string DEFAULT_REPORT_LISTING_REQUEST_CACHE_EXPIRATION = "900000"; 

        //private const string KEY_FORGOT_PASSWORD_REQUEST_TOKEN_EXPIRATION = "UILHost.ForgotPasswordRequestTokenExpiration";
        //private const string DEFAULT_FORGOT_PASSWORD_REQUEST_TOKEN_EXPIRATION = "21600000"; //6 hours

        //private const string KEY_PASSWORD_VALIDATION_REGEX = "UILHost.PasswordValidationRegex";
        //private const string DEFAULT_PASSWORD_VALIDATION_REGEX = @"(?(.*[0-9]+.*)(?(.*[A-Z]+.*)(?(^[a-zA-Z0-9]{8,20}$)(.*)|([^\W\w]+))|([^\W\w]+))|([^\W\w]+))"; //added the 20 for 8-20

        //private const string KEY_PASSWORD_VALIDATION_ERROR_MESSAGE = "UILHost.PasswordValidationErrorMessage";
        //private const string DEFAULT_PASSWORD_VALIDATION_ERROR_MESSAGE = "Password must be between 8 and 20 characters, alphanumeric, and contain at least 1 uppercase letter";

        //private const string KEY_SERVICE_BUS_HOST = "UILHost.ServiceBusHost";
        //private const string KEY_SERVICE_BUS_NAMESPACE = "UILHost.ServiceBusNamespace";
        //private const string KEY_SERVICE_BUS_MANAGEMENT_PORT = "UILHost.ServiceBusManagementPort";
        //private const string KEY_SERVICE_BUS_RUNTIME_PORT = "UILHost.ServiceBusRuntimePort";
        //private const string KEY_SERVICE_BUS_ISSUER_NAME = "UILHost.ServiceBusIssuerName";
        //private const string KEY_SERVICE_BUS_ISSUER_SECRET = "UILHost.ServiceBusIssuerSecret";



        //private const string KEY_SMTP_HOST = "UILHost.SmtpHost";
        //private const string DEFAULT_SMTP_HOST = "localhost";

        //private const string KEY_SMTP_PORT = "UILHost.SmtpPort";
        //private const string DEFAULT_SMTP_PORT = "25";

        //private const string KEY_SYSTEM_EMAIL_FROM = "UILHost.SystemEmailFrom";
        //private const string DEFAULT_SYSTEM_EMAIL_FROM = "pavlos@UILHost.com";

        //private const string KEY_PAYROLL_INTEGRATION_REPORTING_REQUEST_QUEUE_NAME = "UILHost.PayrollIntegrationReportingRequestQueueName";
        //private const string DEFAULT_PAYROLL_INTEGRATION_REPORTING_REQUEST_QUEUE_NAME = "PayrollIntegrationReportingRequestQueue";

        //private const string KEY_PAYROLL_INTEGRATION_REPORTING_RESPONSE_QUEUE_NAME = "UILHost.PayrollIntegrationReportingResponseQueueName";
        //private const string DEFAULT_PAYROLL_INTEGRATION_REPORTING_RESPONSE_QUEUE_NAME = "PayrollIntegrationReportingResponseQueue";

        //private const string KEY_DATA_REFRESH_POLLING_REQUEST_QUEUE_NAME = "UILHost.DataRefreshPollingRequestQueueName";
        //private const string DEFAULT_DATA_REFRESH_POLLING_REQUEST_QUEUE_NAME = "DataRefreshPollingRequestQueue";

        //private const string KEY_EMAIL_SEND_REQUEST_QUEUE_NAME = "UILHost.EmailSendRequestQueueName";
        //private const string DEFAULT_EMAIL_SEND_REQUEST_QUEUE_NAME = "EmailSendRequestQueue";

        //private const string KEY_PAYROLL_APP_PORT = "UILHost.PayrollAppPort";
        //private const string DEFAULT_PAYROLL_APP_PORT = "22";

        //private const string KEY_PAYROLL_APP_HOST = "UILHost.PayrollAppHost";

        //private const string KEY_PAYROLL_APP_USERNAME = "UILHost.PayrollAppUsername";

        //private const string KEY_PAYROLL_APP_PASSWORD = "UILHost.PayrollAppPassword";

        //private const string KEY_PAYROLL_APP_REPORTING_PIPE_INDEXES = "UILHost.PayrollAppReportingPipeIndexes";
        //private const string DEFAULT_PAYROLL_APP_REPORTING_PIPE_INDEXES = "1-5";

        //private const string KEY_PAYROLL_APP_NUM_PIPES_PER_CONNECTION = "UILHost.NumberOfShellsPerPayrollAppPipe";
        //private const string DEFAULT_PAYROLL_APP_NUM_PIPES_PER_CONNECTION = "3";

        //private const string KEY_PAYROLL_APP_SERVER_PIPE_PATH_FORMAT = "UILHost.PayrollAppServerPipePathFormat";
        //private const string DEFAULT_PAYROLL_APP_SERVER_PIPE_PATH_FORMAT = "/home/ashtst/payroll/pipes/web{0}.np";

        //private const string KEY_PAYROLL_APP_CLIENT_PIPE_PATH_FORMAT = "UILHost.PayrollAppClientPipePathFormat";
        //private const string DEFAULT_PAYROLL_APP_CLIENT_PIPE_PATH_FORMAT = "/home/ashtst/payroll/pipes/wec{0}.np";

        //private const string KEY_PAYROLL_APP_SHELL_PROMPT = "UILHost.PayrollAppShellPrompt";
        //private const string DEFAULT_PAYROLL_APP_SHELL_PROMPT = "pammiad01-> ";

        //private const string KEY_PAYROLL_APP_REMOTE_REFRESH_PATH = "UILHost.PayrollAppRemoteRefreshPath";
        //private const string DEFAULT_PAYROLL_APP_REMOTE_REFRESH_PATH = "/home/ashtst/payroll/updates";

        //private const string KEY_PAYROLL_APP_PIPE_PROCESS_NAME_FORMAT = "UILHost.PipeProcessNameFormat";
        //private const string DEFAULT_PAYROLL_APP_PIPE_PROCESS_NAME_FORMAT = "web{0}";

        //private const string KEY_PAYROLL_APP_INTEGRATION_MAX_ATTEMPTS = "UILHost.PayrollAppIntegrationMaxAttempts";
        //private const string DEFAULT_PAYROLL_APP_INTEGRATION_MAX_ATTEMPTS = "5";

        //private const string KEY_PAYROLL_APP_DOWNLOADS_DIRECTORY = "UILHost.PayrollAppDownloadsDirectory";
        //private static readonly string DEFAULT_PAYROLL_APP_DOWNLOADS_DIRECTORY = string.Format("{0}\\{1}",
        //    Path.GetTempPath().Trim().TrimEnd('\\'),
        //    "PavlosPayrollDownloads");

        //private const string KEY_PAYROLL_APP_QUARANTINE_DOWNLOADS_DIRECTORY = "UILHost.PayrollAppQuarantineDownloadsDirectory";
        //private static readonly string DEFAULT_PAYROLL_APP_QUARANTINE_DOWNLOADS_DIRECTORY = string.Format("{0}\\{1}",
        //    Path.GetTempPath().Trim().TrimEnd('\\'),
        //    "PavlosPayrollQuarantineDownloads");

        //private const string KEY_PAYROLL_APP_PCL_DIRECTORY = "UILHost.PayrollAppRemotePclDirectory";
        //private const string DEFAULT_PAYROLL_APP_PCL_DIRECTORY = "/home/ashtst/payroll/pcl";

        //private const string KEY_PAYROLL_APP_PIPE_REQUEST_WRITE_TIMEOUT = "UILHost.PayrollAppPipeRequestWriteTimeout";
        //private const string DEFAULT_PAYROLL_APP_PIPE_REQUEST_WRITE_TIMEOUT = "10000";

        //private const string KEY_PAYROLL_APP_REPORT_LISTING_REQUEST_TIMEOUT = "UILHost.PayrollAppReportListingRequestTimeout";
        //private const string DEFAULT_PAYROLL_APP_REPORT_LISTING_REQUEST_TIMEOUT = "30000";

        //private const string KEY_PAYROLL_APP_REPORT_REQUEST_TIMEOUT = "UILHost.PayrollAppReportRequestTimeout";
        //private const string DEFAULT_PAYROLL_APP_REPORT_REQUEST_TIMEOUT = "30000";

        //private const string KEY_PAYROLL_APP_PAYROLL_PROCESSING_REQUEST_TIMEOUT = "UILHost.PayrollAppPayrollProcessingRequestTimeout";
        //private const string DEFAULT_PAYROLL_APP_PAYROLL_PROCESSING_REQUEST_TIMEOUT = "20000";

        //private const string KEY_MINIMUM_PAYROLL_APP_REQUEST_ID = "UILHost.MinimumPayrollAppRequestId";
        //private const string DEFAULT_MINIMUM_PAYROLL_APP_REQUEST_ID = "1";

        //private const string KEY_MAXIMUM_PAYROLL_APP_REQUEST_ID = "UILHost.MaximumPayrollAppRequestId";
        //private const string DEFAULT_MAXIMUM_PAYROLL_APP_REQUEST_ID = "999999999";

        //private const string KEY_PCL_TO_PDF_CONVERTER_EXE_PATH = "UILHost.PclToPdfConverterExePath";

        //private const string KEY_PAYROLL_APP_STORE_REQUEST_ID_IN_DATABASE = "UILHost.StorePayrollAppRequestIdInDatabase";
        //private const string DEFAULT_PAYROLL_APP_STORE_REQUEST_ID_IN_DATABASE = "false";

        //private const string KEY_EMAIL_TEMPLATES_PATH = "UILHost.EmailTemplatesPath";
        //private const string DEFAULT_EMAIL_TEMPLATES_PATH = "/emailtemplates";


        //private const string KEY_CSR_USERNAME_DOMAIN = "UILHost.CsrUsernameDomain";
        //private const string DEFAULT_CSR_USERNAME_DOMAIN = "UILHost.com";

        //private const string KEY_TAX_RETURN_REPORT_CHECK_DATE_YEAR = "UILHost.TaxReturnReportCheckDateYear";
        //private const string DEFAULT_TAX_RETURN_REPORT_CHECK_DATE_YEAR = "1970";

        //private const string KEY_EMPTY_PROFILE_PICTURE_URL = "UILHost.EmptyProfilePictureUrl";
        //private const string DEFAULT_EMPTY_PROFILE_PICTURE_URL = "/img/emptyProfilePicture.png";


        //public static ConnectionStringSettings OperationalDataContextConnectionString { get { return GetConnectionString(Constants.DefaultConnectionStringName); } }

        //public static int LastBadLoginTimePeriodThreshold { get { return GetInt(KEY_LAST_BAD_LOGIN_TIME_PERIOD_THRESHOLD, DEFAULT_LAST_BAD_LOGIN_TIME_PERIOD_THRESHOLD).GetValueOrDefault(); } }
        //public static int LastBadLoginAttemptsThreshold { get { return GetInt(KEY_LAST_BAD_LOGIN_ATTEMPTS_THRESHOLD, DEFAULT_LAST_BAD_LOGIN_ATTEMPTS_THRESHOLD).GetValueOrDefault(); } }
        //public static int ReportListingRequestChacheExpiration { get { return GetInt(KEY_REPORT_LISTING_REQUEST_CACHE_EXPIRATION, DEFAULT_REPORT_LISTING_REQUEST_CACHE_EXPIRATION).GetValueOrDefault(); } }
        //public static int ForgotPasswordRequestTokenExpiration { get { return GetInt(KEY_FORGOT_PASSWORD_REQUEST_TOKEN_EXPIRATION, DEFAULT_FORGOT_PASSWORD_REQUEST_TOKEN_EXPIRATION).GetValueOrDefault(); } }
        //public static string PasswordValidationRegex { get { return GetString(KEY_PASSWORD_VALIDATION_REGEX, DEFAULT_PASSWORD_VALIDATION_REGEX); } }
        //public static string PasswordValidationeErrorMessage { get { return GetString(KEY_PASSWORD_VALIDATION_ERROR_MESSAGE, DEFAULT_PASSWORD_VALIDATION_ERROR_MESSAGE); } }

        //public static string ServiceBusHost { get { return GetString(KEY_SERVICE_BUS_HOST); } }
        //public static string ServiceBusNamespace { get { return GetString(KEY_SERVICE_BUS_NAMESPACE, string.Empty); } }
        //public static int? ServiceBusManagementPort { get { return GetInt(KEY_SERVICE_BUS_MANAGEMENT_PORT); } }
        //public static int? ServiceBusRuntimePort { get { return GetInt(KEY_SERVICE_BUS_RUNTIME_PORT); } }
        //public static string ServiceBusIssuerName { get { return GetString(KEY_SERVICE_BUS_ISSUER_NAME); } }
        //public static string ServiceBusIssuerSecret { get { return GetString(KEY_SERVICE_BUS_ISSUER_SECRET); } }


        //public static string SmtpHost { get { return GetString(KEY_SMTP_HOST, DEFAULT_SMTP_HOST); } }
        //public static int SmtpPort { get { return GetInt(KEY_SMTP_PORT, DEFAULT_SMTP_PORT).GetValueOrDefault(); } }
        //public static string SystemEmailFrom { get { return GetString(KEY_SYSTEM_EMAIL_FROM, DEFAULT_SYSTEM_EMAIL_FROM); } }

        //public static string PayrollAppReportingRequestQueueName { get { return GetServiceBusQueueName(KEY_PAYROLL_INTEGRATION_REPORTING_REQUEST_QUEUE_NAME, DEFAULT_PAYROLL_INTEGRATION_REPORTING_REQUEST_QUEUE_NAME); } }
        //public static string PayrollAppReportingResponseQueueName { get { return GetServiceBusQueueName(KEY_PAYROLL_INTEGRATION_REPORTING_RESPONSE_QUEUE_NAME, DEFAULT_PAYROLL_INTEGRATION_REPORTING_RESPONSE_QUEUE_NAME); } }
        //public static string DataRefreshPollingRequestQueueName { get { return GetServiceBusQueueName(KEY_DATA_REFRESH_POLLING_REQUEST_QUEUE_NAME, DEFAULT_DATA_REFRESH_POLLING_REQUEST_QUEUE_NAME); } }
        //public static string EmailSendRequestQueueName { get { return GetServiceBusQueueName(KEY_EMAIL_SEND_REQUEST_QUEUE_NAME, DEFAULT_EMAIL_SEND_REQUEST_QUEUE_NAME); } }

        //public static string PayrollAppHost { get { return GetString(KEY_PAYROLL_APP_HOST); } }
        //public static int PayrollAppPort { get { return GetInt(KEY_PAYROLL_APP_PORT, DEFAULT_PAYROLL_APP_PORT).GetValueOrDefault(); } }
        //public static string PayrollAppUsername { get { return GetString(KEY_PAYROLL_APP_USERNAME); } }
        //public static string PayrollAppPassword { get { return GetString(KEY_PAYROLL_APP_PASSWORD); } }
        //public static int[] PayrollAppReportingPipeIndexes { get { return GetIntArray(KEY_PAYROLL_APP_REPORTING_PIPE_INDEXES, DEFAULT_PAYROLL_APP_REPORTING_PIPE_INDEXES); } }
        //public static int PayrollAppNumPipesPerConnection { get { return GetInt(KEY_PAYROLL_APP_NUM_PIPES_PER_CONNECTION, DEFAULT_PAYROLL_APP_NUM_PIPES_PER_CONNECTION).GetValueOrDefault(); } }
        //public static string PayrollAppServerPipePathFormat { get { return GetString(KEY_PAYROLL_APP_SERVER_PIPE_PATH_FORMAT, DEFAULT_PAYROLL_APP_SERVER_PIPE_PATH_FORMAT); } }
        //public static string PayrollAppClientPipePathFormat { get { return GetString(KEY_PAYROLL_APP_CLIENT_PIPE_PATH_FORMAT, DEFAULT_PAYROLL_APP_CLIENT_PIPE_PATH_FORMAT); } }
        //public static string PayrollAppShellPrompt { get { return GetString(KEY_PAYROLL_APP_SHELL_PROMPT, DEFAULT_PAYROLL_APP_SHELL_PROMPT); } }
        //public static string PayrollAppRemoteRefreshPath { get { return GetString(KEY_PAYROLL_APP_REMOTE_REFRESH_PATH, DEFAULT_PAYROLL_APP_REMOTE_REFRESH_PATH); } }
        //public static int PayrollAppIntegrationMaxAttempts { get { return GetInt(KEY_PAYROLL_APP_INTEGRATION_MAX_ATTEMPTS, DEFAULT_PAYROLL_APP_INTEGRATION_MAX_ATTEMPTS).GetValueOrDefault(); } }
        //public static string PayrollAppPipeProcessNameFormat { get { return GetString(KEY_PAYROLL_APP_PIPE_PROCESS_NAME_FORMAT, DEFAULT_PAYROLL_APP_PIPE_PROCESS_NAME_FORMAT); } }
        //public static string PayrollAppDownloadsDirectory { get { return GetString(KEY_PAYROLL_APP_DOWNLOADS_DIRECTORY, DEFAULT_PAYROLL_APP_DOWNLOADS_DIRECTORY); } }
        //public static string PayrollAppQuarantineDownloadsDirectory { get { return GetString(KEY_PAYROLL_APP_QUARANTINE_DOWNLOADS_DIRECTORY, DEFAULT_PAYROLL_APP_QUARANTINE_DOWNLOADS_DIRECTORY); } }
        //public static string PayrollAppRemotePclDirectory { get { return GetString(KEY_PAYROLL_APP_PCL_DIRECTORY, DEFAULT_PAYROLL_APP_PCL_DIRECTORY); } }
        //public static int PayrollAppPipeRequestWriteTimeout { get { return GetInt(KEY_PAYROLL_APP_PIPE_REQUEST_WRITE_TIMEOUT, DEFAULT_PAYROLL_APP_PIPE_REQUEST_WRITE_TIMEOUT).GetValueOrDefault(); } }
        //public static int PayrollAppReportListingRequestTimeout { get { return GetInt(KEY_PAYROLL_APP_REPORT_LISTING_REQUEST_TIMEOUT, DEFAULT_PAYROLL_APP_REPORT_LISTING_REQUEST_TIMEOUT).GetValueOrDefault(); } }
        //public static int PayrollAppReportRequestTimeout { get { return GetInt(KEY_PAYROLL_APP_REPORT_REQUEST_TIMEOUT, DEFAULT_PAYROLL_APP_REPORT_REQUEST_TIMEOUT).GetValueOrDefault(); } }
        //public static int PayrollAppPayrollProcessingRequestTimeout { get { return GetInt(KEY_PAYROLL_APP_PAYROLL_PROCESSING_REQUEST_TIMEOUT, DEFAULT_PAYROLL_APP_PAYROLL_PROCESSING_REQUEST_TIMEOUT).GetValueOrDefault(); } }

        //public static string EmailTemplatesPath { get { return GetString(KEY_EMAIL_TEMPLATES_PATH, DEFAULT_EMAIL_TEMPLATES_PATH); } }

        //public static int PayrollAppMinimumRequestId { get { return GetInt(KEY_MINIMUM_PAYROLL_APP_REQUEST_ID, DEFAULT_MINIMUM_PAYROLL_APP_REQUEST_ID).GetValueOrDefault(); } }
        //public static int PayrollAppMaximumRequestId { get { return GetInt(KEY_MAXIMUM_PAYROLL_APP_REQUEST_ID, DEFAULT_MAXIMUM_PAYROLL_APP_REQUEST_ID).GetValueOrDefault(); } }

        //public static string PclToPdfConverterFilePath { get { return GetString(KEY_PCL_TO_PDF_CONVERTER_EXE_PATH); } }

        //public static bool StorePayrollAppRequestIdInDatabase { get { return GetBool(KEY_PAYROLL_APP_STORE_REQUEST_ID_IN_DATABASE, DEFAULT_PAYROLL_APP_STORE_REQUEST_ID_IN_DATABASE); } }


        //public static string CsrUsernameDomain { get { return GetString(KEY_CSR_USERNAME_DOMAIN, DEFAULT_CSR_USERNAME_DOMAIN); } }

        //public static int TaxReturnReportCheckDateYear { get { return GetInt(KEY_TAX_RETURN_REPORT_CHECK_DATE_YEAR, DEFAULT_TAX_RETURN_REPORT_CHECK_DATE_YEAR).GetValueOrDefault(); } }

        //public static string EmptyProfilePictureUrl { get { return GetString(KEY_EMPTY_PROFILE_PICTURE_URL, DEFAULT_EMPTY_PROFILE_PICTURE_URL); } }




        private const string KEY_WEB_PORTAL_URL_ROOT = "UILHost.WebPortalUrlRoot";
        public static string WebPortalRootUrl { get { return GetString(KEY_WEB_PORTAL_URL_ROOT); } }

        private const string KEY_ENABLE_EF_AUTODETECTCHANGES = "UILHost.EnableEfAutoDetectChanges";
        private const string DEFAULT_ENABLE_EF_AUTODETECTCHANGES = "true";
        public static bool EnableEfAutoDetectChanges { get { return GetBool(KEY_ENABLE_EF_AUTODETECTCHANGES, DEFAULT_ENABLE_EF_AUTODETECTCHANGES); } }

        private const string KEY_DO_CHANGE_DATA_CAPTURE = "UILHost.DoChangeDataCapture";
        private const string DEFAULT_DO_CHANGE_DATA_CAPTURE = "true";
        public static bool DoChangeDataCapture { get { return GetBool(KEY_DO_CHANGE_DATA_CAPTURE, DEFAULT_DO_CHANGE_DATA_CAPTURE); } }

        #region HELPERS

        private static int[] GetIntArray(string key, string defaultValue = null) { return ValueParsingUtil.ParseIntArray(GetString(key, defaultValue)); }
        private static int? GetInt(string key, string defaultValue = null) { return ValueParsingUtil.ParseInt(GetString(key), defaultValue); }
        private static bool GetBool(string key, string defaultValue = null) { return ValueParsingUtil.ParseBool(GetString(key), defaultValue); }
        private static DateTime GetDateTime(string key, string defaultValue = null) { return ValueParsingUtil.ParseDateTime(GetString(key), defaultValue); }
        private static string GetString(string key, string defaultValue = null)
        {
            var value = ConfigurationManager.AppSettings.Get(key);
            return value ?? defaultValue;
        }

        private static string GetServiceBusQueueName(string key, string defaultValue = null)
        {
            var queueName = GetString(key, defaultValue);
#if DEBUG
            queueName = string.Format("{0}-{1}", queueName, Environment.GetEnvironmentVariable("USERNAME"));
#endif
            return queueName;
        }

        private static ConnectionStringSettings GetConnectionString(string key)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[key];
            if (connectionString == null)
                return null;
            return connectionString;
        }

        #endregion
    }
}
