using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models.Request.Common;
using ZeroChaos.TimesheetPOC.Models.Response.Common;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.Views.Common;

namespace ZeroChaos.TimesheetPOC.ViewModel
{
    public class AttachmentViewModel : BaseViewModel
    {
        #region Private Memebers
        IServiceCaller service;
        #endregion
      
        #region Properties
        public int ObjectID { get; set; }
        public int PKID { get; set; }

        #endregion
        
        #region Constructor
        public AttachmentViewModel()
        {


        }
        #endregion

        #region Public Methods
        public async void GetAttachmentList()
        {
            service = new ServiceCaller();
            ViewAttachment tnPage = new ViewAttachment();
            tnPage.BindingContext = this;

            var request = new GetAttachmentsRequest
            {
                OffSet = 0,
                PageSize = 10,
                loggedonUser = App.UserSession.LoggedonUser,
                ObjectID = ObjectID,
                PKID = PKID
            };
            await service.CallHostService<GetAttachmentsRequest, GetAttachmentResponse>(request, "GetAttachmentsRequest", (r) =>
             {
                 //lstViewAttachment.ItemsSource = r.Attachments;
                 if (r.ResultSuccess)
                 {
                     tnPage.ItemSource = r.Attachments;
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
