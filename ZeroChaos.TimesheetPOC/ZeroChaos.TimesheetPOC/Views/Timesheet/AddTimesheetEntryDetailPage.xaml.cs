using System;
using System.Collections.Generic;
using ZeroChaos.TimesheetPOC.Views;
using Xamarin.Forms;

namespace ZeroChaos.TimesheetPOC
{
	public partial class AddTimesheetEntryDetailPage : ContentPage
	{
		

		public AddTimesheetEntryDetailPage()
		{
			InitializeComponent();
			var tgr = new TapGestureRecognizer();
			tgr.Tapped +=(s,e)=>OnEntryFieldClicked();
			entryDate.GestureRecognizers.Add(tgr);
			//entryDate.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnEntryFieldClicked()));

		}
		void OnEntryFieldClicked()
		{
			
		}
		void Save_Button_Clicked(object sender,EventArgs args) 
		{ 
			
		}
		void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
		{
			Entry txtField = sender as Entry;
           SingleItemSelectionPage sis = new SingleItemSelectionPage();

			if (txtField.StyleId == "entryDate") 
			{
				//sis.listView.ItemsSource = 
				sis.GetTimesheetEndDates();

				
			}
		}


	}
}
