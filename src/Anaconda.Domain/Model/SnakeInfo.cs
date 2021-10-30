using Anaconda.Domain.Infra;

namespace Anaconda.Domain.Model
{
    public class SnakeInfo
    {
        public string ApiVersion => "1";
        public string Author => "Anac#nda Azzzzure";
        public string Color => "336699";
        public string Head => "default";
        public string Tail => "default";
        public string Version => $"{AppVersionInfo.Version}";
    }
}
