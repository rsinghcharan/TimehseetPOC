using System;
using Xamarin.Forms;

namespace ZeroChaos.TimesheetPOC.Controls
{
	public class CustomButton : Button
	{
		public CustomButton()
		{
			this.FontSize = 16;// Device.OnPlatform(20, 25, 20);
							   //this.HeightRequest=40;
			this.TextColor = Color.White;
		}
		public string Type { get; set; }
	}
}
