#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zerochaos.Util.POC.Messages;
using ZeroChaos.TimesheetPOC.Models;
using ZeroChaos.TimesheetPOC.ViewModel;
#endregion

namespace ZeroChaos.TimesheetPOC.Views.MasterPages
{
    /// <summary>
    /// MasterDetailControl class.
    /// </summary>
    public partial class MasterDetailControl
    {
        #region Private Members
        private bool _sideContentView = false;
        #endregion

        #region Properties
        public static readonly BindableProperty SideContentProperty = BindableProperty.Create("SideContent",
            typeof(View), typeof(MasterDetailControl), null, propertyChanged: (bindable, value, newValue) =>
            {
                var control = (MasterDetailControl)bindable;
                control.SideContentContainer.Children.Clear();
                control.SideContentContainer.Children.Add(control.SideContent);
            });

        public BindableProperty DetailProperty = BindableProperty.Create("Detail",
            typeof(ContentPage), typeof(MasterDetailControl),
            propertyChanged: (bindable, value, newValue) =>
            {
                var masterPage = (MasterDetailControl)bindable;
                masterPage.DetailContainer.Content = newValue != null ?
                    ((ContentPage)newValue).Content : null;
                masterPage.OnPropertyChanged("SideContentVisible");
            });

        public BindableProperty TitleProperty = BindableProperty.Create("Header", 
            typeof(string), typeof(MasterDetailControl), 
            propertyChanged: (bindable, value, newValue) =>
            {
                var masterPage = (MasterDetailControl)bindable;
                masterPage.headerTitle.Text = (string)newValue;

            });
        public BindableProperty SideButtonProperty = BindableProperty.Create("RightButton", typeof(string), typeof(MasterDetailControl), propertyChanged: (bindable, value, newValue) =>
        {
            var masterPage = (MasterDetailControl)bindable;
            masterPage.rightButton.Text = (string)newValue;

        });

       /* public BindableProperty MasterBackButtonProperty = BindableProperty.Create("MasterBackButton", typeof(bool), typeof(MasterDetailControl), propertyChanged: (bindable, value, newValue) =>
        {
            var masterPage = (MasterDetailControl)bindable;
            masterPage.back.IsVisible = (bool)newValue;

        });*/
        public string Header
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
       

        public string RightButton
        {
            get { return (string)GetValue(SideButtonProperty); }
            set { SetValue(SideButtonProperty,value); }
        }
       /* public bool MasterBackButton
        {
            get { return (bool)GetValue(MasterBackButtonProperty); }
            set { SetValue(MasterBackButtonProperty, value); }
        }*/

        public ContentPage Detail
        {
            get { return (ContentPage)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }

        public View SideContent
        {
            get { return (View)GetValue(SideContentProperty); }
            set { SetValue(SideContentProperty, value); }
        }

        public bool SideContentVisible
        {
            get
            {
                return App.UserSession.SideContentVisibility;

            }
            //set
            //{
            //    var detailPage = Detail as DetailPage;
            //    if (detailPage != null)
            //    {
            //        detailPage.SideContentVisible = value;
            //    }
            //    else
            //    {
            //        _sideContentView = (!_sideContentView);
            //    }
            //}
        }
        #endregion

        #region Constructors
        public MasterDetailControl()
        {
            InitializeComponent();
            SetBinding(DetailProperty, new Binding("Detail", BindingMode.OneWay));
            SetBinding(TitleProperty, new Binding("Header", BindingMode.TwoWay));
            SetBinding(SideButtonProperty, new Binding("RightButton", BindingMode.TwoWay));
            //SetBinding(BackButtonIsVisibleProperty, new Binding("BackButtonIsVisible", BindingMode.TwoWay));
            
            MessagingCenter.Subscribe<object, NeedMoreInfo>(this, "NeedMoreInfo", async (sender, arg) =>
            {
                var nm = arg as NeedMoreInfo;
                var action = await DisplayActionSheet(nm.Title, "Cancel",null,nm.Options.ToArray());
                MessagingCenter.Send<object, string>(this, "NeedMoreInfoReply", action);
            });

        }
        #endregion

        #region Public Methods
        public static Page Create<TView, TViewModel>() where TView : MasterDetailControl, new()
            where TViewModel : MasterDetailControlViewModel, new()
        {
            return Create<TView, TViewModel>(new TViewModel());
        }

        public static Page Create<TView, TViewModel>(TViewModel viewModel) where TView : MasterDetailControl, new()
            where TViewModel : MasterDetailControlViewModel
        {
            try
            {
                var masterDetail = new TView();
                var navigationPage = new NavigationPage(masterDetail);
                viewModel.SetNavigation(navigationPage.Navigation);
                viewModel.Header = "Dashboard";
                viewModel.RightButton = string.Empty;
                masterDetail.BindingContext = viewModel;

                return navigationPage;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;

            }

        }
        #endregion

        #region Form Events
        protected override bool OnBackButtonPressed()
        {
            var viewModel = BindingContext as MasterDetailControlViewModel;
            if (viewModel != null)
            {
                var navigation = (INavigation)viewModel;
                navigation.PopAsync();
                return true;
            }
            return base.OnBackButtonPressed();
        }

        void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.UserSession.SideContentVisibility = (!App.UserSession.SideContentVisibility);
            //SideContentVisible = (!SideContentVisible);
            //SideContentVisible = _sideContentView;
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
