using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeroChaos.TimesheetPOC.Models.Request.Timesheet
{
    #region Timesheet TrackCode

    public class FilterUnAssignedTrackCodesToProjectRequest : RequestBase
    {
        public int ProjectID { get; set; }
        public int OffSet { get; set; }
        public int PageSize { get; set; }
        public bool IsSortInAscendingOrder { get; set; }
        public string SortColumnName { get; set; }
        public int TrackCodeID { get; set; }
        public string TrackCode { get; set; }
        public string TrackCodeName { get; set; }
        public string TrackCodeAssigned { get; set; }
        public bool IsUnassginedFilter { get; set; }

    }
    #endregion



}
