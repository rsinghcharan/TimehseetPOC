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
using ZeroChaos.TimesheetPOC.Views.Timesheet;

namespace ZeroChaos.TimesheetPOC.ViewModel.Timesheet
{
    public class NotesTimesheetViewModel : BaseViewModel
    {
        #region Private Memebers
        IServiceCaller service;
        #endregion
       
        #region Properties
        public int ObjectID { get; set; }
        public int ClientID { get; set; }
        public int PKID { get; set; }

        #endregion
        
        #region Constructor
        public NotesTimesheetViewModel()
        {


        }
        #endregion

        #region Public Methods
        public async void GetTimesheetNotesList()
        {
            service = new ServiceCaller();
            TimesheetNotes tnPage = new TimesheetNotes();
            tnPage.BindingContext = this;

            var request = new TimesheetNotesRequest
            {
                Offset = 0,
                Pagesize = 10,
                loggedonUser = App.UserSession.LoggedonUser,
                objectID = ObjectID,
                clientID = ClientID,
                PKID = PKID
            };
            await service.CallHostService<TimesheetNotesRequest, TimesheetNotesResponse>(request, "GetNotesHistoryRequest", (r) =>
            {
                if (r.ResultSuccess)
                {
                    tnPage.ItemSource = r.zcwNoteList;
                    MasterDetailViewModel.Detail = tnPage;
                }
                else
                {
                    MasterDetailViewModel.Detail.DisplayAlert("Error", r.ResultMessages.FirstOrDefault().Message, "ok");
                }
            });
        }
        #endregion 
    }
}
