#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Views.Login;
#endregion

namespace ZeroChaos.TimesheetPOC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Button click event handler - This method helps decide the data center.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            // App.UserSession = new Model.ZCMobileSystemConfiguration();

            if (Convert.ToString(button.CommandParameter) == "USButton")
            {
                App.UserSession.SelectedDataCenter = "http://devservices.zcdev.net/US-21.0/json/reply/";
            }
            else if (Convert.ToString(button.CommandParameter) == "EUButton")
            {
                App.UserSession.SelectedDataCenter = "http://devservices.zcdev.net/EU-21.0/json/reply/";
            }
            Application.Current.MainPage = new LoginPage();
           // Navigation.PushAsync(new LoginPage());
        }
    }
}

