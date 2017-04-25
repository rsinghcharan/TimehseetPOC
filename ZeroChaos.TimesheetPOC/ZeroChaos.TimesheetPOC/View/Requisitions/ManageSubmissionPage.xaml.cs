
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.ViewModel.CandidateCompare;

namespace ZeroChaos.TimesheetPOC
{
    public partial class ManageSubmissionPage : ContentPage
    {
        #region Private Members
        double columnWidth = 0;
        int noOfCandidates = 0;
        #endregion

        #region Constructors
        public ManageSubmissionPage()
        {
            InitializeComponent();
            GenerateComparisionGrid();
        }
        #endregion

        #region Public Methods
        #endregion

        #region Private Methods
        private void GenerateComparisionGrid()
        {
            var vm = new CandidatesCompareViewModel();
            var defaultWidth = (Device.Idiom == TargetIdiom.Phone) ? 150 : 180;            
            var rowHeight = (Device.Idiom == TargetIdiom.Phone) ? 60 : 120;

            #region Generate Rows
            RowDefinitionCollection tempRowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = 20 },
                    new RowDefinition { Height = (Device.Idiom == TargetIdiom.Phone) ? 120 : 150 },
                    new RowDefinition { Height = rowHeight },
                    new RowDefinition { Height = rowHeight },
                    new RowDefinition { Height = rowHeight },
                    new RowDefinition { Height = rowHeight },
                    new RowDefinition { Height = rowHeight },
                    new RowDefinition { Height = rowHeight },
                    new RowDefinition { Height = rowHeight },
                    new RowDefinition { Height = rowHeight },
                    new RowDefinition { Height = rowHeight },
                };

            compareGrid.RowDefinitions = tempRowDefinitions;
            #endregion

            #region Service call and data binding
            vm.GetCandidatesCompareData((res) =>
            {
                noOfCandidates = res.Candidates.Count;
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    columnWidth = (res.Candidates.Count < 3) ? App.Current.MainPage.Width / noOfCandidates : defaultWidth;
                }
                else
                {
                    if (App.Current.MainPage.Width > App.Current.MainPage.Height)
                    {
                        columnWidth = (noOfCandidates < 5) ? App.Current.MainPage.Width / noOfCandidates : defaultWidth;
                    }
                    else
                    {
                        columnWidth = (noOfCandidates < 4) ? App.Current.MainPage.Width / noOfCandidates : defaultWidth;
                    }
                }

                // compareGrid.SetBinding(Grid.BindingContextProperty, new Binding("res"));

                for (int i = 0; i <= res.Candidates.Count + 1; i++)
                {
                    ColumnDefinition col = new ColumnDefinition { Width = columnWidth };
                    compareGrid.ColumnDefinitions.Add(col);
                }

                BoxView blanckBoxView = new BoxView { Color = Color.FromHex("01446b") };
                Grid.SetRow(blanckBoxView, 0);
                Grid.SetColumn(blanckBoxView, 0);
                Grid.SetRowSpan(blanckBoxView, 2);
                compareGrid.Children.Add(blanckBoxView);

                //Submission Status
                BoxView submissionStatusBoxView = new BoxView { Color = Color.FromHex("3c9ece") };
                Grid.SetRow(submissionStatusBoxView, 2);
                Grid.SetColumn(submissionStatusBoxView, 0);
                compareGrid.Children.Add(submissionStatusBoxView);

                Label submissionStatusLabel = new Label
                {
                    Text = "Submission Status",
                    FontSize = 16,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White
                };

                Grid.SetRow(submissionStatusLabel, 2);
                Grid.SetColumn(submissionStatusLabel, 0);
                compareGrid.Children.Add(submissionStatusLabel);

                //Supplier Name
                BoxView supplierNameBoxView = new BoxView { Color = Color.FromHex("3c9ece") };
                Grid.SetRow(supplierNameBoxView, 3);
                Grid.SetColumn(supplierNameBoxView, 0);
                compareGrid.Children.Add(supplierNameBoxView);

                Label supplierNameLabel = new Label
                {
                    Text = "Supplier Name",
                    FontSize = 16,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White
                };
                Grid.SetRow(supplierNameLabel, 3);
                Grid.SetColumn(supplierNameLabel, 0);
                compareGrid.Children.Add(supplierNameLabel);

                //Diffrence From Target Rate
                BoxView diffFromTargetRateBoxView = new BoxView { Color = Color.FromHex("3c9ece") };
                Grid.SetRow(diffFromTargetRateBoxView, 4);
                Grid.SetColumn(diffFromTargetRateBoxView, 0);
                compareGrid.Children.Add(diffFromTargetRateBoxView);

                Label diffFromTargetRateLabel = new Label
                {
                    Text = "Difference From Target Rate",
                    FontSize = 16,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White
                };
                Grid.SetRow(diffFromTargetRateLabel, 4);
                Grid.SetColumn(diffFromTargetRateLabel, 0);
                compareGrid.Children.Add(diffFromTargetRateLabel);

                //Competencies
                BoxView competenciesBoxView = new BoxView { Color = Color.FromHex("3c9ece") };
                Grid.SetRow(competenciesBoxView, 5);
                Grid.SetColumn(competenciesBoxView, 0);
                compareGrid.Children.Add(competenciesBoxView);

                Label competenciesLabel = new Label
                {
                    Text = "Competencies",
                    FontSize = 16,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White
                };
                Grid.SetRow(competenciesLabel, 5);
                Grid.SetColumn(competenciesLabel, 0);
                compareGrid.Children.Add(competenciesLabel);

                //Certifications
                BoxView certificationsBoxView = new BoxView { Color = Color.FromHex("3c9ece") };
                Grid.SetRow(certificationsBoxView, 6);
                Grid.SetColumn(certificationsBoxView, 0);
                compareGrid.Children.Add(certificationsBoxView);

                Label certificationsLabel = new Label
                {
                    Text = "Certifications",
                    FontSize = 16,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White
                };
                Grid.SetRow(certificationsLabel, 6);
                Grid.SetColumn(certificationsLabel, 0);
                compareGrid.Children.Add(certificationsLabel);

                //Candidate Summary
                BoxView candidateSummaryBoxView = new BoxView { Color = Color.FromHex("3c9ece") };
                Grid.SetRow(candidateSummaryBoxView, 7);
                Grid.SetColumn(candidateSummaryBoxView, 0);
                compareGrid.Children.Add(candidateSummaryBoxView);

                Label candidateSummaryLabel = new Label
                {
                    Text = "Candidate Summary",
                    FontSize = 16,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White
                };
                Grid.SetRow(candidateSummaryLabel, 7);
                Grid.SetColumn(candidateSummaryLabel, 0);
                compareGrid.Children.Add(candidateSummaryLabel);

                //Candidate Location
                BoxView candidateLocationBoxView = new BoxView { Color = Color.FromHex("3c9ece") };
                Grid.SetRow(candidateLocationBoxView, 8);
                Grid.SetColumn(candidateLocationBoxView, 0);
                compareGrid.Children.Add(candidateLocationBoxView);

                Label candidateLocationLabel = new Label
                {
                    Text = "Candidate Location",
                    FontSize = 16,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White
                };
                Grid.SetRow(candidateLocationLabel, 8);
                Grid.SetColumn(candidateLocationLabel, 0);
                compareGrid.Children.Add(candidateLocationLabel);

                //Availability
                BoxView availabilityBoxView = new BoxView { Color = Color.FromHex("3c9ece") };
                Grid.SetRow(availabilityBoxView, 9);
                Grid.SetColumn(availabilityBoxView, 0);
                compareGrid.Children.Add(availabilityBoxView);

                Label availabilityLabel = new Label
                {
                    Text = "Availability",
                    FontSize = 16,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White
                };
                Grid.SetRow(availabilityLabel, 9);
                Grid.SetColumn(availabilityLabel, 0);
                compareGrid.Children.Add(availabilityLabel);


                //Active Submits
                BoxView activeSubmitsBoxView = new BoxView { Color = Color.FromHex("3c9ece") };
                Grid.SetRow(activeSubmitsBoxView, 10);
                Grid.SetColumn(activeSubmitsBoxView, 0);
                compareGrid.Children.Add(activeSubmitsBoxView);

                Label activeSubmitsLabel = new Label
                {
                    Text = "Active Submits",
                    FontSize = 16,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White
                };
                Grid.SetRow(activeSubmitsLabel, 10);
                Grid.SetColumn(activeSubmitsLabel, 0);
                compareGrid.Children.Add(activeSubmitsLabel);

                int gridColumns = 0;
                for (int j = 0; j < noOfCandidates; j++)
                {
                    gridColumns = j + 1;

                    BoxView moreInfoBoxView = new BoxView { Color = Color.FromHex("01446b") };
                    Label moreInfoLabel = new Label
                    {
                        Text = "....",
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.White
                    };
                    Grid.SetRow(moreInfoLabel, 0);
                    Grid.SetRow(moreInfoBoxView, 0);
                    Grid.SetColumn(moreInfoLabel, gridColumns);
                    Grid.SetColumn(moreInfoBoxView, gridColumns);
                    compareGrid.Children.Add(moreInfoBoxView);
                    compareGrid.Children.Add(moreInfoLabel);


                    StackLayout candidateBoxView = new StackLayout { BackgroundColor = Color.FromHex("3c9ece"), HeightRequest = (Device.Idiom == TargetIdiom.Phone) ? 120 : 150 };
                    Label candidateName = new Label
                    {
                        Text = res.Candidates[j].Name,
                        FontSize = 20,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Color.White
                    };
                    candidateBoxView.Children.Add(candidateName);

                    var userProfile = new Image { HeightRequest = (Device.Idiom == TargetIdiom.Phone) ? 80 : 120, WidthRequest = (Device.Idiom == TargetIdiom.Phone) ? 80 : 120, HorizontalOptions = LayoutOptions.Center, BackgroundColor = Color.Transparent };
                    userProfile.Source = ImageSource.FromFile("default_photo");
                    candidateBoxView.Children.Add(userProfile);

                    Grid.SetRow(candidateBoxView, 1);
                    Grid.SetColumn(candidateBoxView, gridColumns);
                    compareGrid.Children.Add(candidateBoxView);

                    Label submissionStatusValueLabel = new Label
                    {
                        Text = res.Candidates[j].SubmissionStatus,
                        FontSize = 16,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Black
                    };
                    Grid.SetRow(submissionStatusValueLabel, 2);
                    Grid.SetColumn(submissionStatusValueLabel, gridColumns);
                    compareGrid.Children.Add(submissionStatusValueLabel);

                    Label supplierNameValueLabel = new Label
                    {
                        Text = res.Candidates[j].SupplierName,
                        FontSize = 16,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Black
                    };
                    Grid.SetRow(supplierNameValueLabel, 3);
                    Grid.SetColumn(supplierNameValueLabel, gridColumns);
                    compareGrid.Children.Add(supplierNameValueLabel);

                    Label diffFromTargetRateValueLabel = new Label
                    {
                        Text = res.Candidates[j].TargetRateDifference,
                        FontSize = 16,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Black
                    };
                    Grid.SetRow(diffFromTargetRateValueLabel, 4);
                    Grid.SetColumn(diffFromTargetRateValueLabel, gridColumns);
                    compareGrid.Children.Add(diffFromTargetRateValueLabel);

                    Label competenciesValueLabel = new Label
                    {
                        //Text = res.Candidates[j].Competencies,
                        Text = string.Join(",", res.Candidates[j].Competencies.Select(X => X.ToString()).ToArray()),
                        FontSize = 16,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Black
                    };
                    Grid.SetRow(competenciesValueLabel, 5);
                    Grid.SetColumn(competenciesValueLabel, gridColumns);
                    compareGrid.Children.Add(competenciesValueLabel);

                    Label cetificationsValueLabel = new Label
                    {
                        Text = string.Join(",", res.Candidates[j].Certifications.Select(X => X.ToString()).ToArray()),
                        FontSize = 16,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Black
                    };
                    Grid.SetRow(cetificationsValueLabel, 6);
                    Grid.SetColumn(cetificationsValueLabel, gridColumns);
                    compareGrid.Children.Add(cetificationsValueLabel);

                    Label candidateSummaryValueLabel = new Label
                    {
                        Text = res.Candidates[j].Summary.FieldValue,
                        FontSize = 16,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Black
                    };
                    Grid.SetRow(candidateSummaryValueLabel, 7);
                    Grid.SetColumn(candidateSummaryValueLabel, gridColumns);
                    compareGrid.Children.Add(candidateSummaryValueLabel);

                    Label candidateLocationValueLabel = new Label
                    {
                        Text = res.Candidates[j].CandidateLocation,
                        FontSize = 16,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Black
                    };
                    Grid.SetRow(candidateLocationValueLabel, 8);
                    Grid.SetColumn(candidateLocationValueLabel, gridColumns);
                    compareGrid.Children.Add(candidateLocationValueLabel);

                    Label availableValueLabel = new Label
                    {
                        Text = res.Candidates[j].Availability,
                        FontSize = 16,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Black
                    };
                    Grid.SetRow(availableValueLabel, 9);
                    Grid.SetColumn(availableValueLabel, gridColumns);
                    compareGrid.Children.Add(availableValueLabel);

                    Label activeSubmitsValueLabel = new Label
                    {
                        Text = res.Candidates[j].ActiveSubmits,
                        FontSize = 16,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Black
                    };
                    Grid.SetRow(activeSubmitsValueLabel, 10);
                    Grid.SetColumn(activeSubmitsValueLabel, gridColumns);
                    compareGrid.Children.Add(activeSubmitsValueLabel);
                }
            });
            #endregion
        }
        #endregion
    }
}

