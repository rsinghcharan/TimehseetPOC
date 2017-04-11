using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.ViewModel.Timesheet;

namespace ZeroChaos.TimesheetPOC
{
	public partial class TimesheetDetailsPage 
	{
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
                //busy.IsBusy = false;
            });
        }

        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.UserSession.SideContentVisibility = (!App.UserSession.SideContentVisibility);
            OnPropertyChanged("SideContentVisible");
        }
        #endregion

        private void txtApprovalManager_Focused(object sender, FocusEventArgs e)
        {
            var BC = BindingContext as DetailTimesheetViewModel;
            BC.OpentheApproveManager();
        }
       
    }
}
