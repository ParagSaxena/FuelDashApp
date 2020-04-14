﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FuelDashApp.Droid.CustomRenderers;
using Xamarin.Forms;

namespace FuelDashApp.Droid
{
    [Activity(Label = "FuelDash", Icon = "@drawable/ic_launcher", Theme = "@style/Theme.Splash", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            App.ScreenWidth = (double)Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density;
            App.ScreenHeight = (double)Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density;

            DependencyService.Register<MessageAndroid>();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}