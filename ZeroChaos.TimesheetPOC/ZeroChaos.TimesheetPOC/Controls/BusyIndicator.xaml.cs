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
        public static readonly BindableProperty IsBusyProperty = BindableProperty.Create<BusyIndicator, bool>(p => p.IsBusy, false,propertyChanged:(bindable, value, newValue) => {
            var isbusy = (bool)newValue;
            var main = bindable as BusyIndicator;
            main.ContentFrame.IsEnabled = isbusy;
            main.overlay.IsVisible = isbusy;
            main.indicator.IsVisible = isbusy;
            main.indicator.IsRunning = isbusy;
        });
        
       

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

    }
}
