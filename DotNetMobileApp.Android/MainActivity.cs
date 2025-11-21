using _Microsoft.Android.Resource.Designer;
using Android.Content.PM;

namespace DotNetMobileApp.Android
{
    [Activity(Label = "@string/app_name", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(ResourceConstant.Layout.activity_main);
            
            var welcomeTextView = FindViewById<TextView>(ResourceConstant.Id.welcome_text);
            if (welcomeTextView != null)
            {
                welcomeTextView.Text = "Welcome to Native .NET Android";
            }
        }
    }
}