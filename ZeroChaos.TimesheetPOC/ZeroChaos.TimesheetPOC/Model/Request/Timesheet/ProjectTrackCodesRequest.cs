using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroChaos.TimesheetPOC.Models.Request.Timesheet
{
    public class ProjectTrackCodesRequest:RequestBase
    {
        public int ProjectID { get; set; }
        public Nullable<DateTime> TimesheetEndingDate { get; set; }
        public int Offset { get; set; }
        public int PageSize { get; set; }
        public bool IsProjectTrackCodes { get; set; }
        public bool IsActiveProjectTrackCodes { get; set; }
        public int TimesheetID { get; set; }
    }
}
