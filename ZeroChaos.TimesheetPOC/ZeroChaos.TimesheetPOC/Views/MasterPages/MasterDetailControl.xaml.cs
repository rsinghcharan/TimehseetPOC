#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
