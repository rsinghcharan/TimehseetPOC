using System;
using System.Diagnostics.Contracts;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
using ZeroChaos.TimesheetPOC.ViewModel;
using ZeroChaos.TimesheetPOC.IServices;
using ZeroChaos.TimesheetPOC.Services;
using ZeroChaos.TimesheetPOC.Model.Request.Engagement;
using ZeroChaos.TimesheetPOC.Model.Response.Engagement;

namespace ZeroChaos.TimesheetPOC.ViewModel
{
	public class EngagementSpendSummaryViewModel:BaseViewModel
	{
        private IServiceCaller service;
        private PlotModel _PieModel;

        public PlotModel PieModel
        {
            get { return _PieModel; }
            set { _PieModel = value; RaisePropertyChanged(); }
        }
        private GetSOWEngagementSpendSummaryResponse _SummaryDetails;

        public GetSOWEngagementSpendSummaryResponse SummaryDetails
        {
            get { return _SummaryDetails ?? (_SummaryDetails=new GetSOWEngagementSpendSummaryResponse()); }
            set { _SummaryDetails = value; RaisePropertyChanged(); }
        }
       


        public EngagementSpendSummaryViewModel()
		{
            service = new ServiceCaller();
            var request = new GetEngagementSpendSummaryRequest() {ClientID=5000,EngagementID= 48478,loggedonUser=App.UserSession.LoggedonUser };
            service.CallHostService<GetEngagementSpendSummaryRequest, GetSOWEngagementSpendSummaryResponse>(request, "GetEngagementSpendSummaryRequest", val => 
            {
                SummaryDetails = val;
				PieModel = CreatePieChart();
            });
            
           
		}
		public PlotModel CreatePieChart()
		{
			Contract.Ensures(Contract.Result<PlotModel>() != null);
			var model = new PlotModel { Title = "Distribution of Approved Budget" , TextColor=OxyColors.Gray};
			var ps = new PieSeries
			{
				//StrokeThickness = .25,
				//InsideLabelPosition = .25,

				//AngleSpan = 360,
				//StartAngle = 0
			};

			ps.Slices.Add(new PieSlice("", Convert.ToDouble(SummaryDetails.PercentageSpendRemaining)) { Fill = OxyColor.Parse("#007DCC") });
			ps.Slices.Add(new PieSlice("", Convert.ToDouble(SummaryDetails.PercentageSpendUsed)) { Fill = OxyColor.Parse("#46BFBD") });
			ps.InsideLabelFormat = "{2:0.0} %";
			ps.InsideLabelColor = OxyColors.Black;
			ps.OutsideLabelFormat = null;

			model.LegendTitle = "I am a Legend";
			model.IsLegendVisible = false;
			model.LegendOrientation = LegendOrientation.Vertical;
			model.LegendPlacement = LegendPlacement.Outside;
			model.LegendPosition = LegendPosition.TopRight;

			/*model.LegendPlacement = LegendPlacement.Inside;
			model.LegendPosition = LegendPosition.RightTop;
			model.LegendPlacement = LegendPlacement.Outside;
			model.LegendMaxWidth = 200;*/
			model.Series.Add(ps);

			return model;
		}

	}
}
