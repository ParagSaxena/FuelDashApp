using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FuelDashApp.Droid.CustomRenderers;
using FuelDashApp.Views.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace FuelDashApp.Droid.CustomRenderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        CustomPicker picker = null;
        public CustomPickerRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                picker = Element as CustomPicker;
                UpdatePickerPlaceholder();
                if (picker.SelectedIndex <= -1)
                {
                    UpdatePickerPlaceholder();
                }
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (picker != null)
            {
                if (e.PropertyName.Equals(CustomPicker.PlaceholderProperty.PropertyName))
                {
                    UpdatePickerPlaceholder();
                }
            }
        }

        protected override void UpdatePlaceHolderText()
        {
            UpdatePickerPlaceholder();
        }

        void UpdatePickerPlaceholder()
        {
            if (picker == null)
                picker = Element as CustomPicker;
            if (picker.Placeholder != null)
                Control.Hint = picker.Placeholder;
        }
    }
}