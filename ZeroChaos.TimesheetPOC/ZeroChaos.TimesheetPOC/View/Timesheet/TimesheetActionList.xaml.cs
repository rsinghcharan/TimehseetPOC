using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZeroChaos.TimesheetPOC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimesheetActionList : ContentPage
    {
        public TimesheetActionList()
        {
            InitializeComponent();
        }
        async void timesheetActionList_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("More Information", "Cancel", null, "Notes", "Adjustment Track", "Track Codes", "Attachments", "Additional Information");
            switch (action)
            {
                //case "Notes":
                //    await Navigation.PushAsync(new AbsoluteDemoPage());
                //    break;
                //case "Attachments":
                //    await Navigation.PushAsync(new AbsoluteDemo());
                //    break;
                case "Track Codes":
                    await Navigation.PushAsync(new TimesheetTrackCode());
                    break;
                //case "Adjustment Track":
                //    await Navigation.PushAsync(new Ch15TypingText());
                //    break;
            }
        }

    }
}
