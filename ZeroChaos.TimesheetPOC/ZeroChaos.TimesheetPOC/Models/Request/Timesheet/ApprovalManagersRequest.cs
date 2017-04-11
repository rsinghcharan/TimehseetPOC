using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroChaos.TimesheetPOC.Models.Request.Timesheet
{
    public class ApprovalManagersRequest:RequestBase
    {
        public int projectID { get; set; }
    }
}
