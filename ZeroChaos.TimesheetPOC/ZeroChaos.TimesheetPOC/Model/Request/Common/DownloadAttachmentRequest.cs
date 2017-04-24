using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroChaos.TimesheetPOC.Models.Request.Common
{
    public class DownloadAttachmentRequest : RequestBase
    {
        public int ObjectID { get; set; }
        public string RelativePath { get; set; }
    }
}
