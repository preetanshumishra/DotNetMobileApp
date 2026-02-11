namespace DotNetMobileApp.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow? Window { get; set; }
        
        public override bool FinishedLaunching(UIApplication application, NSDictionary? launchOptions)
        {
            if (OperatingSystem.IsIOSVersionAtLeast(26))
            {
                var windowScene = application.ConnectedScenes
                    .OfType<UIWindowScene>()
                    .FirstOrDefault();
                if (windowScene == null)
                {
                    return false;
                }

                Window = new UIWindow(windowScene);
            }
            else
            {
#pragma warning disable CA1422
                Window = new UIWindow(UIScreen.MainScreen.Bounds);
#pragma warning restore CA1422
            }

            Window.RootViewController = new MainViewController();
            Window.MakeKeyAndVisible();
            return true;
        }
    }
}
