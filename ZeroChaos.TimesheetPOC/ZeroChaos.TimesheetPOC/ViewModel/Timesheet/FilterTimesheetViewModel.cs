using GalaSoft.MvvmLight.Command;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models.Request.Timesheet;
using ZeroChaos.TimesheetPOC.Models.Response.Timesheet;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.ViewModel;
using ZeroChaos.TimesheetPOC.Views.Timesheet;

namespace ZeroChaos.TimesheetPOC.ViewModel.Timesheet
{
    public class FilterTimesheetViewModel : BaseViewModel
    {
        #region Private Members
        // private ViewTimesheetRequest request;

        #endregion

        #region Properties
        private ViewTimesheetRequest _listTimesheetRequest;

        public ViewTimesheetRequest ListTimesheetRequest
        {
            get { return _listTimesheetRequest ?? (_listTimesheetRequest = new ViewTimesheetRequest()); }
            set { _listTimesheetRequest = value; }
        }

        public RelayCommand FilterViewTimeSheet { get; private set; }

        public int ResourceID
        {
            get { return ListTimesheetRequest.ResourceID; }
            set { ListTimesheetRequest.ResourceID = value; RaisePropertyChanged(); }
        }
        public DateTime MinSubmitDate
        {
            get { return ListTimesheetRequest.MinSubmitDate; }
            set { ListTimesheetRequest.MinSubmitDate = value; RaisePropertyChanged(); }
        }
        public DateTime MaxSubmitDate
        {
            get { return ListTimesheetRequest.MaxSubmitDate; }
            set { ListTimesheetRequest.MaxSubmitDate = value; RaisePropertyChanged(); }
        }
        public int ContactID
        {
            get { return ListTimesheetRequest.ContactID; }
            set { ListTimesheetRequest.ContactID = value; RaisePropertyChanged(); }
        }
        public int VendorID
        {
            get { return ListTimesheetRequest.VendorID; }
            set { ListTimesheetRequest.VendorID = value; RaisePropertyChanged(); }
        }
        public int TimesheetID
        {
            get { return ListTimesheetRequest.TimesheetID; }
            set { ListTimesheetRequest.TimesheetID = value; RaisePropertyChanged("TimesheetID"); }
        }
        public string ResourceCodeResourceID
        {
            get { return ListTimesheetRequest.ResourceCodeResourceID; }
            set { ListTimesheetRequest.ResourceCodeResourceID = value; RaisePropertyChanged(); }
        }
        public string ResourceName
        {
            get { return ListTimesheetRequest.ResourceName; }
            set { ListTimesheetRequest.ResourceName = value; RaisePropertyChanged(); }
        }
        public string ProjectName
        {
            get { return ListTimesheetRequest.ProjectName; }
            set { ListTimesheetRequest.ProjectName = value; RaisePropertyChanged(); }
        }
        public DateTime MinPeriodEnding
        {
            get { return ListTimesheetRequest.MinPeriodEnding; }
            set { ListTimesheetRequest.MinPeriodEnding = value; RaisePropertyChanged(); }
        }
        public DateTime MaxPeriodEnding
        {
            get { return ListTimesheetRequest.MaxPeriodEnding; }
            set { ListTimesheetRequest.MaxPeriodEnding = value; RaisePropertyChanged(); }
        }
        public string PayAmount
        {
            get { return ListTimesheetRequest.PayAmount; }
            set { ListTimesheetRequest.PayAmount = value; RaisePropertyChanged(); }
        }
        public string ZcBillAmount
        {
            get { return ListTimesheetRequest.ZcBillAmount; }
            set { ListTimesheetRequest.ZcBillAmount = value; RaisePropertyChanged(); }
        }
        public int Offset
        {
            get { return ListTimesheetRequest.Offset; }
            set { ListTimesheetRequest.Offset = value; RaisePropertyChanged(); }
        }
        public int PageSize
        {
            get { return ListTimesheetRequest.PageSize; }
            set { ListTimesheetRequest.PageSize = value; RaisePropertyChanged(); }
        }
        public string SortColumnName
        {
            get { return ListTimesheetRequest.SortColumnName; }
            set { ListTimesheetRequest.SortColumnName = value; RaisePropertyChanged(); }
        }
        public bool IsSortInAscendingOrder
        {
            get { return ListTimesheetRequest.IsSortInAscendingOrder; }
            set { ListTimesheetRequest.IsSortInAscendingOrder = value; RaisePropertyChanged(); }
        }
        public int ClientID
        {
            get { return ListTimesheetRequest.ClientID; }
            set { ListTimesheetRequest.ClientID = value; RaisePropertyChanged(); }
        }
        public string TotalHours
        {
            get { return ListTimesheetRequest.TotalHours; }
            set { ListTimesheetRequest.TotalHours = value; RaisePropertyChanged(); }
        }
        public int OrgLevelID
        {
            get { return ListTimesheetRequest.OrgLevelID; }
            set { ListTimesheetRequest.OrgLevelID = value; RaisePropertyChanged(); }
        }


        #endregion

        #region Constructor
        public FilterTimesheetViewModel()
        {
            FilterViewTimeSheet = new RelayCommand(OnFilterTimesheet);

        }
        #endregion
        #region Private Methods
        private void OnFilterTimesheet()
        {
            ViewTimesheetViewModel vm = App.ContentModel as ViewTimesheetViewModel;
            vm.ViewTimesheetListRequest = ListTimesheetRequest;
            vm.MasterDetailViewModel = MasterDetailViewModel;
            vm.MasterDetailViewModel.RightButton = "...";
            vm.MasterDetailViewModel.Header = "View Timesheet";
            vm.FilterTimesheet();
            MasterDetailViewModel.PopAsync();
        }

        #endregion
    }
}
