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
            if(Device.RuntimePlatform==Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
            
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
            //Image imgMenu = (Image)sender;
            //if (App.UserSession.SideContentVisibility)
            //{
            //    imgMenu.Margin = new Thickness(220, 20, 0, 0);
            //}
            //else
            //{
            //    imgMenu.Margin = new Thickness(2, 20, 0, 0);
            //}
            OnPropertyChanged("SideContentVisible");
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
