using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ZeroChaos.TimesheetPOC
{
	public partial class SpendSummaryPage : ContentPage
	{
		public SpendSummaryPage()
		{
			InitializeComponent();
			EngagementSpendSummaryViewModel cvm = new EngagementSpendSummaryViewModel();
			this.BindingContext = cvm;
		}
	}
}
