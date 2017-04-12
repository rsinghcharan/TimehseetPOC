using System;
using Xamarin.Forms;

using Xamarin.Forms.Platform.iOS;
using CoreAnimation;
using CoreGraphics;
using ZeroChaos.TimesheetPOC.iOS.Renderers;
using ZeroChaos.TimesheetPOC.Controls;
using UIKit;
[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace ZeroChaos.TimesheetPOC.iOS.Renderers
{
	public class CustomButtonRenderer : ButtonRenderer
	{
		public CustomButtonRenderer()
		{
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			var elementButton = this.Element as CustomButton;

			//
			UIButton thisButton = Control as UIButton;

			thisButton.TouchDown += delegate
						{
							System.Diagnostics.Debug.WriteLine("TouchDownEvent");
						};
			thisButton.TouchUpInside += delegate
			{
				System.Diagnostics.Debug.WriteLine("TouchUpEvent");
			};
			///
			if (elementButton.Type == Typeenum.Orange)
				Control.Layer.InsertSublayer(CreateGradientColor("#ffb85c", "#d25903", "#FFF6923F", Control.Bounds), 0);
			else if (elementButton.Type == Typeenum.Blue)
				Control.Layer.InsertSublayer(CreateGradientColor("#3c9ece", "#01446b", "#FFB95454", Control.Bounds), 0);
			else Control.Layer.InsertSublayer(CreateGradientColor("#3c9ece", "#01446b", "#FFB95454", Control.Bounds), 0);
		}

		private CAGradientLayer CreateGradientColor(string color1, string color2, string borderColor, CGRect bounds)
		{
			var gradient = new CAGradientLayer();
			gradient.Frame = bounds;
			gradient.Colors = new CoreGraphics.CGColor[] { Color.FromHex(color1).ToCGColor(), Color.FromHex(color2).ToCGColor() };
			//gradient.BorderColor = Color.FromHex(borderColor).ToCGColor();
			//gradient.BorderWidth = 2;
			return gradient;
		}


	}
}
