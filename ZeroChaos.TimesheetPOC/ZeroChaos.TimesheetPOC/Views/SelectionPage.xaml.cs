using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZeroChaos.TimesheetPOC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectionPage : ContentPage
    {
        public SelectionPage()
        {
            InitializeComponent();

            messageDispay.Text = App.UserSession.CurrentUserInfo.ClientID + " " + App.UserSession.CurrentUserInfo.FullName + " " + App.UserSession.CurrentUserInfo.UserPreferredLanguageName;
        }
    }
}
