using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Anaconda.Domain.Infra
{
    public static class AppVersionInfo
    {
        public static string RuntimeFramework { get; }

        public static string SourceHash { get; }

        public static string SourceVersion { get; }

        public static string Version => $"{SourceVersion}+{SourceHash}";

        static AppVersionInfo()
        {
            RuntimeFramework = RuntimeInformation.FrameworkDescription;

            SourceVersion = GetSourceVersion();

            SourceHash = GetSourceHash();
        }

        /*
         * --configuration $(BuildConfiguration) --output "$(build.artifactstagingdirectory)" /property:Description=$(GITHUB_SHA) /p:SourceRevisionId=$(GITHUB_SHA)
         */

        private static string GetSourceVersion() 
            => GetAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "0.0.0";

        private static string GetSourceHash() 
            => GetAttribute<AssemblyDescriptionAttribute>()?.Description ?? "local";

        private static T GetAttribute<T>() where T : Attribute
        {
            var asm = typeof(AppVersionInfo).Assembly;
            return (T)asm.GetCustomAttributes(typeof(T)).FirstOrDefault();
        }
    }
}
