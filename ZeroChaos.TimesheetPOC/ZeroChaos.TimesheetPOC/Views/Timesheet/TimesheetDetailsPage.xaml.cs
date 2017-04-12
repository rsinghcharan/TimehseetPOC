using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Controls;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models.Request.Timesheet;
using ZeroChaos.TimesheetPOC.Models.Response.Timesheet;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.ViewModel.Timesheet;

namespace ZeroChaos.TimesheetPOC
{
    public partial class TimesheetDetailsPage
    {
        #region Private Members
    //    private TimesheetDetailsResponse TimesheetDetails { get; set; }
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public TimesheetDetailsPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<object, string>(this, "ApproveManager", (sender, arg) =>
           {
               txtApprovalManager.Text = arg;
           });
        }
        #endregion

        #region Form Events
        public void LoadTimesheet()
        {
            //busy.IsBusy = true;
            var BC = BindingContext as DetailTimesheetViewModel;
            BC.GetDetail((res) =>
            {
                lblResourceNameValue.Text = res.ResourceFullName;
                lblProjectNameValue.Text = res.ProjName;
                lblEndValue.Text = res.EndDt.ToString("dd-MMM-yy");
                lblPoValue.Text = res.ProjectPONumber;
                txtApprovalManager.Text = res.ApprovalManager;
                lblIDValue.Text = BC.TimesheetID.ToString();
                lsTimeSheetItem.ItemsSource = res.TimeSheetEntryList;
                res.TimesheetID = BC.TimesheetID;
              //  BC.SaveSubmitButtonVisibility = (res.TimesheetTypeID == 1 ? true : false);
                btnSave.IsVisible = (res.TimesheetTypeID == 1 ? true : false);
                btnSubmit.IsVisible = (res.TimesheetTypeID == 1 ? true : false);
                //busy.IsBusy = false;
            });
        }

        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.UserSession.SideContentVisibility = (!App.UserSession.SideContentVisibility);
            OnPropertyChanged("SideContentVisible");
        }


        /// <summary>
        /// Save/Submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as CustomButton;
            var BC = BindingContext as DetailTimesheetViewModel;
            BC.SaveSubmitTimesheet(Convert.ToInt32(button.StyleId),(r) =>
            {
                if (!r.ResultSuccess)
                {
                    Application.Current.MainPage.DisplayAlert("Error", r.ResultMessages[0].Message, "Ok");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Timesheet", r.ResultMessages[0].Message, "Ok");
                }
            });
            //IServiceCaller service = new ServiceCaller();

            //var request = PrepareSaveOrSubmitTimesheetRequest(Convert.ToInt32(button.StyleId));
            //service.CallHostService<SaveOrSubmitTimesheetRequest, SaveOrSubmitTimesheetResponse>(request, "SaveOrSubmitTimesheetRequest", (r) =>
            //{
            //    if (!r.ResultSuccess)
            //    {
            //        Application.Current.MainPage.DisplayAlert("Error", r.ResultMessages[0].Message, "Ok");
            //    }
            //    else
            //    {
            //        Application.Current.MainPage.DisplayAlert("Timesheet", r.ResultMessages[0].Message, "Ok");
            //    }
            //});
        }
		void Handle_Clicked(object sender, System.EventArgs e)
		{
			var BC = BindingContext as DetailTimesheetViewModel;
			BC.OpenAddEntryPage();
		}

        #endregion

        #region Private Methods
        private SaveOrSubmitTimesheetRequest PrepareSaveOrSubmitTimesheetRequest(int action)
        {
            var BC = BindingContext as DetailTimesheetViewModel;            
            var request = new SaveOrSubmitTimesheetRequest
            {
                PrimaryApprovalManagerID = BC.SelectedManager,
                ActionTypeID = action,
                EndDate = BC.Tres.EndDt,
                ProjectID = BC.Tres.ProjectID,
                ResourceID = BC.Tres.ResourceID,
                TimesheetID = BC.Tres.TimesheetID,
                timesheetEntries = BC.Tres.TimeSheetEntryList,
                loggedonUser = App.UserSession.LoggedonUser
            };

            return request;
        }
        #endregion

        private void txtApprovalManager_Focused(object sender, FocusEventArgs e)
        {
            var BC = BindingContext as DetailTimesheetViewModel;
            BC.OpentheApproveManager();
        }
       
    }
}
