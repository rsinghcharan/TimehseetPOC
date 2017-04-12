using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models.Request.Timesheet;
using ZeroChaos.TimesheetPOC.Models.Response.Timesheet;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.Views;
using ZeroChaos.TimesheetPOC.Views.Timesheet;

namespace ZeroChaos.TimesheetPOC.ViewModel.Timesheet
{
    public class DetailTimesheetViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IServiceCaller service;

        public event PropertyChangedEventHandler PropertyChanged;

        public int TimesheetID { get; set; }
		public TimesheetEntry TimeshetEntrySeleted {
			get;
			set;
		}
        public TimesheetDetailsResponse Tres { get; set; }
        public SaveOrSubmitTimesheetResponse SaveSubmitResponse { get; set; }

        public List<PayCodeInfoList> PayCodeInfoList { get; set; }

        public List<ProjectTrackCode> ProjectTrackCode { get; set; }
        public int SelectedManager { get; set; }

        private bool saveSubmitButtonVisibility = true;
        public bool SaveSubmitButtonVisibility
        {
            get
            {
                return saveSubmitButtonVisibility;
            }
            set
            {
                saveSubmitButtonVisibility = value;
                OnPropertyChanged();
            }
        }

        private AddTimeSheet _AddTimesheetEntrySelected;

        public AddTimeSheet AddTimesheetEntrySelected
        {
            get { return _AddTimesheetEntrySelected ?? (_AddTimesheetEntrySelected=new AddTimeSheet()); }
            set { _AddTimesheetEntrySelected = value; }
        }

      
       

        public DetailTimesheetViewModel()
        {
            App.Current.Resources["DateColor"] = Color.FromHex("#3c9ece");
            App.Current.Resources["PayCode"] = Color.FromHex("#c1eaf6");
            App.Current.Resources["TrackCode"] = Color.FromHex("#c1eaf6");
        }
        public async void GetDetail(Action<TimesheetDetailsResponse> Callback)
        {
            service = new Services.ServiceCaller();
            await service.CallHostService<TimesheetDetailsRequest, TimesheetDetailsResponse>(new TimesheetDetailsRequest { loggedonUser = App.UserSession.LoggedonUser, timesheetID = TimesheetID }, "GetTimesheetDetailsRequest", (res) =>
            {
                Tres = res;
                Callback(res);
            });
        }

        public async void SaveSubmitTimesheet(int action, Action<SaveOrSubmitTimesheetResponse> callback)
        {
            service = new ServiceCaller();
            var request = PrepareSaveOrSubmitTimesheetRequest(action);
            await service.CallHostService<SaveOrSubmitTimesheetRequest, SaveOrSubmitTimesheetResponse>(request, "SaveOrSubmitTimesheetRequest", (res) =>
            {
                SaveSubmitResponse = res;
                callback(res);
            });
        }

        public async void OpentheApproveManager()
        {
            service = new Services.ServiceCaller();
            ApproveManager ap = new ApproveManager();
            ap.BindingContext = this;
            
            await service.CallHostService<ApprovalManagersRequest, ApprovalManagerResponse>(new ApprovalManagersRequest { loggedonUser = App.UserSession.LoggedonUser, projectID = Tres.ProjectID }, "GetApprovalManagersRequest", res =>
            {
                if(res.ResultSuccess)
                {
                    ap.ItemSource = res.Managers;
                    MasterDetailViewModel.Detail = ap;
                }
                else
                {
                    MasterDetailViewModel.Detail.DisplayAlert("Error", res.ResultMessages.FirstOrDefault().Message, "ok");
                }
               

            });

        }

        public void LoadSelectionPage(string value)
        {
            IServiceCaller service = new Services.ServiceCaller();
            switch (value)
            {
                case "Date":
                    var request = new TimesheetEndingDatesRequest { projectID = Tres.ProjectID, loggedonUser = App.UserSession.LoggedonUser, timesheetEndingDate =Tres.EndDt.ToString()};
                    service.CallHostService<TimesheetEndingDatesRequest, TimesheetEndingDatesResponse>(request, "GetTimesheetEntryDatesRequest", (r) =>
                    {
                       
                        SingleItemSelectionPage page = new SingleItemSelectionPage();
                        page.SelectionPageCollection = r.timesheetEntryDates;
                        page.Option = value;
                        page.BindingContext = this;
                        MasterDetailViewModel.Detail = page;
                    });
                    break;
                case "Paycode":
                    var req = new TimesheetPayCodeRequest { timesheetTypeID = Tres.TimesheetTypeID.Value, projectID = Tres.ProjectID, loggedonUser = App.UserSession.LoggedonUser, timesheetEndingDate = Tres.EndDt.ToString() };
                    service.CallHostService<TimesheetPayCodeRequest, TimesheetPayCodeResponse>(req, "GetPayCodesRequest", (r) =>
                    {
                        PayCodeInfoList = r.payCodeInfoList;
                        SingleItemSelectionPage page = new SingleItemSelectionPage();
                        page.BindingContext = this;
                        page.Option = value;
                        page.SelectionPageCollection = r.payCodeInfoList.Select(p=>p.payCodeName).ToList();
                        MasterDetailViewModel.Detail = page;
                    });

                    break;
                case "Trackcode":
                    ProjectTrackCodesRequest trackReq = new ProjectTrackCodesRequest();
                    trackReq.ProjectID = Tres.ProjectID;
                    trackReq.TimesheetEndingDate = Tres.EndDt;
                    trackReq.TimesheetID = Tres.TimesheetID;
                    trackReq.Offset = 0;
                    trackReq.PageSize = 10;
                    trackReq.loggedonUser = App.UserSession.LoggedonUser;
                     service.CallHostService<ProjectTrackCodesRequest, ProjectTrackCodeResponse>(trackReq, "GetProjectTrackCodesRequest", (r) =>
                     {
                         ProjectTrackCode = r.ProjectTrackCodes.ToList();
                         SingleItemSelectionPage page = new SingleItemSelectionPage();
                         page.BindingContext = this;
                         page.Option = value;
                         page.SelectionPageCollection = r.ProjectTrackCodes.Select(p => p.TrackCodeName).ToList();
                         MasterDetailViewModel.Detail = page;
                     });
                    break;
                default:
                    break;
            }
        }

		public void OpenAddEntryPage()
		{
			AddTimesheetEntryDetailPage ad = new AddTimesheetEntryDetailPage();
			MasterDetailViewModel.Header="Timesheet Entry";
			MasterDetailViewModel.RightButton="";
			 ad.BindingContext = this;
			MasterDetailViewModel.Detail = ad;
			ad.OnAppearing();

				

		}

        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private SaveOrSubmitTimesheetRequest PrepareSaveOrSubmitTimesheetRequest(int action)
        {
            var request = new SaveOrSubmitTimesheetRequest
            {
                PrimaryApprovalManagerID = (SelectedManager != 0 ? SelectedManager : Tres.ApprovalManagerId),
                ActionTypeID = action,
                EndDate = Tres.EndDt,
                ProjectID = Tres.ProjectID,
                ResourceID = Tres.ResourceID,
                TimesheetID = Tres.TimesheetID,
                timesheetEntries = Tres.TimeSheetEntryList,
                loggedonUser = App.UserSession.LoggedonUser
            };

            return request;
        }
    }

    public class AddTimeSheet
    {
        public string SelectedEntryDate { get; set; }
        public string SelectedPaycode { get; set; }
        public string TrackCode { get; set; }
        public int Units { get; set; }
    }
}
