using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Model.Request.Timesheet;
using ZeroChaos.TimesheetPOC.Models.Response.Timesheet;
using ZeroChaos.TimesheetPOC.Services;

namespace ZeroChaos.TimesheetPOC.Views.Timesheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimesheetNotes : ContentPage
    {
        public TimesheetNotes()
        {
            InitializeComponent();
            GetNotesList();
        }
        void GetNotesList()
        {
            IServiceCaller service = new ServiceCaller();
            var request = new TimesheetNotesRequest { Offset = 0, Pagesize = 10, loggedonUser = App.UserSession.LoggedonUser, objectID = 9, clientID = 1292, PKID = 7454765 };
            service.CallHostService<TimesheetNotesRequest, TimesheetNotesResponse>(request, "GetNotesHistoryRequest", (r) =>
            {
                lstView.ItemsSource = r.zcwNoteList;
            });
        }
    }
}
