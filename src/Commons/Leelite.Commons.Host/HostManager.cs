using Microsoft.Extensions.Hosting;

namespace Leelite.Commons.Host
{

    public static class HostManager
    {
        private static IHost? _defaultHost;
        private static IHost? _webApplication;

        public static IHost DefaultHost
        {
            get
            {
                if (_defaultHost == null)
                {
                    throw new Exception("WebApplication is null.");
                }

                return _defaultHost;
            }
            set
            {
                _defaultHost = value;
            }
        }

        public static IHost WebApplication
        {
            get
            {
                if (_webApplication == null)
                {
                    throw new Exception("WebApplication is null.");
                }

                return _webApplication;
            }
            set
            {
                _webApplication = value;
            }
        }
    }
}
