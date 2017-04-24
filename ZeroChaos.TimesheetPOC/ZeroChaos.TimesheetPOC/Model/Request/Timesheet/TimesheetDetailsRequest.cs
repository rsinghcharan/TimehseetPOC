using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroChaos.TimesheetPOC.Models.Request.Timesheet
{
    public class TimesheetDetailsRequest:RequestBase
    {
        public int timesheetID { get; set; }
    }
}
