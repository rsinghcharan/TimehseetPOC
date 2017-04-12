using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models;
using ZeroChaos.TimesheetPOC.Models.Request.Timesheet;
using ZeroChaos.TimesheetPOC.Models.Response.Timesheet;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.ViewModel.Timesheet;

namespace ZeroChaos.TimesheetPOC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimesheetTrackCode
    {
        #region Private Member
        #endregion
      
        #region Property
        public List<UnAssignedTrackCode> ItemSource
        {
            get { return lstViewTrackCode.ItemsSource as List<UnAssignedTrackCode>; }
            set { lstViewTrackCode.ItemsSource = value; }
        }

        #endregion
        
        #region Constructor
        public TimesheetTrackCode()
        {
            InitializeComponent();
           // GetTrackCode();
        }
        #endregion

        #region Public Methods
        public void GetTrackCode()
        {
            var BC = BindingContext as TrackcodeTimesheetViewModel;
            BC.GetTimesheetTrackCode();
        }
        #endregion
    }
}
