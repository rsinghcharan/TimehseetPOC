using System;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models.Request.Timesheet;
using ZeroChaos.TimesheetPOC.Models.Response.Timesheet;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.ViewModel;

namespace ZeroChaos.TimesheetPOC.ViewModel.Timesheet
{
    public class FilterTimesheetViewModel : BaseViewModel
    {
        #region Private Members
        ViewTimesheetRequest request;
        #endregion

        #region Properties

        public int ResourceID
        {
            get { return request.ResourceID; }
            set { request.ResourceID = value; }
        }
        public DateTime MinSubmitDate
        {
            get { return request.MinSubmitDate; }
            set { request.MinSubmitDate = value; }
        }
        public DateTime MaxSubmitDate
        {
            get { return request.MaxSubmitDate; }
            set { request.MaxSubmitDate = value; }
        }
        public int ContactID
        {
            get { return request.ContactID; }
            set { request.ContactID = value; }
        }
        public int VendorID
        {
            get { return request.VendorID; }
            set { request.VendorID = value; }
        }
        public int TimesheetID
        {
            get { return request.TimesheetID; }
            set { request.TimesheetID = value; }
        }
        public string ResourceCodeResourceID
        {
            get { return request.ResourceCodeResourceID; }
            set { request.ResourceCodeResourceID = value; }
        }
        public string ResourceName
        {
            get { return request.ResourceName; }
            set { request.ResourceName = value; }
        }
        public string ProjectName
        {
            get { return request.ProjectName; }
            set { request.ProjectName = value; }
        }
        public DateTime MinPeriodEnding
        {
            get { return request.MinPeriodEnding; }
            set { request.MinPeriodEnding = value; }
        }
        public DateTime MaxPeriodEnding
        {
            get { return request.MaxPeriodEnding; }
            set { request.MaxPeriodEnding = value; }
        }
        public string PayAmount
        {
            get { return request.PayAmount; }
            set { request.PayAmount = value; }
        }
        public string ZcBillAmount
        {
            get { return request.ZcBillAmount; }
            set { request.ZcBillAmount = value; }
        }
        public int Offset
        {
            get { return request.Offset; }
            set { request.Offset = value; }
        }
        public int PageSize
        {
            get { return request.PageSize; }
            set { request.PageSize = value; }
        }
        public string SortColumnName
        {
            get { return request.SortColumnName; }
            set { request.SortColumnName = value; }
        }
        public bool IsSortInAscendingOrder
        {
            get { return request.IsSortInAscendingOrder; }
            set { request.IsSortInAscendingOrder = value; }
        }
        public int ClientID
        {
            get { return request.ClientID; }
            set { request.ClientID = value; }
        }
        public string TotalHours
        {
            get { return request.TotalHours; }
            set { request.TotalHours = value; }
        }
        public int OrgLevelID
        {
            get { return request.OrgLevelID; }
            set { request.OrgLevelID = value; }
        }
        #endregion

        #region Constructor
        public FilterTimesheetViewModel()
        {
            //ViewTimesheetViewModel _vtm = new ViewTimesheetViewModel();
            //_vtm.FilterTimesheet(request);
        }
        #endregion

    }
}
