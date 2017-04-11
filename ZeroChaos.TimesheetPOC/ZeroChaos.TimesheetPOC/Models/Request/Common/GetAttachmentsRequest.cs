using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroChaos.TimesheetPOC.Models.Request.Common
{
    public class GetAttachmentsRequest : RequestBase
    {
        public int ObjectID { get; set; }
        public int PKID { get; set; }
        public int PageSize { get; set; }
        public int OffSet { get; set; }

    }
}
