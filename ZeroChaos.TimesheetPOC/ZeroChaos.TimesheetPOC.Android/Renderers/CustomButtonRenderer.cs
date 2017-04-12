using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using ZeroChaos.TimesheetPOC.Controls;
using ZeroChaos.TimesheetPOC.Droid.Renderers;

[assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
namespace ZeroChaos.TimesheetPOC.Droid.Renderers
{
	public class CustomButtonRenderer:ButtonRenderer
	{
		public CustomButtonRenderer()
		{
			
		} 
		  
				protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
				{
					base.OnElementChanged(e);

					var elementButton = this.Element as CustomButton;
						//var button = this.Control;
						//button.SetAllCaps(false);

						Android.Widget.Button thisButton = Control as Android.Widget.Button;
						thisButton.SetAllCaps(false);
						thisButton.Touch += (object sender, Android.Views.View.TouchEventArgs e2) =>
						            {
										if (e2.Event.Action == MotionEventActions.Down)
										{
											System.Diagnostics.Debug.WriteLine("TouchDownEvent");
					                 // Toast.MakeText(this, "Key Up", ToastLength.Short).Show();

										}
										else if (e2.Event.Action == MotionEventActions.Up)
										{
											

											System.Diagnostics.Debug.WriteLine("TouchUpEvent");
											Control.CallOnClick();
										}
						            };
			      // CustomButton.SetAllCaps(false);
					if (elementButton.Type == Typeenum.Orange)
						Control.SetBackgroundDrawable(CreateGradientColor("#ffb85c", "#d25903", "#FFF6923F"));
					else if (elementButton.Type == Typeenum.Blue)
						Control.SetBackgroundDrawable(CreateGradientColor("#3c9ece", "#01446b", "#FFB95454"));
					else Control.SetBackgroundDrawable(CreateGradientColor("#3c9ece", "#01446b", "#FF98B954"));
				}

		private GradientDrawable CreateGradientColor(string color1, string color2, string borderColor)
		{
			GradientDrawable gd = new GradientDrawable(
			GradientDrawable.Orientation.TopBottom,
			new int[] { Color.FromHex(color1).ToAndroid().ToArgb(), Color.FromHex(color2).ToAndroid().ToArgb() });
			//gd.SetCornerRadius(0f);
			//gd.SetStroke(5, Color.FromHex(borderColor).ToAndroid());
			return gd;
			}
					}
}
