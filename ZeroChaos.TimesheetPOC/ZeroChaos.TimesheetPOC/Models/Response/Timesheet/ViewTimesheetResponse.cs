#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ZeroChaos.TimesheetPOC.Models.Response.Timesheet
{
    /// <summary>
    /// ViewTimesheetResponse class
    /// </summary>
    public class ViewTimesheetResponse : ResponseBase
    {
        public int projectID { get; set; }
        public int timesheetID { get; set; }
        public string projectName { get; set; }
        public string periodEnding { get; set; }
        public string payAmount { get; set; }
        public int adjusted { get; set; }
        public bool isApprovalReady { get; set; }
        public string submitDate { get; set; }
        public int projStatusID { get; set; }
        public string projStatus { get; set; }
        public int resourceID { get; set; }
        public string status { get; set; }
        public int timeStatusID { get; set; }
        public string billCurrencyCode { get; set; }
        public string payCurrencyCode { get; set; }
        public bool isLastTimesheet { get; set; }
        public int clientID { get; set; }
        public string clientName { get; set; }
        public bool sickTimeAccrualTracking { get; set; }
    }

    public class ViewTimesheetObjectResponse
    {
        public List<ViewTimesheetResponse> timesheets { get; set; }
        public int recordCount { get; set; }
        public bool resultSuccess { get; set; }
        public List<object> resultMessages { get; set; }
    }
}
