using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.Models.Response.Timesheet;
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
                //Device.BeginInvokeOnMainThread(() =>
                //{
                //       lstView.re
                //});
                //Detail = new TimesheetDetailsPage();
                //IServiceCaller service = new ServiceCaller();
                ////var request = new LoginRequest { emailAddress = txtUserName.Text, password = txtPassword.Text };
                //var request = new ViewTimesheetRequest
                //{
                //    contactID = (App.UserSession.CurrentUserInfo.UserTypeID == 2 ? App.UserSession.LoggedonUser.userID : 0),
                //    resourceID = (App.UserSession.CurrentUserInfo.UserTypeID == 1 ? App.UserSession.LoggedonUser.userID : 0),
                //    loggedonUser = App.UserSession.LoggedonUser,
                //    offset=0,pageSize=10

                //};
                //service.CallHostService<ViewTimesheetRequest, ViewTimesheetObjectResponse>(request, "FilterTimesheetsForSearchRequest", (r) =>
                //{              
                //    this.lstView.ItemsSource = r.timesheets;

                //});



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

        private void lstView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            //var timesheet = e.Item as ViewTimesheetResponse;
            // var abc= lstView.ItemsSource as List<ViewTimesheetResponse>;
            //if(abc.Last().timesheetID==timesheet.timesheetID)
            //{
            //    //Application.Current.MainPage.DisplayAlert("last", "Last element Reached", "ok");
            //}
          
        }

        //void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    App.UserSession.SideContentVisibility = (!App.UserSession.SideContentVisibility);
        //    RaisePropertyChanged("SideContentVisible");
        //}
    }
}
