#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace ZeroChaos.TimesheetPOC.Models
{
    /// <summary>
    /// UserPermissions class
    /// </summary>
    public class UserPermissions
    {
        public bool? AllowSOWInvoicing;
        public bool? AllowRequisitions { get; set; }
        public bool? AllowToSearchCandidates { get; set; }
        public bool? AllowToAddTimesheet { get; set; }
        public bool? AllowToAddExpense { get; set; }
        public bool? AllowToSubmitExpense { get; set; }
        public bool? AllowToSubmitTimesheet { get; set; }
        public bool? AllowToHaveCheckList { get; set; }
        public bool? IsRegistered { get; set; }
        public bool? CanClientContactCandidate { get; set; }
        public bool? IsSourcingVendor { get; set; }
        public bool? AllowInsurancePenalty { get; set; }
        public bool? IsPayrollingVendor { get; set; }
        public bool? AllowToEditEnrollment { get; set; }
        public bool? AllowToVendorBIEdit { get; set; }
        public bool? IsServiceProvider { get; set; }
        public bool? IsEnableEvaluationExpiration { get; set; }
        public bool? AllowSOWRequisition { get; set; }
        public bool? AllowEngagement { get; set; }
        public bool? AllowToManageProjects { get; set; }
        public bool? AllowToManageTimesheets { get; set; }
        public bool? AllowToManageMemberPayHistory { get; set; }
        public bool? AllowEnrollMent { get; set; }
        public bool? AllowToManageDocuments { get; set; }
        public bool? IsBackGroundCheckRequiredForMember { get; set; }
        public bool? IsDrugScreenRequiredForMember { get; set; }
        public bool? EnableSSOForMember { get; set; }
        public bool? AllowH1BIPlacement { get; set; }
        public bool? HasW2eVerifyCheck { get; set; }
        public bool? IsRehire { get; set; }
        public bool? IsPayRateAccepted { get; set; }
        public bool? IsMailMeCheck { get; set; }
        public bool? AllowSSOEmailVerification { get; set; }
        public bool? AllowThroughVMS { get; set; }
        public bool? AllowComplianceClientDecision { get; set; }
        public bool? HasEnterpriseWideAccess { get; set; }
        public bool? OutOfOfficeActive { get; set; }
        public bool? AllowToReceiveEmailDuringOutOfOffice { get; set; }
        public bool? IsSentPDF { get; set; }
        public bool? AllowToViewReport { get; set; }
        public bool? AllowManagerToAddNewEngagement { get; set; }
        public bool? AllowManagerToAddNewServiceProvider { get; set; }
        public bool? AllowRFPCreation { get; set; }
        //  public bool? AllowToEditReqAfterDraft { get; set; } //ZCW-71768
        public bool? AllowAutoDistReqsByTier { get; set; }
        public bool? AllowToExceedMaxBillRate { get; set; }
        public bool? AllowToEditResumeByMSP { get; set; }
        public bool? IsClassicDashBoard { get; set; }
        public bool? CanVendorContactClient { get; set; }
        public bool? AllowAutoTerminateProjects { get; set; }
        public bool IsClientExpenseModuleEnabled { get; set; }
        public bool IsClientExpenseModuleEnabledOnDashLet { get; set; }
        public string ResourceCode { get; set; }
        public bool? ShowTimesheetSectionForSP { get; set; }
        /// <summary>
        /// ZCW-61333 used for menu permission               
        /// </summary>
        public bool AllowToSearchServiceProviderProfile { get; set; }
    }
}
