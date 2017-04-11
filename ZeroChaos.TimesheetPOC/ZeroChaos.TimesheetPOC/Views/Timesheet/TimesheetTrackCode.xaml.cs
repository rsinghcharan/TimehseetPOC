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

namespace ZeroChaos.TimesheetPOC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimesheetTrackCode : ContentPage
    {
        #region Constructor
        public TimesheetTrackCode()
        {
            InitializeComponent();
            GetTrackCode();
        }
        #endregion

        #region Private Methods
        void GetTrackCode()
        {
            IServiceCaller service = new ServiceCaller();
            var request = new FilterUnAssignedTrackCodesToProjectRequest { ProjectID = 429103, IsUnassginedFilter = true, OffSet = 0, PageSize = 10 };
            request.loggedonUser = App.UserSession.LoggedonUser;
            service.CallHostService<FilterUnAssignedTrackCodesToProjectRequest, UnAssignedTrackCodesToProjectResponse>(request, "FilterUnAssignedTrackCodesToProjectRequest", (r) =>
            {
                lstViewTrackCode.ItemsSource = r.UnAssignedTrackCodes;
            });

        }
        #endregion
    }
}
