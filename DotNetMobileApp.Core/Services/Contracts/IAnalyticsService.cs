namespace DotNetMobileApp.Core.Services.Contracts
{
    public interface IAnalyticsService
    {
        void TrackEvent(string eventName, Dictionary<string, object>? properties = null);
        void TrackException(Exception exception);
        void SetUserId(string userId);
    }
}