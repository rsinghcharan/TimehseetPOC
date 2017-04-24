using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroChaos.TimesheetPOC.Models.Response.Common
{
    public class DownloadAttachmentResponse : ResponseBase
    {
        public string FileContent { get; set; }
        public string MimeType { get; set; }
        public string EncodeType { get; set; }
    }
}
