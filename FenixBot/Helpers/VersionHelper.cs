using System.Diagnostics;
using System.Reflection;

namespace FenixBot.Helpers
{
    public static class VersionHelper
    {
        public static string GetFullAssemblyVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            var assemblyVersion = fileVersionInfo.ProductVersion;

            return assemblyVersion;
        }
    }
}