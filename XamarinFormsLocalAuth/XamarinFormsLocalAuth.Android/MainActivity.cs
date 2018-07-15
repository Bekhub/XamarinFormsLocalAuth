using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RealSimpleCircle.Android;
using Plugin.CurrentActivity;
using Plugin.Fingerprint;

namespace XamarinFormsLocalAuth.Droid
{
    [Activity(Label = "XamarinFormsLocalAuth", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(bundle);
    
            global::Xamarin.Forms.Forms.Init(this, bundle);
            CrossCurrentActivity.Current.Init(this, bundle);
            CrossFingerprint.SetCurrentActivityResolver(() => CrossCurrentActivity.Current.Activity);
            CircleRenderer.Init();
            LoadApplication(new App());
        }
    }
}

