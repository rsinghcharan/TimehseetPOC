#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Models;
using ZeroChaos.TimesheetPOC.Views.Login;
#endregion

namespace ZeroChaos.TimesheetPOC
{
    public partial class App : Application
    {
        public string RememberedUser = "RememberedUser";
        public static ZCMobileSystemConfiguration UserSession { get; set; }
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            if (App.UserSession == null)
            {
                App.UserSession = new ZCMobileSystemConfiguration();
            }

            if (Properties.ContainsKey(RememberedUser))
            {
                App.UserSession.RememberedUser = (string)Properties[RememberedUser];
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            if (App.UserSession.RememberUser)
            {
                App.UserSession.RememberUser = false;
                Properties[RememberedUser] = App.UserSession.RememberedUser;
            }
            else
            {
                Properties[RememberedUser] = null;
            }
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
