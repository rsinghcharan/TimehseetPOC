using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ZeroChaos.TimesheetPOC
{
	public partial class TimesheetDetailsPage 
	{
		public TimesheetDetailsPage()
		{
			InitializeComponent();
		}


        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.UserSession.SideContentVisibility = (!App.UserSession.SideContentVisibility);
            OnPropertyChanged("SideContentVisible");
        }
    }
}
