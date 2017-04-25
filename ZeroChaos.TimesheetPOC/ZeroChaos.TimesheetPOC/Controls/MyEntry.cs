using System;

using Xamarin.Forms;

namespace ZeroChaos.TimesheetPOC
{
	public class MyEntry : Entry
	{
	public bool IsDate { get; set; }
	public MyEntry()
	{
		this.Focused += MyEntry_Focused;
	}

	private void MyEntry_Focused(object sender, FocusEventArgs e)
	{
		if (IsDate)
		{
			var parent = this.Parent as StackLayout;

			DatePicker dt = new DatePicker();
			dt.DateSelected += Dt_DateSelected;
			
			parent.Children.Add(dt);
			Device.BeginInvokeOnMainThread(() =>
			{
					
			
	dt.Focus();


			});


		}
	}

	private void Dt_DateSelected(object sender, DateChangedEventArgs e)
	{
		var selectedDate = sender as DatePicker;
		this.Text = selectedDate.Date.ToString("MMM-dd-yyyy");
		var parent = this.Parent as StackLayout;
			parent.Children.Remove(selectedDate);   
		}
	}
}

