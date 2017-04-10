#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Models;
using ZeroChaos.TimesheetPOC.Models.Request;
using ZeroChaos.TimesheetPOC.Models.Response;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.ViewModel;
using ZeroChaos.TimesheetPOC.Views.MasterPages;
#endregion

namespace ZeroChaos.TimesheetPOC.Views.Login
{
    /// <summary>
    /// Login page partial class
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        #region Private Members
        #endregion

        #region Properties
        #endregion

        #region Constructors
        public LoginPage()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(App.UserSession.RememberedUser))
            {
                txtUserName.Text = App.UserSession.RememberedUser;
            }

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
           //     Navigation.PushAsync(new ForgotPasswordPage(txtUserName.Text));
            };
            lblForgot.GestureRecognizers.Add(tapGestureRecognizer);
        }
        #endregion

        #region Form Events
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnButtonClick(object sender, EventArgs e)
        {
            IServiceCaller service = new ServiceCaller();
            var request = new LoginRequest { emailAddress = txtUserName.Text, password = txtPassword.Text };
            busyindicator.IsBusy = true;
            service.CallHostService<LoginRequest, LoginResponse>(request, "loginrequest", (r) =>
            {
                busyindicator.IsBusy = false;
                var loggedonUser = new UserInfo
                {
                    userCulture = r.UserCulture,
                    userGUID = r.UserID,
                    userName = r.EmailAddress,
                    userID = (r.UserTypeID == 1 ? r.ResourceID : r.ContactID),
                    zCWUserID = Convert.ToInt32(r.ZCWUserID),
                    userPreferredCNLanguageID = r.UserPreferredCNLanguageID,
                    userPreferredLanguageID = r.PreferredLanguageID,
                    userPreferredLanguageName = r.UserPreferredLanguageName,
                    userPreferredTimeZoneID = Convert.ToInt32(r.UserPreferredTimeZone),
                    userPreferredTimeZoneName = r.UserPreferredTimeZoneName,
                    userType = r.UserTypeID
                };

                //  App.UserSession = new ZCMobileSystemConfiguration {LoggedonUser = loggedonUser };
                Application.Current.MainPage = MasterDetailControl.Create<MasterDetail, MasterDetailViewModel>();
                App.UserSession.LoggedonUser = loggedonUser;
                App.UserSession.CurrentUserInfo = r;

                
               // Navigation.PushAsync(new SelectionPage());

                Navigation.PushAsync(new TimesheetActionList());

            });
        }

        void OnRemeberSwitchToggled(object sender, ToggledEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                App.UserSession.RememberedUser = txtUserName.Text;
                App.UserSession.RememberUser = true;
            }
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
