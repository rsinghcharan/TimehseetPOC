using System;
using System.Diagnostics.Contracts;
using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Series;
namespace ZeroChaos.TimesheetPOC
{
	public class EngagementSpendSummaryViewModel
	{
		public PlotModel PieModel { get; set; }

		public EngagementSpendSummaryViewModel()
		{
			PieModel = CreatePieChart();

		}
		private PlotModel CreatePieChart()
		{
			Contract.Ensures(Contract.Result<PlotModel>() != null);
			var model = new PlotModel { Title = "Spend Summary" };


			var ps = new PieSeries
			{
				//StrokeThickness = .25,
				//InsideLabelPosition = .25,

				//AngleSpan = 360,
				//StartAngle = 0
			};
			//model.IsLegendVisible = false;
			//model.LegendPlacement = LegendPlacement.Outside;
			//InsideLabelFormat = "";
			//model.LegendPosition = LegendPosition.BottomCenter;
			//ps.LegendFormat = ;
			//ps.OutsideLabelFormat = "{1}";
			//ps.InsideLabelColor = OxyColors.Automatic;
			//ps.InsideLabelFormat = null;
			//ps.InsideLabelPosition = 0.0;
			//ps.InsideLabelFormat = "{0}";
			//ps.LegendFormat = "{1}: {0}";
			//model.LegendPosition = LegendPosition.TopLeft;
			//ps.InsideLabelPosition = 0.0;

			//ps.TickDistance = 0;
			//ps.TickRadialLength = 6;

			//model.LegendOrientation = LegendOrientation.Horizontal;
			//model.LegendPlacement = LegendPlacement.Outside;
			//model.LegendPosition = LegendPosition.TopRight;
			//model.LegendPlacement = LegendPlacement.Outside;
			//model.LegendItemOrder = LegendItemOrder.Normal;
			//model.LegendColumnSpacing = 1;ps.Slices.Add(new PieSlice("gujarat", 1030) { IsExploded = false });
			ps.Slices.Add(new PieSlice("Americas", 929) { Fill = OxyColors.DarkBlue });
			ps.Slices.Add(new PieSlice("Asia", 4157) { Fill = OxyColors.LightBlue });


			model.LegendTitle = "I am a Legend";
			model.IsLegendVisible = true;
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
