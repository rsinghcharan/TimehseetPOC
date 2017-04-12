using System;
using System.Collections.Generic;
using ZeroChaos.TimesheetPOC.Views;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.ViewModel.Timesheet;
using ZeroChaos.TimesheetPOC.Models;
using System.Linq;
namespace ZeroChaos.TimesheetPOC
{
	public partial class AddTimesheetEntryDetailPage : ContentPage
	{
		

		public AddTimesheetEntryDetailPage()
		{
			InitializeComponent();
            MessagingCenter.Subscribe<string, string>(this, "SelectedOption", (sender, arg) =>
            {
                
                switch (sender)
                {
                    case "Date":
                        date.Text = arg as string;
                        break;
                    case "Paycode":
                        PayCode.Text = arg as string;
                        break;
                    case "Trackcode":
                        TrackCode.Text = arg as string;
                        break;
                    default:
                        break;
                }
                
            });

        }
		
		
	
        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            Entry txtField = sender as Entry;
            var Bc = BindingContext as DetailTimesheetViewModel;
            Bc.LoadSelectionPage(txtField.StyleId);
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            var Bc = BindingContext as DetailTimesheetViewModel;
            Bc.Tres.TimeSheetEntryList.Add(new Models.Request.Timesheet.TimesheetEntry()
            {
                PayCodeID = Bc.PayCodeInfoList != null ?Bc.PayCodeInfoList.Where(p => p.payCodeName == PayCode.Text).FirstOrDefault().payCodeID:0,
                PayCodeRateTypeID = 1,
                TimesheetEntryDate = Convert.ToDateTime(date.Text),
                TrackCodeID = Bc.ProjectTrackCode!=null ?Bc.ProjectTrackCode.Where(p => p.TrackCodeName == TrackCode.Text).FirstOrDefault().TrackCodeID:0,
                Units = unit.Text
            });
            Bc.SaveSubmitTimesheet(1,  res => 
            {
                if (!res.ResultSuccess)
                {
                    Application.Current.MainPage.DisplayAlert("Error", res.ResultMessages[0].Message, "Ok");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Timesheet", res.ResultMessages[0].Message, "Ok");
                }
                MessagingCenter.Send<object, bool>(this, "UpdateDetail", true);
               Bc.MasterDetailViewModel.PopAsync();

            });


        }
    }
}
