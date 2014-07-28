using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILHost.Common.PayrollApplication
{
    // ---- MESSAGE TYPES ----
    //001 	Get available reports list. 	    Standard and Tax 	                    Last 3 Months for standard  	List 
    //                                                                                    reports - last year for 
    //                                                                                    tax report
    //002 	Get specified report from PAM. 	    Standard and Tax 	                    Single Report 	                PCL File 
    //                                            and Data Download 
    //003 	Get available reports list. 	    Standard and Tax 	                    Date Range 	                    List 
    //004 	Get available reports list. 	    Download Data File 	                    Last 3 Months for data  	    List 
    //                                                                                    download reports
    //006 	Get available reports list. 	    Data Download File 	                    Date Range 	                    List
    //007 	Get specified report from PAM. 	    On Demand 	                            Single Report 	                PCL File 

    public enum WarningType : int
    {
        [Description("Dollars Warning ")]
        DollarsWarning = 1,
        [Description("Hours Warning ")]
        HoursWarning = 2,
        [Description("Net Pay Warning ")]
        NetPayWarning = 3,
        [Description("Rate Warning ")]
        RateWarning = 4,
        [Description("Taxes Warning")]
        TaxesWarning = 5,
        [Description("Tips Warning")]
        TipsWarning = 6,
        [Description("Gross Receipts Warning")]
        GrossReceiptsWarning = 7,
        [Description("Meals Warning")]
        MealsWarning = 8,
        [Description("Deductions Warning")]
        DeductionsWarning = 9,
        [Description("Deductions - Section 125 Warning")]
        DeductionsSection125Warning = 10,
        [Description("Deductions - Deferred Comp Warning")]
        DeductionsDeferredCompWarning = 11,
        [Description("Deferred Comp Loans Warning")]
        DeferredCompLoansWarning = 12,
        [Description("Garnishments Warning")]
        GarnishmentsWarning = 13,
        [Description("Reimbursements Warning")]
        ReimbursementsWarning = 14,
        [Description("1099 Warning")]
        Form1099Warning = 15,
        [Description("Fringe Benefits")]
        FringeBenefits = 16,
    }

    //public enum PayType
    //{
    //    RegularHours = 1,
    //    OvertimeHours = 2,
    //    VactionHours = 3,
    //    HolidayHours = 4,
    //    MiscellaneousHours = 5,
    //    SickHours = 6,
    //    SpecialHours = 7
    //}

    public enum PayType
    {
        Regular = 1,
        Overtime = 2,
        Special = 3,
        Miscellaneous = 4,
        Sick = 5,
        Vacation = 6,
        Holiday = 7,
        Other1 = 8,
        Other2 = 9,
        Other3 = 10,
        Other4 = 11,
        Other5 = 12,
        Other6 = 13
    }
    
    public enum ComponentType
    {
        VariesByClient = 1,
        SameForClients = 2,
    }

    // ------------------------------

    public enum PayrollApplicationReportingMessageType : int
    {
        // standard and tax listing request types

        ListStandardAndTaxLastThreeMonths = 1,
        ListStandardAndTaxDateRange = 3,
        ListStandardAndTaxDownloadLastThreeMonths = 4,
        ListStandardAndTaxDownloadDateRange = 6,

        // standard and tax report request types

        StandardAndTaxReportRequest = 2,
        StandardAndTaxDataFileRequest = 5,

        // on demand report request types

        OnDemandPayrollHistoryReportRequest = 7,
        OnDemandEmployeeListingReportRequest = 8,
        OnDemandMiscellaneousReportRequest = 9

    }

    // ------------------------------





    public enum MessageCategory
    {
        REP,
        CUS
    } 

    public enum ReportType : int
    {
        Undefined = 0,

        /// <summary>Report</summary>
        [Description("Accrual Report")]
        Accrual = 1,

        /// <summary>Report</summary>
        [Description("Check Reconciliation Report")]
        CheckReconciliation = 2,

        /// <summary>Report</summary>
        [Description("Deferred Compensation Report (401(k),403(b), etc.)")]
        DeferredCompensation_401K_403B = 3,

        /// <summary>Report</summary>
        [Description("G/L Posting Report")]
        GlPosting = 4,

        /// <summary>Report</summary>
        [Description("Month To-Date Payroll Report")]
        MonthToDatePayroll = 5,

        /// <summary>Report</summary>
        [Description("Monthly Cafeteria (Sec. 125) Deduction Report")]
        MonthlyCafeteria_Sec125_Deduction = 6,

        /// <summary>Report</summary>
        [Description("Payroll Journal Report")]
        PayrollJournal = 7,

        /// <summary>Report</summary>
        [Description("Payroll Worksheet")]
        PayrollWorksheet = 8,

        /// <summary>Report</summary>
        [Description("Payroll Funding Report")]
        PayrollFunding = 9,

        /// <summary>Report</summary>
        [Description("Payroll Reports - All of the above")]
        PayrollS_AllOfTheAbove = 500,

        /// <summary>Report</summary>
        [Description("Federal 941")]
        Federal_941 = 501,

        /// <summary>Report</summary>
        [Description("Federal 943")]
        Federal_943 = 502,

        /// <summary>Report</summary>
        [Description("Federal W-2")]
        Federal_W2 = 503,

        /// <summary>Report</summary>
        [Description("Federal W-3")]
        Federal_W3 = 504,

        /// <summary>Report</summary>
        [Description("Federal 1099-MISC")]
        Federal_1099MISC = 505,

        /// <summary>Report</summary>
        [Description("Federal 1099-INT")]
        Federal_1099INT = 506,

        /// <summary>Report</summary>
        [Description("Federal 1099-R")]
        Federal_1099R = 507,

        /// <summary>Report</summary>
        [Description("Federal 1096-MISC")]
        Federal_1096MISC = 508,

        /// <summary>Report</summary>
        [Description("Federal 1096-INT")]
        Federal_1096INT = 509,

        /// <summary>Report</summary>
        [Description("Federal 1096-R")]
        Federal_1096R = 510,

        /// <summary>Report</summary>
        [Description("State Unemployment")]
        StateUnemployment = 701,

        /// <summary>Report</summary>
        [Description("State Withholding")]
        StateWithholding = 702,

        /// <summary>Report</summary>
        [Description("Tax Reports - All of the above")]
        TaxS_AllOfTheAbove = 900,

        /// <summary>Report</summary>
        [Description("MA State Health Insurance report - MA 1700")]
        MAStateHealthInsurance_MA_1700 = 703,

        /// <summary>Report</summary>
        [Description("Washington L & I")]
        Washington_LI = 511,

        /// <summary>Report</summary>
        [Description("Payroll Deduction Register")]
        PayrollDeductionRegister = 10,

        /// <summary>Report</summary>
        [Description("Workers' Compensation Report")]
        WorkersCompensation = 11,

        /// <summary>Report</summary>
        [Description("Federal 940")]
        Federal_940 = 512,

        /// <summary>Report</summary>
        [Description("Paycheck Detail Report")]
        PaycheckDetail = 102,

        /// <summary>Report</summary>
        [Description("Paycheck Detail Report")]
        PaycheckDetail2 = 12,

        /// <summary>Report</summary>
        [Description("Per Payroll - Month to Date Report")]
        PerPayroll_MonthToDate = 13,

        /// <summary>Report</summary>
        [Description("Employee Wage, Deduction & Tax Report")]
        EmployeeWage_DeductionAndTax = 14,

        /// <summary>Report</summary>
        [Description("MTD Tips In Excess Report")]
        MTDTipsInExcess = 15,

        /// <summary>Report</summary>
        [Description("401(k) Report")]
        _401K = 16,

        /// <summary>Report</summary>
        [Description("403(b) Report")]
        _403B = 17,

        /// <summary>Report</summary>
        [Description("408(k) Report")]
        _408K = 18,

        /// <summary>Report</summary>
        [Description("457(b) Report")]
        _457B = 19,

        /// <summary>Report</summary>
        [Description("501(c) Report")]
        _501C = 20,

        /// <summary>Report</summary>
        [Description("Simple IRA Report")]
        SimpleIRA = 21,

        /// <summary>Report</summary>
        [Description("Roth 401(k) Report")]
        Roth401K = 22,

        /// <summary>Report</summary>
        [Description("Roth 403(b) Report")]
        Roth403B = 23,

        /// <summary>Report</summary>
        [Description("Health Care Reform")]
        HealthCareReform = 25,

        /// <summary>Report</summary>
        [Description("xxx")]
        XXX = 69,

        /// <summary>Report</summary>
        [Description("Quarterly Tax Package")]
        QuarterlyTaxPackage = 800,

        /// <summary>Report</summary>
        [Description("Tax Exception Report")]
        TaxException = 513,

        /// <summary>Report</summary>
        [Description("Quarterly Tax Package With History")]
        QuarterlyTaxPackageWithHistory = 514,

        /// <summary>Data File</summary>
        [Description("401K Contribution File")]
        _401kContributionFile = 951,

        /// <summary>Data File</summary>
        [Description("401K Census File")]
        _401kCensusFile = 952,

        /// <summary>Data File</summary>
        [Description("401K Address File")]
        _401kAddressFile = 953,

        /// <summary>Data File</summary>
        [Description("Check Reconciliation File")]
        CheckReconciliationFile = 954,

        /// <summary>Data File</summary>
        [Description("Check Reconciliation Special File (a)")]
        CheckReconciliationSpecialFile_A = 955,

        /// <summary>Data File</summary>
        [Description("Check Reconciliation Special File (b)")]
        CheckReconciliationSpecialFile_B = 956,

        /// <summary>Data File</summary>
        [Description("G/L Interface File (a)")]
        GLInterfaceFile_A = 957,

        /// <summary>Data File</summary>
        [Description("G/L Interface File (b)")]
        GLInterfaceFile_B = 958,

        /// <summary>Data File</summary>
        [Description("G/L Interface File (c)")]
        GLInterfaceFile_C = 959,

        /// <summary>Data File</summary>
        [Description("Deductions Detail File (Tampa #26255)")]
        DeductionsDetailFile_Tampa26255 = 960,

        /// <summary>Data File</summary>
        [Description("Salary/Census File (Seattle #60001++)")]
        SalaryCensusFileSeattle_60001pp = 961,

        /// <summary>Data File</summary>
        [Description("Consolidated Salary/Census File (Seattle #60001)")]
        ConsolidatedSalary_CensusFileSeattle_60001 = 962,

        /// <summary>Data File</summary>
        [Description("G/L Interface File (d)")]
        GLInterfaceFileD = 963,

        /// <summary>Data File</summary>
        [Description("401k Contribution File Type 2")]
        _401kContributionFileType2 = 964,

        /// <summary>Data File</summary>
        [Description("401k Employer Contribution File")]
        _401kEmployerContributionFile = 965,





        /// <summary>On Demand Report - Requires Parameters</summary>
        [Description("Employee History Report - Summary")]
        EmployeeHistorySummary = 980,

        /// <summary>On Demand Report - Requires Parameters</summary>
        [Description("Employee History Report - Detail")]
        EmployeeHistoryDetail = 981,

        /// <summary>On Demand Report - No Parameters Required</summary>
        [Description("Employee List Report - All")]
        EmployeeListReport_All = 982,

        /// <summary>On Demand Report - Requires Parameters</summary>
        [Description("Invoice Report")]
        Invoice = 983,

        /// <summary>On Demand Report - No Parameters Required</summary>
        [Description("Employee List Report - Active")]
        EmployeeListReport_Active = 984,

        /// <summary>On Demand Report - No Parameters Required</summary>
        [Description("Employee List Report - Terminated")]
        EmployeeListReport_Terminated = 985,

        /// <summary>On Demand Report - Requires Parameters</summary>
        [Description("Employee History")] //check stub?
        SingleEmployeePayrollHistory = 988,

        /// <summary>On Demand Report - No Parameters Required</summary>
        [Description("Employee Wage, Deduction & Tax Report")]
        EmployeeWage_DeductionTax = 014,

        /// <summary>On Demand Report - No Parameters Required</summary>
        [Description("Outstanding OnePay Check Report")]
        OutstandingOnePayCheck = 986,

        /// <summary>Payroll Process Request</summary>
        [Description("Payroll Process Request")]
        PayrollProcessRequest = 987,

        /// <summary>Payroll Process Request</summary>
        [Description("Employee Ess Access")]
        EmployeeESSAccess = 988,

        /// <summary>Payroll Process Request</summary>
        [Description("Employee History Report - Summary - Export")]
        EmployeeHistorySummary_Export = 989,

        /// <summary>Payroll Process Request</summary>
        [Description("Employee History Report - Detail - Export")]
        EmployeeHistoryDetail_Export = 990,

        W2_1099 = 991,

        W2_Regular = 992
    }

    public enum PAMLocation : int
    {
        Miramar = 1,
        Tampa = 2,
        Phoenix = 3,
        NewYork = 4,
        Atlanta = 5,
        LongIsland = 6,
        Selma = 7,
        Maine = 8,
        Tennessee = 10,
        Chicago = 11,
        Irvine_OrangeCounty = 12,
        Boston = 13,
        WalnutCreek = 14,
        Dallas_OffLine = 15,
        Seattle = 97
    }
}
