using System;
using Xamarin.Forms;

using Xamarin.Forms.Platform.iOS;
using CoreAnimation;
using CoreGraphics;
using ZeroChaos.TimesheetPOC.iOS.Renderers;
using ZeroChaos.TimesheetPOC.Controls;
using UIKit;
[assembly: ExportRenderer(typeof(EntryClass), typeof(EntryClassRenderer))]
namespace ZeroChaos.TimesheetPOC.iOS.Renderers
{
	public class EntryClassRenderer:EntryRenderer
	{
		public EntryClassRenderer()
		{
		}

			protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
			{
				base.OnElementChanged(e);

				if (this.Control == null) return;

			this.Control.BorderStyle = UITextBorderStyle.None;
			}
	}
}
