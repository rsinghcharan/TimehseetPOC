using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Services;

namespace ZeroChaos.TimesheetPOC
{
	public partial class SingleItemSelectionPage : ContentPage
	{
		public SingleItemSelectionPage()
		{
			InitializeComponent();
			GetTimesheetEndDates();
		}
		public void GetTimesheetEndDates()
		{
			IServiceCaller service = new ServiceCaller();
			var request = new TimesheetEndingDatesRequest { projectID = 429103, loggedonUser = App.UserSession.LoggedonUser, timesheetEndingDate = "10/22/2014 12:00:00" };
			service.CallHostService<TimesheetEndingDatesRequest, TimesheetEndingDatesResponse>(request, "GetTimesheetEntryDatesRequest", (r) =>
			{
				lstView.ItemsSource = r.timesheetEntryDates;
			});
		}
		public void GetTimesheetPaycodes()
		{
			IServiceCaller service = new ServiceCaller();
			var request = new TimesheetPayCodeRequest { timesheetTypeID=1,projectID = 429103, loggedonUser = App.UserSession.LoggedonUser, timesheetEndingDate = "10/22/2014 12:00:00" };
			service.CallHostService<TimesheetPayCodeRequest, TimesheetPayCodeResponse>(request, "GetPayCodesRequest", (r) =>
			{
				lstView.ItemsSource = r.payCodeInfoList;
			});
		}

	}

}
