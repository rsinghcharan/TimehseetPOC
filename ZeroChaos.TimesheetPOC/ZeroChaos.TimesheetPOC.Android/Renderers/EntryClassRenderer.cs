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
using ZeroChaos.TimesheetPOC.Android.Renderers;
using ZeroChaos.TimesheetPOC.Controls;

[assembly: ExportRenderer(typeof(EntryClass), typeof(EntryClassRenderer))]
namespace ZeroChaos.TimesheetPOC.Android.Renderers
{
	public class EntryClassRenderer:EntryRenderer
	{
		public EntryClassRenderer()
		{ 
		}
			protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
			{
				base.OnElementChanged(e);
				Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
					}
	}
}
