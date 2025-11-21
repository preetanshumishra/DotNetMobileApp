using MvvmCross.Platforms.Ios.Core;
using DotNetMobileApp.Core;
using Microsoft.Extensions.Logging;

namespace DotNetMobileApp.iOS
{
    public class Setup : MvxIosSetup<App>
    {
        protected override ILoggerProvider? CreateLogProvider()
        {
            throw new NotImplementedException();
        }
        
        protected override ILoggerFactory? CreateLogFactory()
        {
            throw new NotImplementedException();
        }
    }
}