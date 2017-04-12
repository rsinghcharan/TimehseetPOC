using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ZeroChaos.TimesheetPOC.Controls
{
    [ContentProperty("ContainerContent")]
    public partial class BusyIndicator : ContentView
    {
        public BusyIndicator()
        {
            InitializeComponent();
            overlay.IsVisible = false;
        }
        public View ContainerContent
        {
            get { return ContentFrame.Content; }
            set { ContentFrame.Content = value; }
        }
       

        public bool IsBusy
        {
            get { return overlay.IsVisible; }
            set
            {
                if (value)
                    ContentFrame.IsEnabled = false;
                else
                    ContentFrame.IsEnabled = true;


                overlay.IsVisible = value;
                indicator.IsVisible = value;
                indicator.IsRunning = true;

            }
        }

    }
}
