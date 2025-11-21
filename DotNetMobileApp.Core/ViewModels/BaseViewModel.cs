using MvvmCross.ViewModels;

namespace DotNetMobileApp.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }
        
        protected virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}