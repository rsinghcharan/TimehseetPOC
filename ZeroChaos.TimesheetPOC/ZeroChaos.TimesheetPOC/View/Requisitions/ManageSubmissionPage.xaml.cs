
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
					new RowDefinition { Height = 40 },
					new RowDefinition { Height = (Device.Idiom == TargetIdiom.Phone) ? 150 : 180 },
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
					columnWidth = (noOfCandidates < 3) ? App.Current.MainPage.Width / noOfCandidates : defaultWidth;
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



				for (int i = 0; i < noOfCandidates + 1; i++)
				{
					ColumnDefinition col = new ColumnDefinition { Width = columnWidth };
					compareGrid.ColumnDefinitions.Add(col);
				}
				Debug.WriteLine("Number of Columns ==" + compareGrid.ColumnDefinitions.Count());

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
					///Here we tried setting Binding Context based on the response we have in each iteration
					//to make use of mvvm. however it consider last candidate for all columns generated.
					//Please help us here.
					//compareScrollView.BindingContext = res.Candidates[j];
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


					AbsoluteLayout candidateBoxView = new AbsoluteLayout { BackgroundColor = Color.FromHex("3c9ece"), HeightRequest = (Device.Idiom == TargetIdiom.Phone) ? 150 : 180, };
					Label candidateName = new Label
					{
						Text = res.Candidates[j].Name,
						FontSize = 20,
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						VerticalOptions = LayoutOptions.StartAndExpand,
						HorizontalTextAlignment = TextAlignment.Center,
						TextColor = Color.White,
					};
					//candidateName.SetBinding(Label.TextProperty, "Name");

					AbsoluteLayout.SetLayoutBounds(candidateName, new Rectangle(0.5, 0, 0.8, 0.4));
					AbsoluteLayout.SetLayoutFlags(candidateName, AbsoluteLayoutFlags.All);

					candidateBoxView.Children.Add(candidateName);

					var userProfile = new Image { HeightRequest = (Device.Idiom == TargetIdiom.Phone) ? 80 : 120, WidthRequest = (Device.Idiom == TargetIdiom.Phone) ? 80 : 120, HorizontalOptions = LayoutOptions.Center, BackgroundColor = Color.Transparent };
					userProfile.Source = ImageSource.FromFile("default_photo");

					AbsoluteLayout.SetLayoutBounds(userProfile, new Rectangle(0.5, 0.8, userProfile.HeightRequest, userProfile.WidthRequest));
					AbsoluteLayout.SetLayoutFlags(userProfile, AbsoluteLayoutFlags.PositionProportional);
					candidateBoxView.Children.Add(userProfile);

					Grid.SetRow(candidateBoxView, 1);
					Grid.SetColumn(candidateBoxView, gridColumns);
					compareGrid.Children.Add(candidateBoxView);


					BoxView submissionStatusValueBoxView = new BoxView { Color = Color.White, Margin = 0.5 };
					Grid.SetRow(submissionStatusValueBoxView, 2);
					Grid.SetColumn(submissionStatusValueBoxView, gridColumns);
					compareGrid.Children.Add(submissionStatusValueBoxView);

					Label submissionStatusValueLabel = new Label
					{
						Text = res.Candidates[j].SubmissionStatus,
						FontSize = 16,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
						TextColor = Color.Black
					};
					//submissionStatusValueLabel.SetBinding(Label.TextProperty, "SubmissionStatus");
					Grid.SetRow(submissionStatusValueLabel, 2);
					Grid.SetColumn(submissionStatusValueLabel, gridColumns);
					compareGrid.Children.Add(submissionStatusValueLabel);

					BoxView supplierNameValueBoxView = new BoxView { Color = Color.White, Margin = 0.5 };
					Grid.SetRow(supplierNameValueBoxView, 3);
					Grid.SetColumn(supplierNameValueBoxView, gridColumns);
					compareGrid.Children.Add(supplierNameValueBoxView);

					Label supplierNameValueLabel = new Label
					{
						Text = res.Candidates[j].SupplierName,
						FontSize = 16,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
						TextColor = Color.Black
					};
					//supplierNameValueLabel.SetBinding(Label.TextProperty, "SupplierName");
					Grid.SetRow(supplierNameValueLabel, 3);
					Grid.SetColumn(supplierNameValueLabel, gridColumns);
					compareGrid.Children.Add(supplierNameValueLabel);

					BoxView diffFromTargetRateValueBoxView = new BoxView { Color = Color.White, Margin = 0.5 };
					Grid.SetRow(diffFromTargetRateValueBoxView, 4);
					Grid.SetColumn(diffFromTargetRateValueBoxView, gridColumns);
					compareGrid.Children.Add(diffFromTargetRateValueBoxView);

					Label diffFromTargetRateValueLabel = new Label
					{
						Text = res.Candidates[j].TargetRateDifference,
						FontSize = 16,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
						TextColor = Color.Black
					};
					//diffFromTargetRateValueLabel.SetBinding(Label.TextProperty, "TargetRateDifference");

					Grid.SetRow(diffFromTargetRateValueLabel, 4);
					Grid.SetColumn(diffFromTargetRateValueLabel, gridColumns);
					compareGrid.Children.Add(diffFromTargetRateValueLabel);

					BoxView competenciesValueBoxView = new BoxView { Color = Color.White, Margin = 0.5 };
					Grid.SetRow(competenciesValueBoxView, 5);
					Grid.SetColumn(competenciesValueBoxView, gridColumns);
					compareGrid.Children.Add(competenciesValueBoxView);

					Label competenciesValueLabel = new Label
					{
						Text = res.Candidates[j].CandidateCompantencies,
						FontSize = 16,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
						TextColor = Color.Black
					};
					//competenciesValueLabel.SetBinding(Label.TextProperty, "CandidateCompantencies");
					Grid.SetRow(competenciesValueLabel, 5);
					Grid.SetColumn(competenciesValueLabel, gridColumns);
					compareGrid.Children.Add(competenciesValueLabel);

					BoxView cetificationsValueBoxView = new BoxView { Color = Color.White, Margin = 0.5 };
					Grid.SetRow(cetificationsValueBoxView, 6);
					Grid.SetColumn(cetificationsValueBoxView, gridColumns);
					compareGrid.Children.Add(cetificationsValueBoxView);

					Label cetificationsValueLabel = new Label
					{
						Text = res.Candidates[j].CandidateCertifications,
						FontSize = 16,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
						TextColor = Color.Black
					};
					//cetificationsValueLabel.SetBinding(Label.TextProperty, "CandidateCertifications");
					Grid.SetRow(cetificationsValueLabel, 6);
					Grid.SetColumn(cetificationsValueLabel, gridColumns);
					compareGrid.Children.Add(cetificationsValueLabel);

					BoxView candidateSummaryValueBoxView = new BoxView { Color = Color.White, Margin = 0.5 };
					Grid.SetRow(candidateSummaryValueBoxView, 7);
					Grid.SetColumn(candidateSummaryValueBoxView, gridColumns);
					compareGrid.Children.Add(candidateSummaryValueBoxView);

					Label candidateSummaryValueLabel = new Label
					{
						Text = res.Candidates[j].Summary.FieldValue,
						FontSize = 16,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
						TextColor = Color.Black
					};
					//candidateSummaryValueLabel.SetBinding(Label.TextProperty, "Summary.FieldValue");
					Grid.SetRow(candidateSummaryValueLabel, 7);
					Grid.SetColumn(candidateSummaryValueLabel, gridColumns);
					compareGrid.Children.Add(candidateSummaryValueLabel);

					//Frame candidateLocationContainer = new Frame { BackgroundColor = Color.White, OutlineColor = Color.Black, HeightRequest = rowHeight, CornerRadius = 0, HasShadow = false};
					BoxView candidateLocationContainerBox = new BoxView
					{
						BackgroundColor = Color.White,
						Margin = 0.5
					};
					Label candidateLocationValueLabel = new Label
					{
						Text = res.Candidates[j].CandidateLocation,
						FontSize = 16,
						Margin = 2,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
						TextColor = Color.Black
					};
					//candidateLocationValueLabel.SetBinding(Label.TextProperty, "CandidateLocation");

					Grid.SetRow(candidateLocationContainerBox, 8);
					Grid.SetColumn(candidateLocationContainerBox, gridColumns);
					compareGrid.Children.Add(candidateLocationContainerBox);

					Grid.SetRow(candidateLocationValueLabel, 8);
					Grid.SetColumn(candidateLocationValueLabel, gridColumns);
					compareGrid.Children.Add(candidateLocationValueLabel);

					BoxView availableValueBoxView = new BoxView { Color = Color.White, Margin = 0.5 };
					Grid.SetRow(availableValueBoxView, 9);
					Grid.SetColumn(availableValueBoxView, gridColumns);
					compareGrid.Children.Add(availableValueBoxView);
					Label availableValueLabel = new Label
					{
						Text = res.Candidates[j].Availability,
						FontSize = 16,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
						TextColor = Color.Black
					};
					//availableValueLabel.SetBinding(Label.TextProperty, "Availability");
					Grid.SetRow(availableValueLabel, 9);
					Grid.SetColumn(availableValueLabel, gridColumns);
					compareGrid.Children.Add(availableValueLabel);

					BoxView activeSubmitsValueBoxView = new BoxView { Color = Color.White, Margin = 0.5 };
					Grid.SetRow(activeSubmitsValueBoxView, 10);
					Grid.SetColumn(activeSubmitsValueBoxView, gridColumns);
					compareGrid.Children.Add(activeSubmitsValueBoxView);

					Label activeSubmitsValueLabel = new Label
					{
						Text = res.Candidates[j].ActiveSubmits,
						FontSize = 16,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						VerticalTextAlignment = TextAlignment.Center,
						TextColor = Color.Black
					};
					//activeSubmitsValueLabel.SetBinding(Label.TextProperty, "ActiveSubmits");
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