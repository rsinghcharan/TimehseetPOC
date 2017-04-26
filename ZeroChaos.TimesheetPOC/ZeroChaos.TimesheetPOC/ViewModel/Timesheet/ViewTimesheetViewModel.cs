#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zerochaos.Util.POC.Utility;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models.Request.Timesheet;
using ZeroChaos.TimesheetPOC.Models.Response.Timesheet;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.Views.Timesheet;
using System.Collections.ObjectModel;
#endregion

namespace ZeroChaos.TimesheetPOC.ViewModel.Timesheet
{
    public class ViewTimesheetViewModel : BaseViewModel
    {
        #region Private Members
        private MasterDetailViewModel masterDetailViewModel;
        IServiceCaller service;

        #endregion

        #region Properties
        private ObservableCollection<ViewTimesheetResponse> _viewTimesheetResponse;

        public ObservableCollection<ViewTimesheetResponse> Timesheets
        {
            get { return _viewTimesheetResponse ?? (_viewTimesheetResponse = new ObservableCollection<ViewTimesheetResponse>()); }
            set { _viewTimesheetResponse = value; RaisePropertyChanged("Timesheets"); }
        }

        private ViewTimesheetRequest _viewTimesheetListRequest;

        public ViewTimesheetRequest ViewTimesheetListRequest
        {
            get { return _viewTimesheetListRequest ?? (_viewTimesheetListRequest = new ViewTimesheetRequest()); }
            set { _viewTimesheetListRequest = value; }
        }


        //public MasterDetailViewModel MasterDetailViewModel
        //{
        //    get { return masterDetailViewModel; }
        //    set { masterDetailViewModel = value; }
        //}
        #endregion

        #region Constructors
        public ViewTimesheetViewModel()
        {
            // FilterTimesheet();
        }
        #endregion

        #region Public Methods
        public void GetTimesheetDetailPage(int TimesheetID)
        {

            MasterDetailViewModel.Header = "Timesheet";
            MasterDetailViewModel.RightButton = "...";
            DetailTimesheetViewModel vm = new DetailTimesheetViewModel();
            vm.TimesheetID = TimesheetID;
            vm.MasterDetailViewModel = MasterDetailViewModel;
            TimesheetDetailsPage detailPage = new TimesheetDetailsPage();
            detailPage.BindingContext = vm;
            MasterDetailViewModel.Detail = detailPage;
            detailPage.LoadTimesheet();
        }
        public async void FilterTimesheet()
        {
            service = new ServiceCaller();
            //viewTimesheetRequest = new ViewTimesheetRequest();
            ViewTimesheetListRequest.ContactID = (App.UserSession.CurrentUserInfo.UserTypeID == 2 ? App.UserSession.LoggedonUser.userID : 0);
            ViewTimesheetListRequest.ResourceID = (App.UserSession.CurrentUserInfo.UserTypeID == 1 ? App.UserSession.LoggedonUser.userID : 0);
            ViewTimesheetListRequest.loggedonUser = App.UserSession.LoggedonUser;
            ViewTimesheetListRequest.Offset = 0;
            ViewTimesheetListRequest.PageSize = 10;

            await service.CallHostService<ViewTimesheetRequest, ViewTimesheetObjectResponse>(ViewTimesheetListRequest, "FilterTimesheetsForSearchRequest", (r) =>
             {
                 if (r.resultSuccess)
                 { 
                     Timesheets = r.timesheets.ToObservableCollection();
                     RaisePropertyChanged("Timesheets");
                 }
                 else
                 {
                     MasterDetailViewModel.Detail.DisplayAlert("Error", r.resultMessages.FirstOrDefault().ToString(), "ok");
                 }

             });
        }


        #endregion

        #region Private methods
        #endregion
    }
}
