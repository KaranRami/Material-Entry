using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Material_Entry.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Material.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer), new[] { typeof(VisualMarker.MaterialVisual) })]
namespace Material_Entry.Droid.Renderer
{
    public class CustomEntryRenderer : MaterialEntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control.EditText.LayoutChange += EditText_LayoutChange;
        }

        private void EditText_LayoutChange(object sender, LayoutChangeEventArgs e)
        {
            if (Control != null)
            {
                Control.EditText.SetPadding(0, Control.EditText.PaddingTop, Control.EditText.PaddingRight, Control.EditText.PaddingBottom);
                if (Control.EditText.IsFocused)
                    Control.EditText.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Blue);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                Control.EditText.SetPadding(0, Control.EditText.PaddingTop, Control.EditText.PaddingRight, Control.EditText.PaddingBottom);
                if (e.PropertyName.ToUpper() == "ISFOCUSED" && !Control.EditText.IsFocused)
                    Control.EditText.BackgroundTintList = ColorStateList.ValueOf(Element.TextColor.ToAndroid());
            }
        }

        protected override void Dispose(bool disposing)
        {
            Control.EditText.LayoutChange -= EditText_LayoutChange;
            base.Dispose(disposing);
        }
    }
}