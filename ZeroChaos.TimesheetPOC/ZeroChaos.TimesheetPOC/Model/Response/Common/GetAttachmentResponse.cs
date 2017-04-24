using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroChaos.TimesheetPOC.Models.Response.Common
{
    public class GetAttachmentResponse : ResponseBase
    {
        private List<AttachmentInfo> attachments = new List<AttachmentInfo>();
        public GetAttachmentResponse()
        {
            attachments = new List<AttachmentInfo>();
        }
        public List<AttachmentInfo> Attachments
        {
            get { return attachments; }
            set { attachments = value; }
        }
        public int RecordCount { get; set; }

    }

    public class AttachmentInfo
    {
        public string FileName { get; set; }
        public int? AttachmentID { get; set; }
        public string RelativePath { get; set; }
    }


}
