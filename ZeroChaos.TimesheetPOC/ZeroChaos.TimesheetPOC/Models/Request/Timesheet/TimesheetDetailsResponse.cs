using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroChaos.TimesheetPOC.Models.Response;

namespace ZeroChaos.TimesheetPOC.Models.Request.Timesheet
{
    public class TimesheetDetailsResponse:ResponseBase
    {
        public DateTime EndDt { get; set; }
        public string EndDtDisp { get; set; }
        public string StatusReasonName { get; set; }
        public int? TimesheetTypeID { get; set; }
        public string TimesheetTypeName { get; set; }
        public string Note { get; set; }
        public string ProjectPONumber { get; set; }
        private List<UserDefinedFields> customFields;

        public List<UserDefinedFields> TimesheetCustomFields
        {
            get { return customFields; }
            set { customFields = value; }
        }

        private List<UserDefinedFields> timeDetailCustomFields;

        public List<UserDefinedFields> TimeDetailCustomFields
        {
            get { return timeDetailCustomFields; }
            set { timeDetailCustomFields = value; }
        }

        public int? TimePeriodID { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
        public bool? Exempt { get; set; }
        public bool IsCANV { get; set; }
        public int? ApprovalManagerId { get; set; }
        public string ApprovalManager { get; set; }
        public string UnitsHeader { get; set; }
        public string ResourceFullName { get; set; }
        public bool IsPeriodicOT { get; set; }
        public bool ShouldDisplayBillRate { get; set; }
        public bool ShouldDisplayPayRate { get; set; }
        public bool HasTrackCode { get; set; }
        public bool HasAssignTrackcodePermission { get; set; }
        public string ProjName { get; set; }
        public int ProjectID { get; set; }
        public string ClientName { get; set; }
        public int? OverTimeStrategyID { get; set; }
        public string BillCurrencyCode { get; set; }
        public string PayCurrencyCode { get; set; }
        public bool? TimeSheetApprovalRequired { get; set; }
        public List<TimesheetEntry> TimeSheetEntryList { get; set; }
        public List<TimesheetEntry> TimeDetailRecords { get; set; }
        public bool ISResourceRejectedOrTerminated { get; set; }

        public TimesheetDetailsResponse()
        {
            customFields = new List<UserDefinedFields>();
            TimeSheetEntryList = new List<TimesheetEntry>();
            TimeDetailRecords = new List<TimesheetEntry>();
            timeDetailCustomFields = new List<UserDefinedFields>();

        }

        public bool EnableTimesheetAttachment { get; set; }
        public bool AllowZeroHourSubmission { get; set; }
        public bool HasAddTrackcodePermission { get; set; }
        public bool? ManagerSubmitTime { get; set; }
        public bool? ManagerAddTime { get; set; }
        public bool? ResourceSubmitExistingTimesheet { get; set; }

        //ZMOB-2070 -- Required to display the sick time accraual balance after manager submits time sheet.
        //It is also used to get sick time accrual balance for resource while logged in as manager and created timesheet for resource.
        public int ResourceID { get; set; }

        public int ClientID { get; set; }

        public int TimesheetID { get; set; }
        public string BusinessUnit { get; set; }
    }
    public class TimesheetEntry
    {
        public Nullable<int> TimesheetID { get; set; }
        public int DailyDetailID { get; set; }
        public int TimeDetailID { get; set; }
        public Nullable<int> PayCodeID { get; set; }
        private string _payCodeName = string.Empty;

        public string PayCodeName
        {
            get
            {
                return _payCodeName;
            }
            set { _payCodeName = value; }
        }

        public string PayRate { get; set; }
        public string BillRate { get; set; }
        public string PayRate_dv { get; set; }
        public string BillRate_dv { get; set; }
        public Nullable<int> TrackCodeID { get; set; }
        public string TrackCodeName { get; set; }
        public string TotalHours { get; set; }
        public string Units { get; set; }
        public string Units_dv { get; set; }
        public DateTime TimesheetEntryDate { get; set; }

        public string PayCodeDesc { get; set; }
        public string PayRateTotal { get; set; }
        public string BillTotal { get; set; }
        public string PayRateTotal_dv { get; set; }
        public string BillTotal_dv { get; set; }

        //Following properties are only applicable to Hourly With Details
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<UserDefinedFields> TimeDetailCustomFields { get; set; }
        public bool HasBreakTime { get; set; }
        public bool IsBreakItem { get; set; }
        public short? PayCodeRateTypeID { get; set; }
        public int Index { get; set; }
        public string TimesheetUnitsName { get; set; }
        public string DailyTrackcodePercentage { get; set; }

        // added by Shweta Kulshrestha as on 20.07.2015 against JIRA #2008
        public bool SickTimeAccrualTracking { get; set; }

        // ended by Shweta Kulshrestha as on 20.07.2015 against JIRA #2008
        public bool Workable { get; set; }

        public bool MealBreakTakenVisibility { get; set; }

        //Fix for ZMOB-2297 -- added workable to identify sick/lunch time to disable meal break toggle button
        public bool IsMealBreakToggleSwitchVisible { get; set; }

        public bool IsNewTimeEntry { get; set; }

        public bool IsUnitsDropdownVisibleForPeriodicDetail { get; set; }

        public TimesheetEntry()
        {
            TimeDetailCustomFields = new List<UserDefinedFields>();
        }
    }
    public class UserDefinedFields
    {
        public string ID { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; }
        public Nullable<int> MaximumLength { get; set; }
        public int ControlID { get; set; }
        public List<DropDownItem> UserDefinedDropDown { get; set; }
        public bool? Visible { get; set; } // added for ZMOB-3106
        public bool IsUDFBool { get; set; }
        //Non-table properties.
        public bool IsDisabled { get; set; }
    }
    public class DropDownItem
    {
        public DropDownItem()
        {
        }
        public DropDownItem(string name, string value, int? ShareWithID = null)
        {
            this.Name = name;
            this.Value = value;
            this.ShareWithID = ShareWithID;
        }
        public string Name { get; set; }
        public string Value { get; set; }
        public int? ShareWithID { get; set; }
    }
}
