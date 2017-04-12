using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.ViewModel.Timesheet;

namespace ZeroChaos.TimesheetPOC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleItemSelectionPage : ContentPage
    {
        public SingleItemSelectionPage()
        {
            InitializeComponent();
        }

       

        public List<string> SelectionPageCollection
        {
            get { return lstView.ItemsSource as List<string>; }
            set { lstView.ItemsSource = value; }
        }
        public string Option { get; set; }


        private void lstView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var lstview = (sender as ListView);
            var SelectedItem = lstview.SelectedItem;
            var BC = BindingContext as DetailTimesheetViewModel;
            switch (Option)
            {
                case "Date":
                    BC.AddTimesheetEntrySelected.SelectedEntryDate = Convert.ToString(SelectedItem);
                    break;
                case "Paycode":
                    BC.AddTimesheetEntrySelected.SelectedPaycode = Convert.ToString(SelectedItem);
                    break;
                case "Trackcode":
                    BC.AddTimesheetEntrySelected.TrackCode = Convert.ToString(SelectedItem);
                    break;
                default:
                    break;
            }
            MessagingCenter.Send<string, string>(Option, "SelectedOption", SelectedItem.ToString());

            BC.MasterDetailViewModel.PopAsync();

        }
    }
}
