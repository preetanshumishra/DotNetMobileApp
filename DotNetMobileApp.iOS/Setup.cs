using MvvmCross.Platforms.Ios.Core;
using DotNetMobileApp.Core;
using Microsoft.Extensions.Logging;

namespace DotNetMobileApp.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override ILoggerProvider? CreateLogProvider()
        {
            return null;
        }
        
        protected override ILoggerFactory? CreateLogFactory()
        {
            return null;
        }
    }
}