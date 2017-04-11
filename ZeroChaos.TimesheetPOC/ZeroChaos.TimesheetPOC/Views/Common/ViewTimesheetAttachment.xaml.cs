using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models.Request.Common;
using ZeroChaos.TimesheetPOC.Models.Response.Common;
using ZeroChaos.TimesheetPOC.Services;

namespace ZeroChaos.TimesheetPOC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewTimesheetAttachment : ContentPage
    {
        public ViewTimesheetAttachment()
        {
            InitializeComponent();
            GetAttachment();
        }

        void GetAttachment()
        {
            IServiceCaller service = new ServiceCaller();
            GetAttachmentsRequest request = new GetAttachmentsRequest();
            request.ObjectID = 9;
            request.PKID = 1354014;
            request.OffSet = 0;
            request.PageSize = 200;
            request.loggedonUser = App.UserSession.LoggedonUser;

            service.CallHostService<GetAttachmentsRequest, GetAttachmentResponse>(request, "GetAttachmentsRequest", (r) =>
            {
                lstViewAttachment.ItemsSource = r.Attachments;
            });

        }

    }
}
