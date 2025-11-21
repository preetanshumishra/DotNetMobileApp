using MvvmCross.ViewModels;
using DotNetMobileApp.Core.ViewModels;
using DotNetMobileApp.Core.Services.Contracts;
using DotNetMobileApp.Core.Services.Implementations;
using MvvmCross.IoC;

namespace DotNetMobileApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            // Register platform-independent services
            RegisterCoreServices();
            
            // Auto-register services and repositories
            RegisterAutoServices();
            
            // Register all view models
            RegisterViewModels();
            
            // Set the app startup
            RegisterAppStart<MainViewModel>();
        }
        
        private void RegisterCoreServices()
        {
            // Register core services with explicit interface mapping for better control
            var iocProvider = MvxIoCProvider.Instance;
            
            // Logger service - register first as other services depend on it
            iocProvider?.RegisterSingleton<ILoggerService>(new LoggerService());
            
            // Analytics service
            var loggerService = iocProvider?.Resolve<ILoggerService>();
            if (loggerService != null)
            {
                iocProvider?.RegisterSingleton<IAnalyticsService>(
                    new AnalyticsService(loggerService));
            }
            
            // Log initialization
            loggerService?.LogInfo("Core services initialized successfully");
        }
        
        private void RegisterAutoServices()
        {
            // Auto-register remaining services ending with "Service" that weren't manually registered
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            // Auto-register repositories
            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();
        }
        
        private void RegisterViewModels()
        {
            // All ViewModels are automatically registered via MvvmCross
            // but you can add specific configurations here if needed
            var logger = MvxIoCProvider.Instance.Resolve<ILoggerService>();
            logger?.LogInfo("ViewModels registered");
        }
    }
}