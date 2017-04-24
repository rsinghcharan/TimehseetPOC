using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroChaos.TimesheetPOC.Models.Response.Timesheet
{
    #region TimeSheet TrackCode 

    public class UnAssignedTrackCodesToProjectResponse : ResponseBase
    {
        private List<UnAssignedTrackCode> unAssignedTrackCodes;
        public UnAssignedTrackCodesToProjectResponse()
        {
            unAssignedTrackCodes = new List<UnAssignedTrackCode>();
        }
        public List<UnAssignedTrackCode> UnAssignedTrackCodes
        {
            get { return unAssignedTrackCodes; }
            set { unAssignedTrackCodes = value; }
        }
        public int RecordCount { get; set; }
    }
    public class UnAssignedTrackCode
    {
        public int TrackCodeID { get; set; }
        public string TrackCode { get; set; }
        public string TrackCodeName { get; set; }
        public bool TrackCodeAssigned { get; set; }
        public string TrackCodeAssignedValue { get; set; }
        public bool Active { get; set; }
        public int RecID { get; set; }
        public CustomFields CustomFields { get; set; }
    }

    public class CustomFields
    {
        public string UDF01 { get; set; }
        public string UDF02 { get; set; }
        public string UDF03 { get; set; }
        public string UDF04 { get; set; }
        public string UDF05 { get; set; }
        public string UDF06 { get; set; }
        public string UDF07 { get; set; }
        public string UDF08 { get; set; }
        public string UDF09 { get; set; }
        public string UDF10 { get; set; }
    }
    #endregion

}
