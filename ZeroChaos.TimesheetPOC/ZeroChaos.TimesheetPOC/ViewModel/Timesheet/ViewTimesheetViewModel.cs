#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
#endregion

namespace ZeroChaos.TimesheetPOC.ViewModel.Timesheet
{
    public class ViewTimesheetViewModel 
    {
        #region Private Members
        private MasterDetailViewModel masterDetailViewModel;
        #endregion

        #region Properties
        public MasterDetailViewModel MasterDetailViewModel
        {
            get { return masterDetailViewModel; }
            set { masterDetailViewModel = value; }
        }
        #endregion

        #region Constructors
        public ViewTimesheetViewModel()
        {

        }
        #endregion

        #region Public Methods
        public void GetTimesheetDetailPage(int TimesheetID)
        {

            MasterDetailViewModel.Header = "Timesheet";
            MasterDetailViewModel.RightButton = "...";
            DetailTimesheetViewModel vm = new DetailTimesheetViewModel();
            vm.TimesheetID = TimesheetID;
            vm.MasterDetailViewModel = MasterDetailViewModel;
            TimesheetDetailsPage detailPage = new TimesheetDetailsPage();
            detailPage.BindingContext = vm;
            MasterDetailViewModel.Detail = detailPage;
            detailPage.LoadTimesheet();           
        }
        #endregion

        #region Private methods
        #endregion
    }
}
