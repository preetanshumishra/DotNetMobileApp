using MvvmCross.Platforms.Android.Core;
using DotNetMobileApp.Core;
using Microsoft.Extensions.Logging;

namespace DotNetMobileApp.Android
{
    public class Setup : MvxAndroidSetup<App>
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