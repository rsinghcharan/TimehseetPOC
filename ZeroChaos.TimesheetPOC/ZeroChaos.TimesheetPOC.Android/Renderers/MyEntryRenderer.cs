using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ZeroChaos.TimesheetPOC;
using ZeroChaos.TimesheetPOC.Droid;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace ZeroChaos.TimesheetPOC.Droid
{
	public class MyEntryRenderer : EntryRenderer
	{

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);

			}
		}

	}
}

