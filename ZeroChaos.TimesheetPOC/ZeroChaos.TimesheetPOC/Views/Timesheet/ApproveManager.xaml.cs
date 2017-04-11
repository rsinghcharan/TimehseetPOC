using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.ViewModel.Timesheet;

namespace ZeroChaos.TimesheetPOC.Views.Timesheet
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApproveManager : ContentPage
    {
        public ApproveManager()
        {
            InitializeComponent();
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var BC = BindingContext as DetailTimesheetViewModel;
            BC.MasterDetailViewModel.PopAsync();

        }
    }

   
}
