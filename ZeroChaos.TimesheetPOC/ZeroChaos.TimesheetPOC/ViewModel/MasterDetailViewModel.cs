﻿#region 
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Controls;
using ZeroChaos.TimesheetPOC.Views;
using ZeroChaos.TimesheetPOC.ViewModel.Timesheet;
using ZeroChaos.TimesheetPOC.Views.Dashboard;
using ZeroChaos.TimesheetPOC.Views.Timesheet;
using Zerochaos.Util.POC.Messages;
#endregion
namespace ZeroChaos.TimesheetPOC.ViewModel
{
    public class MasterDetailViewModel : MasterDetailControlViewModel
    {
        public MasterDetailViewModel()
        {
            Detail = new DashBoard();
            MessagingCenter.Subscribe<object, string>(this, "NeedMoreInfoReply", NeedMoreInfoResponse);
        }


        private ICommand _NeedMoreInfo;

        public ICommand NeedMoreInfo
        {
            get
            {
                return _NeedMoreInfo ?? (_NeedMoreInfo = new Command(() =>
          {
              //var action = await DisplayActionSheet("More Information", "Cancel", null, "Notes", "Adjustment Track", "Track Codes", "Attachments", "Additional Information");

              string title = "More Information";
              List<string> Options = new List<string>() { "Notes", "Track Codes", "Attachments" };
              NeedMoreInfo nm = new NeedMoreInfo("More Information", Options);

              MessagingCenter.Send<object, NeedMoreInfo>(this, "NeedMoreInfo", nm);
              // Detail = new TimesheetActionList();
          }));
            }
            set { _NeedMoreInfo = value; }
        }


        private ObservableCollection<AccordionSource> _Checking;

        public ObservableCollection<AccordionSource> Checking
        {
            get { return _Checking ?? (_Checking = new ObservableCollection<AccordionSource>()); }
            set { _Checking = value; OnPropertyChanged(); }
        }
        public List<AccordionSource> GetSampleData()
        {
            var vResult = new List<AccordionSource>();


            foreach (var item in PreparedObject())
            {

                Grid gd = new Grid();
                // gd.BackgroundColor = Color.FromHex("#01446b");
                if (item.ChildItemList.Count > 0)
                {
                    foreach (var child in item.ChildItemList)
                    {
                        gd.RowDefinitions.Add(new RowDefinition { Height = 25 });

                    }
                    if (item.ChildItemList.Any(q => q.BubbleCount > 0))
                    {
                        gd.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                        Device.OnPlatform(iOS: () =>
                        {
                            gd.ColumnDefinitions.Add(new ColumnDefinition { Width = 25 });
                        }, Android: () =>
                        {
                            gd.ColumnDefinitions.Add(new ColumnDefinition { Width = 30 });
                        });


                    }
                    int rowCount = 0;
                    foreach (var actual in item.ChildItemList)
                    {
                        Label lbl = new Label();
                        lbl.Text = actual.TextValue;
                        //lbl.HeightRequest = 30;
                        lbl.StyleId = actual.DataValue;
                        lbl.Margin = new Thickness(5, 0, 0, 0);
                        lbl.TextColor = Color.FromHex("#c1eaf6");

                        TapGestureRecognizer tg = new TapGestureRecognizer();
                        tg.Tapped += (ea, sa) =>
                        {

                            var label = ea as Label;
                            if (label.Text == "Dashboard")
                            {
                                Detail = new DashBoard();
                                Header = "DashBoard";
                                RightButton = "";
                            }
                            else if (label.Text == "View Timesheet")
                            {
                                var page = new ViewTimesheetPage();
                                Header = "View Timesheet";
                                RightButton = string.Empty;
                                ViewTimesheetViewModel vm = new ViewTimesheetViewModel();
                                vm.MasterDetailViewModel = this;
                                page.BindingContext = vm;
                                Detail = page;
                            }
                            else
                            {
                                var obj = new ViewTimesheetPage();
                                // obj.LblText = label.Text;

                                TapGestureRecognizer td = new TapGestureRecognizer();
                                td.Tapped += (ss, se) =>
                                {
                                    //Detail = new Detail1();
                                };

                                Header = "View Timesheet";
                                RightButton = "...";
                                // obj.lbl.GestureRecognizers.Add(td);
                                Detail = obj;

                            }
                            App.UserSession.SideContentVisibility = (!App.UserSession.SideContentVisibility);
                            OnPropertyChanged("SideContentVisible");
                        };
                        lbl.GestureRecognizers.Add(tg);
                        Grid.SetRow(lbl, rowCount);
                        if (actual.BubbleCount > 0)
                        {
                            BoxView bx = new BoxView();
                            bx.HeightRequest = 5;
                            bx.WidthRequest = 5;

                            bx.BackgroundColor = Color.White;
                            Grid.SetColumn(bx, 1);
                            Grid.SetRow(bx, rowCount);

                            gd.Children.Add(bx);

                            Label bubblecount = new Label();
                            //bubblecount.HeightRequest = 10;
                            //bubblecount.WidthRequest = 10;
                            bubblecount.Text = actual.BubbleCount.ToString();
                            bubblecount.VerticalTextAlignment = TextAlignment.Center;
                            bubblecount.HorizontalOptions = LayoutOptions.Center;
                            bubblecount.VerticalOptions = LayoutOptions.Center;

                            Grid.SetColumn(bubblecount, 1);
                            Grid.SetRow(bubblecount, rowCount);
                            gd.Children.Add(bubblecount);
                            /*Button bubblecount = new Button();
                            bubblecount.BackgroundColor = Color.White;
                            //bubblecount.HeightRequest = 25;
                            Device.OnPlatform(iOS: () =>
                            {
                                bubblecount.HeightRequest = 20;
                                bubblecount.WidthRequest = 20;
                            }, Android: () =>
                            {
                                
                            });

                            bubblecount.BorderRadius = 5;
                            bubblecount.HorizontalOptions = LayoutOptions.Fill;
                            bubblecount.Text = actual.BubbleCount.ToString();
                             //bubblecount.HorizontalOptions = LayoutOptions.End;
                            bubblecount.VerticalOptions = LayoutOptions.Center;
                            bubblecount.FontSize = 12;
                            
                            Grid.SetColumn(bubblecount, 1);
                            Grid.SetRow(bubblecount, rowCount);
                            gd.Children.Add(bubblecount);*/
                        }
                        gd.Children.Add(lbl);
                        rowCount++;
                    }

                    vResult.Add(new AccordionSource
                    {
                        HeaderText = item.HeaderText,
                        HeaderTextColor = Color.FromHex("#c1eaf6"),
                        HeaderBackGroundColor = Color.FromHex("#3c9ece"),
                        ContentItems = gd
                    });
                }
                else
                {
                    vResult.Add(new AccordionSource
                    {
                        HeaderText = item.HeaderText,
                        HeaderTextColor = Color.FromHex("#c1eaf6"),
                        HeaderBackGroundColor = Color.FromHex("#3c9ece"),
                        ContentItems = gd
                    });
                }
            }

            return vResult;
        }

        private List<SimpleObject> PreparedObject()
        {
            var dummyData = new List<SimpleObject>();
            SimpleObject obj = new SimpleObject();
            obj.HeaderText = "Timesheet";
            obj.ChildItemList.Add(new ChildItems { TextValue = "View Timesheet", DataValue = "T1" });
            obj.ChildItemList.Add(new ChildItems { TextValue = "Create Timesheet", DataValue = "T2", BubbleCount = 5 });
            dummyData.Add(obj);

            obj = new SimpleObject();
            obj.HeaderText = "Expense";
            obj.ChildItemList.Add(new ChildItems { TextValue = "View Expense Report", DataValue = "E1" });
            obj.ChildItemList.Add(new ChildItems { TextValue = "Create Expense Report", DataValue = "E2" });
            obj.ChildItemList.Add(new ChildItems { TextValue = "Approve Expense Report", DataValue = "E3", BubbleCount = 2 });
            dummyData.Add(obj);

            obj = new SimpleObject();
            obj.HeaderText = "Payment";
            obj.ChildItemList.Add(new ChildItems { TextValue = "View Payment History", DataValue = "P1" });
            dummyData.Add(obj);

            obj = new SimpleObject();
            obj.HeaderText = "Dossier";
            obj.ChildItemList.Add(new ChildItems { TextValue = "Information", DataValue = "D1" });
            obj.ChildItemList.Add(new ChildItems { TextValue = "Security", DataValue = "D2" });
            obj.ChildItemList.Add(new ChildItems { TextValue = "Contact Us", DataValue = "D3" });
            dummyData.Add(obj);

            obj = new SimpleObject();
            obj.HeaderText = "Dashboard";
            obj.ChildItemList.Add(new ChildItems { TextValue = "Dashboard", DataValue = "D1" });
            dummyData.Add(obj);

            obj = new SimpleObject();
            obj.HeaderText = "Logout";
            dummyData.Add(obj);

            return dummyData;
        }

        private void NeedMoreInfoResponse(object sender, string selectedaction)
        {
            if (selectedaction == "Track Codes")
                Detail = new TimesheetTrackCode();
        }
    }
    public class SimpleObject
    {
        public SimpleObject()
        {
            ChildItemList = new List<ChildItems>();
        }
        public string HeaderText { get; set; }
        public List<ChildItems> ChildItemList { get; set; }
    }
    public class ChildItems
    {
        public string TextValue { get; set; }
        public string DataValue { get; set; }
        public int BubbleCount { get; set; }
    }
    public class ListDataViewCell : ViewCell
    {
        public ListDataViewCell()
        {


            var label = new Label()
            {
                Font = Font.SystemFontOfSize(NamedSize.Default),
                TextColor = Color.FromHex("#c1eaf6"),
                Margin = new Thickness(3, 0, 0, 0)

            };
            label.SetBinding(Label.TextProperty, new Binding("TextValue"));
            label.SetBinding(Label.ClassIdProperty, new Binding("DataValue"));
            View = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                // Padding = new Thickness(12, 8),
                Children = { label },
                BackgroundColor = Color.FromHex("#01446b")
            };
        }
    }


}
