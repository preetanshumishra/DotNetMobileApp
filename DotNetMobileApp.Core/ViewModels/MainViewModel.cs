using MvvmCross.Commands;
using DotNetMobileApp.Core.Services.Contracts;

namespace DotNetMobileApp.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ILoggerService _loggerService;
        private readonly IAnalyticsService _analyticsService;
        
        private string _welcomeMessage = "Welcome to DotNetMobileApp";
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set => SetProperty(ref _welcomeMessage, value);
        }
        
        public IMvxCommand UpdateMessageCommand { get; }
        public IMvxCommand TrackAnalyticsCommand { get; }
        
        public MainViewModel(ILoggerService loggerService, IAnalyticsService analyticsService)
        {
            _loggerService = loggerService;
            _analyticsService = analyticsService;
            
            Title = "Main View";
            
            UpdateMessageCommand = new MvxCommand(UpdateMessage);
            TrackAnalyticsCommand = new MvxCommand(TrackAnalytics);
            
            _loggerService.LogInfo("MainViewModel initialized");
        }
        
        protected override Task InitializeAsync()
        {
            _loggerService.LogInfo("MainViewModel initialization started");
            _analyticsService.TrackEvent("MainViewLoaded");
            return base.InitializeAsync();
        }
        
        private void UpdateMessage()
        {
            WelcomeMessage = "Hello from MvvmCross!";
            _loggerService.LogInfo("Message updated");
        }
        
        private void TrackAnalytics()
        {
            _analyticsService.TrackEvent("UpdateMessageClicked", new Dictionary<string, object>
            {
                { "timestamp", DateTime.UtcNow },
                { "message", WelcomeMessage }
            });
            _loggerService.LogInfo("Analytics event tracked");
        }
    }
}