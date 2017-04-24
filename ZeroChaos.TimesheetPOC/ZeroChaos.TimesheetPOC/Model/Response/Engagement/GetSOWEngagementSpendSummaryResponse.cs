using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroChaos.TimesheetPOC.Models.Response;

namespace ZeroChaos.TimesheetPOC.Model.Response.Engagement
{
    public class GetSOWEngagementSpendSummaryResponse:ResponseBase
    {
        public CustomizedField AmountReleasedForInvoicing { get; set; }
        public CustomizedField TotalInvoiced { get; set; }
        public CustomizedField AmountAwaitingApproval { get; set; }
        public CustomizedField NotReleasedForInvoicing { get; set; }
        public CustomizedField PercentOfApprovedBudgetForReleasedForInvoicing { get; set; }
        public CustomizedField PercentOfApprovedBudgetForNotReleasedForInvoicing { get; set; }
        public CustomizedField RemainingAvailableForInvoicing { get; set; }
        public CustomizedField ApprovedBudget { get; set; }
        public string PercentageSpendUsed { get; set; }
        public string PercentageSpendRemaining { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsChartVisible { get; set; }
    }
    public class CustomizedField
    {
        public bool IsVisible { get; set; }
        public bool IsModify { get; set; }
        public bool IsRequired { get; set; }
        public string DefaultValue { get; set; }
        public string Caption { get; set; }
        public string FieldValue { get; set; }
    }
}
