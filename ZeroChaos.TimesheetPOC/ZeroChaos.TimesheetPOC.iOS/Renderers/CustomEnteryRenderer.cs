using System;
using System.ComponentModel;
using CoreAnimation;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ZeroChaos.TimesheetPOC.Views.Login;

[assembly: ExportRenderer(typeof(ZeroChaos.TimesheetPOC.iOS.LineEntry), typeof(ZeroChaos.TimesheetPOC.iOS.CustomEnteryRenderer.LineEntryRenderer))]
namespace ZeroChaos.TimesheetPOC.iOS
{
	public class CustomEnteryRenderer : ContentPage
	{
		public class LineEntryRenderer : EntryRenderer
		{
			protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
			{
				base.OnElementChanged(e);

				if (Control != null)
				{
					Control.BorderStyle = UITextBorderStyle.None;

					var view = (Element as LineEntry);
					if (view != null)
					{
						DrawBorder(view);
						SetFontSize(view);
						SetPlaceholderTextColor(view);
					}
				}
			}

			protected override void OnElementPropertyChanged(LineEntryRenderer instance, object sender, PropertyChangedEventArgs e)
			{
				base.OnElementPropertyChanged(sender, e);

				var view = (LineEntry)Element;

				if (e.PropertyName.Equals(view.BorderColor))
					instance.DrawBorder(view);
				if (e.PropertyName.Equals(view.FontSize))
					instance.SetFontSize(view);
				if (e.PropertyName.Equals(view.PlaceholderColor))
					instance.SetPlaceholderTextColor(view);
			}

			void DrawBorder(LineEntry view)
			{
				var borderLayer = new CALayer();
				borderLayer.MasksToBounds = true;
				borderLayer.Frame = new CoreGraphics.CGRect(0f, Frame.Height / 2, Frame.Width, 1f);
				borderLayer.BorderColor = view.BorderColor.ToCGColor();
				borderLayer.BorderWidth = 1.0f;

				Control.Layer.AddSublayer(borderLayer);
				Control.BorderStyle = UITextBorderStyle.None;
			}

			void SetFontSize(LineEntry view)
			{
				if (view.FontSize != Font.Default.FontSize)
					Control.Font = UIFont.SystemFontOfSize((System.nfloat)view.FontSize);
				else if (view.FontSize == Font.Default.FontSize)
					Control.Font = UIFont.SystemFontOfSize(17f);
			}

			void SetPlaceholderTextColor(LineEntry view)
			{
				if (string.IsNullOrEmpty(view.Placeholder) == false && view.PlaceholderColor != Color.Default)
				{
					var placeholderString = new NSAttributedString(view.Placeholder,
												new UIStringAttributes { ForegroundColor = view.PlaceholderColor.ToUIColor() });
					Control.AttributedPlaceholder = placeholderString;
				}
			}
		}
	}
	public class LineEntry : Entry
	{
		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create<LineEntry, Color>(p => p.BorderColor, Color.Black);

		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}

		public static readonly BindableProperty FontSizeProperty =
			BindableProperty.Create<LineEntry, double>(p => p.FontSize, Font.Default.FontSize);

		public double FontSize
		{
			get { return (double)GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value); }
		}

		public static readonly BindableProperty PlaceholderColorProperty =
			BindableProperty.Create<LineEntry, Color>(p => p.PlaceholderColor, Color.Default);

		public Color PlaceholderColor
		{
			get { return (Color)GetValue(PlaceholderColorProperty); }
			set { SetValue(PlaceholderColorProperty, value); }
		}
	}
}

