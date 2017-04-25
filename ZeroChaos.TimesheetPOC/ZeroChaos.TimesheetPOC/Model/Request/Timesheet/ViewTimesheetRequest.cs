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
    /// ViewTimesheetRequest class
    /// </summary>
    public class ViewTimesheetRequest : RequestBase
    {

        public int ResourceID { get; set; }
        public DateTime MinSubmitDate { get; set; }
        public DateTime MaxSubmitDate { get; set; }
        //public bool IsAfterSubmitDate { get; set; }
        //private List<Statuses> statuses = new List<Statuses>();

        //public List<Statuses> Statuses
        //{
        //    get
        //    {
        //        return statuses;
        //    }
        //    set
        //    {
        //        statuses = value;
        //    }
        //}
        public int ContactID { get; set; }
        public int VendorID { get; set; }
        public int TimesheetID { get; set; }
        public string ResourceCodeResourceID { get; set; }
        public string ResourceName { get; set; }
        public string ProjectName { get; set; }
        public DateTime MinPeriodEnding { get; set; }
        public DateTime MaxPeriodEnding { get; set; }
        //public bool IsAfterPeriodEnding { get; set; }
        public string PayAmount { get; set; }
        public string ZcBillAmount { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
        public string SortColumnName { get; set; }
        public bool IsSortInAscendingOrder { get; set; }
        public int ClientID { get; set; }
        public string TotalHours { get; set; }
        public int OrgLevelID { get; set; }
    }
}
