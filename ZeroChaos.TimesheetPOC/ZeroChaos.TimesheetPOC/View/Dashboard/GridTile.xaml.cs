#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Models;
using ZeroChaos.TimesheetPOC.ViewModel;
using ZeroChaos.TimesheetPOC.Views;
using ZeroChaos.TimesheetPOC.Views.Timesheet;
#endregion

namespace ZeroChaos.TimesheetPOC.Views.Dashboard
{
    public partial class GridTile : ContentView
    {
        public GridTile()
        {
            InitializeComponent();
        }
        public GridTile(PickerDataSource.Student item, string colorName, double columnHeight)
        {
            InitializeComponent();
            try
            {
                //Convert Actual color from hexadecimal value
                var converter = new ColorTypeConverter();
                Color bgColor = (Color)converter.ConvertFromInvariantString(colorName);
                tileView.BackgroundColor = string.IsNullOrEmpty(item.Title) ? Color.White : bgColor;

                tileView.StyleId = item.StyleID;
                imageName.Source = ImageSource.FromFile(item.ImageName);
                titleName.FontSize = Device.Idiom == TargetIdiom.Phone ? 22 : 28;
                titleName.Text = item.Title;

                bubleConainer.IsVisible = item.BubbleCount > 0 ? true : false;
                bubbleCount.FontSize = Device.Idiom == TargetIdiom.Phone ? 16 : 32;
                bubleConainer.WidthRequest = Device.Idiom == TargetIdiom.Phone ? 20 : 40;
                bubleConainer.HeightRequest = Device.Idiom == TargetIdiom.Phone ? 20 : 40;
                bubbleCount.Text = item.BubbleCount.ToString();
                tileView.HeightRequest = columnHeight;

                var tapGestureRecognizerForGridTile = new TapGestureRecognizer();
                tapGestureRecognizerForGridTile.Tapped += (s, e) =>
                {
                    ContentView contentViewContainer = s as ContentView;
					if(contentViewContainer.StyleId =="view-timesheet")
					{
						var BC= BindingContext as MasterDetailViewModel;
						BC.Header = "View Timesheet";
						BC.RightButton = "";
						var page = new ViewTimesheetPage();
						BC.Detail = page;
						
					}
                    
                };
                tileView.GestureRecognizers.Add(tapGestureRecognizerForGridTile);
            }
            catch (Exception ex)
            {

            }

        }
    }
}
