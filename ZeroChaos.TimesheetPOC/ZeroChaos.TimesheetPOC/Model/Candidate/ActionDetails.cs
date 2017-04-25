#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ZeroChaos.TimesheetPOC.Model.Candidate
{
    /// <summary>
    /// ReqSubmissionAction class
    /// </summary>
    public enum ReqSubmissionAction
    {
        Invalid = -1,
        Approve = 0,
        ApproveMarkup,
        Decline,
        RequestInterview,
        ExtendOffer,
        CounterOffer,
        RequestCounter,
        ConfirmRate,
        RescindOffer,
        ViewResumeText,
        AddNotes,
        Email,
        Manage_Candidate,
        Request,
        Submit,
        ShortlistCandidate,
        MSPShortlist
    }

    /// <summary>
    /// ActionDetails class
    /// </summary>
    public class ActionDetails
    {
        public String Name { get; set; }
        public ReqSubmissionAction ActionType { get; set; }
    }
}
