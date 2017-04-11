using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.Models.Request.Timesheet;
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


        

        public List<Manager> ItemSource
        {
            get { return approverlst.ItemsSource as List<Manager>; }
            set { approverlst.ItemsSource = value; }
        }

        private void approverlst_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var se = sender as ListView;
            var BC = BindingContext as DetailTimesheetViewModel;
            BC.SelectedManager = (se.SelectedItem as Manager).ManagerID;
            MessagingCenter.Send<object, string>(this, "ApproveManager", (se.SelectedItem as Manager).ManagerName);
            BC.MasterDetailViewModel.PopAsync();
        }
    }
}
