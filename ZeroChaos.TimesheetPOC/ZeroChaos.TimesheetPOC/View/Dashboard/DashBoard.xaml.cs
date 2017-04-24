#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeroChaos.TimesheetPOC.Models;
#endregion

namespace ZeroChaos.TimesheetPOC.Views.Dashboard
{
    /// <summary>
    /// DashBoard partial class
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class DashBoard
    {
        #region Private members
        PickerDataSource.DashboardItems dashBoardData;
        string colorName;
        string test;
        #endregion

        #region Constructors
        public DashBoard()
        {
            InitializeComponent();
            int userType = App.UserSession.LoggedonUser.userType;
            var dashBoardDataCollection = handleUserDashboardData(userType);
            loadDashboard(dashBoardDataCollection, userType);
        }
        #endregion

        #region Public Methods
        public PickerDataSource.DashboardItems handleUserDashboardData(int userType)
        {
            switch (userType)
            {
                case 2:
                    dashBoardData = PickerDataSource.getManagerData();
                    break;
                case 1:
                    dashBoardData = PickerDataSource.getResourceData();
                    break;
                case 10:
                    dashBoardData = PickerDataSource.getSupplierData();
                    break;
                default:
                    break;
            }
            return dashBoardData;
        }
        public void loadDashboard(PickerDataSource.DashboardItems dashboardItems, int userType)
        {
            try
            {
                List<PickerDataSource.Student> sortedDashboardData = new List<PickerDataSource.Student>();

                //Reset the tiles beforeLoad new one
                leftTitleView.Children.Clear();
                rightTitleView.Children.Clear();
                double totalTilesCount = dashBoardData.dashboardItems.Count;
                int count = 0;
                /*var tapGestureRecognizerForGridTile = new TapGestureRecognizer();
                tapGestureRecognizerForGridTile.Tapped += (s, e) =>
                {
                 ContentView contentViewContainer = s as ContentView;
                 DisplayAlert("Dashboard", "Your StyleId =" + contentViewContainer.StyleId, "OK");
                }*/
                //Here first we short the array based onthe buble count we have so all tiles having bubble count are at top postion in list

                sortedDashboardData = dashBoardData.dashboardItems.OrderByDescending(p => p.BubbleCount).ToList();
                dashBoardData.dashboardItems = sortedDashboardData;
                //Here we will get the logo itme from the list because we have to put it at end of the list
                var zcLogoItem = dashBoardData.dashboardItems.Find(x => x.Title == null);
                //So we will remove it from list and put it again at end position
                dashBoardData.dashboardItems.RemoveAll(x => x.Title == null);
                //Put the logo itme at the end
                dashBoardData.dashboardItems.Add(zcLogoItem);

                double tilesInColumn1;
                double totalTilesNumber = (double)totalTilesCount / 2;
                bool checkNumberFloatType = (totalTilesNumber % 1 == 0) ? false : true;
                if (checkNumberFloatType)
                {
                    tilesInColumn1 = Math.Floor(totalTilesNumber);
                }
                else
                {
                    tilesInColumn1 = totalTilesNumber - 1;
                }
                tilesInColumn1 = tilesInColumn1 < 2 ? 2 : tilesInColumn1;
                double getHeightForColumn1 = getTitleHeight(1, tilesInColumn1, totalTilesCount);
                double getHeightForColumn2 = getTitleHeight(2, totalTilesCount - tilesInColumn1, totalTilesCount);
                double heightInColumn1 = getHeightForColumn1 > getHeightForColumn2 ? getHeightForColumn1 : getHeightForColumn2;//tilesInColumn1 > 4 ? (getHeightForColumn1 > getHeightForColumn2 ? getHeightForColumn1 : getHeightForColumn2) : getHeightForColumn1;
                double tilesInColumn2 = totalTilesCount - tilesInColumn1;
                double heightInColumn2 = getHeightForColumn1 < getHeightForColumn2 ? getHeightForColumn1 : getHeightForColumn2;//tilesInColumn2 > 4 ? (getHeightForColumn1 < getHeightForColumn2 ? getHeightForColumn1 : getHeightForColumn2) : getHeightForColumn2;

                foreach (var item in dashboardItems.dashboardItems)
                {

                    if (count < tilesInColumn1)
                    {
                        colorName = PickerDataSource.getRightTileColors()[count];
                        GridTile title = new GridTile(item, colorName, heightInColumn1);
                        //title.GestureRecognizers.Add(tapGestureRecognizerForGridTile);
                        leftTitleView.Children.Add(title);
                    }
                    else
                    {
                        colorName = PickerDataSource.getLeftTileColors()[count];
                        GridTile title = new GridTile(item, colorName, heightInColumn2);
                        //title.GestureRecognizers.Add(tapGestureRecognizerForGridTile);
                        rightTitleView.Children.Add(title);

                    }
                    /*if (count.Equals(0)) { 
                     break;
                    }*/
                    count++;
                }

            }
            catch (Exception ex)
            {

            }

        }

        public static double getTitleHeight(int columnType, double itemsInColumn, double totalItems)
        {
            double mainValue = 0;
            double returnValue = 0;

            if (Device.Idiom == TargetIdiom.Phone)
            {
                mainValue = totalItems < 11 ? 500 : (totalItems < 12 ? 420 : 450);//250: 400
            }
            else
            {
                mainValue = (totalItems < 11 ? ((Device.OS == TargetPlatform.iOS) ? 750 : 450) : 650);
            }

            if (totalItems > 7)
            {
                returnValue = (itemsInColumn * mainValue / totalItems);
            }
            else
            {
                //Get Device Height
                double deviceHeight = Application.Current.MainPage.Bounds.Height;
                returnValue = (itemsInColumn.Equals(2)) ? deviceHeight / 2 : (itemsInColumn.Equals(3) ? deviceHeight / 3 : deviceHeight / 4);
            }
            return returnValue;
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
