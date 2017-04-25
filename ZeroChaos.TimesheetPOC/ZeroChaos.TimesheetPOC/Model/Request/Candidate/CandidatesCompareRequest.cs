#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroChaos.TimesheetPOC.Models.Request;
#endregion

namespace ZeroChaos.TimesheetPOC.Model.Request.Candidate
{
    /// <summary>
    /// CandidatesCompareRequest class
    /// </summary>
    public class CandidatesCompareRequest : RequestBase
    {
        public int reqID { set; get; }
        List<int> _reqSubIDs = new List<int>();
        public List<int> reqSubIDs { set { _reqSubIDs = value; } get { return _reqSubIDs; } }
        public int userPreferredLanguageID { get; set; }
    }
}
