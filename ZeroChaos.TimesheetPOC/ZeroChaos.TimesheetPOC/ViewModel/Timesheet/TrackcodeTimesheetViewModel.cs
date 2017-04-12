using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models.Request.Timesheet;
using ZeroChaos.TimesheetPOC.Models.Response.Timesheet;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.Views;

namespace ZeroChaos.TimesheetPOC.ViewModel.Timesheet
{
    public class TrackcodeTimesheetViewModel : BaseViewModel
    {
        #region Private Memebrs
        IServiceCaller service;
        #endregion

        #region Properties
        public int ProjectID { get; set; }
        public bool IsUnassginedFilter { get; set; }
        #endregion
        #region Constructor
        public TrackcodeTimesheetViewModel()
        {


        }
        #endregion

        #region Public Methods

        public async void GetTimesheetTrackCode()
        {
            service = new ServiceCaller();
            TimesheetTrackCode ttc = new TimesheetTrackCode();
            ttc.BindingContext = this;

            var request = new FilterUnAssignedTrackCodesToProjectRequest { ProjectID = ProjectID, IsUnassginedFilter = IsUnassginedFilter, OffSet = 0, PageSize = 10 };
            request.loggedonUser = App.UserSession.LoggedonUser;
            await service.CallHostService<FilterUnAssignedTrackCodesToProjectRequest, UnAssignedTrackCodesToProjectResponse>(request, "FilterUnAssignedTrackCodesToProjectRequest", (r) =>
            {
                if (r.ResultSuccess)
                {
                    ttc.ItemSource = r.UnAssignedTrackCodes;
                    MasterDetailViewModel.Detail = ttc;
                }
                else
                {
                    MasterDetailViewModel.Detail.DisplayAlert("Error", r.ResultMessages.FirstOrDefault().Message, "ok");
                }

            });

        }
        #endregion
        #region Public Methods

        #endregion
        #region Private Methods

        #endregion
    }
}
