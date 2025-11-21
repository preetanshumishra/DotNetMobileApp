using DotNetMobileApp.Core.Services.Contracts;

namespace DotNetMobileApp.Core.Services.Implementations
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly ILoggerService _loggerService;
        private string? _userId;
        
        public AnalyticsService(ILoggerService loggerService)
        {
            _loggerService = loggerService ?? throw new ArgumentNullException(nameof(loggerService));
        }
        
        public void TrackEvent(string eventName, Dictionary<string, object>? properties = null)
        {
            var message = $"Event tracked: {eventName}";
            if (properties != null && properties.Count > 0)
            {
                var props = string.Join(", ", properties.Select(p => $"{p.Key}={p.Value}"));
                message += $" | Properties: {props}";
            }
            _loggerService.LogInfo(message);
        }
        
        public void TrackException(Exception exception)
        {
            _loggerService.LogError($"Exception tracked: {exception.GetType().Name}", exception);
        }
        
        public void SetUserId(string userId)
        {
            _userId = userId;
            _loggerService.LogInfo($"User ID set: {userId}");
        }
    }
}