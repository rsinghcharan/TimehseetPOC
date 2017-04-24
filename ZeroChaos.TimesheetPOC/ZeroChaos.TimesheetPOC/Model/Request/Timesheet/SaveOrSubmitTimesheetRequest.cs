#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion 

namespace ZeroChaos.TimesheetPOC.Models.Request.Timesheet
{
    /// <summary>
    /// SaveOrSubmitTimesheetRequest class
    /// </summary>
    public class SaveOrSubmitTimesheetRequest : RequestBase
    {
        //public int UserTypeID { get; set; }
        public int ResourceID { get; set; }
        public int ContactId { get; set; }
        //public string EmailAddress { get; set; }
        //public Guid UserID { get; set; }
        public int? OverTimeStrategyID { get; set; }
        public int ActionTypeID { get; set; }
        public bool IsLastTimesheet { get; set; }
        public int TimesheetID { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ClonedFrom { get; set; }
        public int ProjectID { get; set; }
        public int? PrimaryApprovalManagerID { get; set; }
        public int? SecondaryApprovalManagerID { get; set; }
        public string Notes { get; set; }
        public List<TimesheetEntry> timesheetEntries = new List<TimesheetEntry>();

        public List<TimesheetEntry> TimesheetEntries
        {
            get { return timesheetEntries; }
            set { timesheetEntries = value; }
        }

        public string WeeklyOTHours { get; set; }


        public List<UserDefinedFields> customFields = new List<UserDefinedFields>();

        public List<UserDefinedFields> TimesheetCustomFields
        {
            get { return customFields; }
            set { customFields = value; }
        }

        public bool IsOTConfirmed { get; set; }
        public bool IsSickAllow { get; set; }
        public bool IsEditRequest { get; set; }
    }
}
