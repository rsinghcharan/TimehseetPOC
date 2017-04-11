using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models.Request.Timesheet;
using ZeroChaos.TimesheetPOC.Models.Response.Timesheet;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.ViewModel;
using ZeroChaos.TimesheetPOC.ViewModel.Timesheet;

namespace ZeroChaos.TimesheetPOC.Views.Timesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewTimesheetPage
    {
        public ViewTimesheetPage()
        {
            try
            {
                InitializeComponent();
				 //Detail = new TimesheetDetailsPage();
                IServiceCaller service = new ServiceCaller();
                //var request = new LoginRequest { emailAddress = txtUserName.Text, password = txtPassword.Text };
                var request = new ViewTimesheetRequest
                {
                    contactID = (App.UserSession.CurrentUserInfo.UserTypeID == 2 ? App.UserSession.LoggedonUser.userID : 0),
                    resourceID = (App.UserSession.CurrentUserInfo.UserTypeID == 1 ? App.UserSession.LoggedonUser.userID : 0),
                    loggedonUser = App.UserSession.LoggedonUser,
                    offset=0,pageSize=10

                };
                service.CallHostService<ViewTimesheetRequest, ViewTimesheetObjectResponse>(request, "FilterTimesheetsForSearchRequest", (r) =>
                {              
                    this.lstView.ItemsSource = r.timesheets;

                });
                this.lstView.ItemSelected += (sender, e) =>
               {
                   if (e.SelectedItem == null) return; // don't do anything if we just de-selected the row

                   var timesheet = e.SelectedItem as ViewTimesheetResponse;
                   ((ListView)sender).SelectedItem = null; // de-select the row
                                                           //call detail page from below
                                                           /*var secondPage = new SecondPage();
                                                           secondPage.BindingContext = e.SelectedItem;
                                                           await Navigation.PushAsync(secondPage);*/

                  
                   var viewtimesheetVM = BindingContext as ViewTimesheetViewModel;
                   viewtimesheetVM.GetTimesheetDetailPage(timesheet.timesheetID);
               };
            }
            catch (Exception ex)
            { }
        }

        //void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    App.UserSession.SideContentVisibility = (!App.UserSession.SideContentVisibility);
        //    OnPropertyChanged("SideContentVisible");
        //}
    }
}
