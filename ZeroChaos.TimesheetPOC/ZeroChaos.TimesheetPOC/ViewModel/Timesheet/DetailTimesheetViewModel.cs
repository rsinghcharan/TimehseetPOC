using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Models.Request.Timesheet;
using ZeroChaos.TimesheetPOC.Views.Timesheet;

namespace ZeroChaos.TimesheetPOC.ViewModel.Timesheet
{
    public class DetailTimesheetViewModel : BaseViewModel
    {
        Services.ServiceCaller service;
        public int TimesheetID { get; set; }
        public TimesheetDetailsResponse Tres { get; set; }
        public int SelectedManager { get; set; }
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
    }
}
