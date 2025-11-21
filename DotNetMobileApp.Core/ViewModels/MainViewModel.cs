using MvvmCross.Commands;

namespace DotNetMobileApp.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _welcomeMessage = "Welcome to DotNetMobileApp";
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set => SetProperty(ref _welcomeMessage, value);
        }
        
        public IMvxCommand UpdateMessageCommand { get; }
        
        public MainViewModel()
        {
            Title = "Main View";
            UpdateMessageCommand = new MvxCommand(UpdateMessage);
        }
        
        private void UpdateMessage()
        {
            WelcomeMessage = "Hello from MvvmCross!";
        }
    }
}