namespace DotNetMobileApp.Core.Services.Contracts
{
    public interface IAppNavigationService
    {
        Task NavigateAsync<TViewModel>() where TViewModel : class;
        Task NavigateAsync<TViewModel>(object parameter) where TViewModel : class;
        Task CloseAsync();
    }
}