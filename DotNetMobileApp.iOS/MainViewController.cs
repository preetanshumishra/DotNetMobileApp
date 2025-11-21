namespace DotNetMobileApp.iOS
{
    [Register(nameof(MainViewController))]
    public class MainViewController : UIViewController
    {
        private UILabel? _welcomeLabel;
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            View!.BackgroundColor = UIColor.White;
            
            _welcomeLabel = new UILabel
            {
                Frame = new CGRect(0, 0, 300, 100),
                Text = "Welcome to Native .NET iOS",
                TextAlignment = UITextAlignment.Center,
                Font = UIFont.SystemFontOfSize(18),
                TextColor = UIColor.Black
            };
            
            _welcomeLabel.Center = View.Center;
            View.AddSubview(_welcomeLabel);
        }
    }
}