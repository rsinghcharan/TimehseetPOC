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
using ZeroChaos.TimesheetPOC.ViewModel;

namespace ZeroChaos.TimesheetPOC.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewAttachment 
    {
        #region Private Member
        #endregion

        #region Property
        public List<AttachmentInfo> ItemSource
        {
            get { return lstViewAttachment.ItemsSource as List<AttachmentInfo>; }
            set { lstViewAttachment.ItemsSource = value; }
        }

        #endregion
        
        #region Constructor
        public ViewAttachment()
        {
            InitializeComponent();
            //GetAttachment();
        }
        #endregion
        
        #region Public Method
        public void GetAttachment()
        {
            var BC = BindingContext as AttachmentViewModel;
            BC.GetAttachmentList();
        }
        #endregion
    }
   
}
