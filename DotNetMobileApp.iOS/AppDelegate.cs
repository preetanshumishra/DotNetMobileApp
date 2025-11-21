namespace DotNetMobileApp.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow? Window { get; set; }
        
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = new ViewController();
            Window.MakeKeyAndVisible();
            return true;
        }
    }
}