using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroChaos.TimesheetPOC.Models.Response.Timesheet
{
    public class SaveOrSubmitTimesheetResponse : ResponseBase
    {
        public bool OTStrategyValidationFailed { get; set; }
        public int OverTimeStrategyID { get; set; }
        public int TimesheetID { get; set; }
        public int? TimesheetTypeID { get; set; }
        public string TimesheetTypeName { get; set; }
        public Confirmation Confirmation { get; set; }
        public bool IsSickNegative { get; set; }
    }
    public class Confirmation
    {
        public string SendBackField { get; set; }
        private List<ResultMessage> confirmationMessages;

        public Confirmation()
        {
            confirmationMessages = new List<ResultMessage>();
        }

        public List<ResultMessage> ConfirmationMessages
        {
            get { return confirmationMessages; }
            set { confirmationMessages = value; }
        }
    }
}
