#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.ViewModel;
#endregion

namespace ZeroChaos.TimesheetPOC.Views.MasterPages
{
    /// <summary>
    /// MasterDetail class.
    /// </summary>
    public partial class MasterDetail
    {
        #region Private Members
        #endregion

        #region Constructors
        public MasterDetail()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Events
        protected override void OnAppearing()
        {
            var bc = BindingContext as MasterDetailViewModel;
            
            one.DataSource = bc.GetSampleData();
            one.DataBind();
        }

        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.UserSession.SideContentVisibility = (!App.UserSession.SideContentVisibility);
            OnPropertyChanged("SideContentVisible");
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
