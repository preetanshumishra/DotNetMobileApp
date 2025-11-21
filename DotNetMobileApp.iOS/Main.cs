namespace DotNetMobileApp.iOS
{
    public static class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                UIApplication.Main(args, null, typeof(AppDelegate));
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception: {ex.Message}");
                return 1;
            }
        }
    }
}