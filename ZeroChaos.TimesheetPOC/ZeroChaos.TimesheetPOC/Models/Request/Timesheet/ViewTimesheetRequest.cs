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
        public int contactID { get; set; }
        public int resourceID { get; set; }
        public int pageSize { get; set; }
        public int offset { get; set; }
    }
}
