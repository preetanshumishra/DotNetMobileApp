using MvvmCross.ViewModels;
using DotNetMobileApp.Core.ViewModels;
using MvvmCross.IoC;

namespace DotNetMobileApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            RegisterAppStart<MainViewModel>();
        }
    }
}