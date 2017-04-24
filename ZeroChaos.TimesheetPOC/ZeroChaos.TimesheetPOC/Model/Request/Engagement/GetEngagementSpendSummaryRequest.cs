using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroChaos.TimesheetPOC.Models.Request;

namespace ZeroChaos.TimesheetPOC.Model.Request.Engagement
{
    public class GetEngagementSpendSummaryRequest:RequestBase
    {
        public int EngagementID { get; set; }
        public int ClientID { get; set; }
    }
}
