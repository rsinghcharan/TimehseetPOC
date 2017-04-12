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
using ZeroChaos.TimesheetPOC.Views.Timesheet;

namespace ZeroChaos.TimesheetPOC.ViewModel.Timesheet
{
    public class DetailTimesheetViewModel : BaseViewModel, INotifyPropertyChanged
    {
        IServiceCaller service;

        public event PropertyChangedEventHandler PropertyChanged;

        public int TimesheetID { get; set; }
        public TimesheetDetailsResponse Tres { get; set; }
        public SaveOrSubmitTimesheetResponse SaveSubmitResponse { get; set; }
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

		public void OpenAddEntryPage()
		{
			AddTimesheetEntryDetailPage ad = new AddTimesheetEntryDetailPage();
			MasterDetailViewModel.Header="Timesheet Entry";
			MasterDetailViewModel.RightButton="";
			MasterDetailViewModel.Detail = ad;
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
}
