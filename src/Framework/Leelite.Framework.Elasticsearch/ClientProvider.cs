using Elasticsearch.Net;

using Microsoft.Extensions.Options;

using Nest;

namespace Leelite.Framework
{
    public class ClientProvider : IClientProvider
    {
        private readonly Dictionary<string, ElasticClient> _keyValuePairs = new Dictionary<string, ElasticClient>();
        private readonly IOptions<ElasticsearchOptions> _options;
        private readonly object _sync = new object();

        public ClientProvider(IOptions<ElasticsearchOptions> options)
        {
            _options = options;
        }

        /// <summary>
        /// 获取elastic client  
        /// </summary>
        public ElasticClient GetClient()
        {
            if (_options == null || _options.Value == null || _options.Value.Urls == null || _options.Value.Urls.Count < 1)
            {
                throw new Exception("urls can not be null");
            }
            if (_options.Value.Urls.Count == 1)
            {
                return GetClient(_options.Value.Urls.First(), "");
            }
            else
            {
                return GetClient(_options.Value.Urls, "");
            }
        }

        /// <summary>
        /// 指定index获取ElasticClient
        /// </summary>
        public ElasticClient GetClient(string indexName)
        {
            if (_options == null || _options.Value == null || _options.Value.Urls == null || _options.Value.Urls.Count < 1)
            {
                throw new Exception("urls can not be null");
            }
            if (_options.Value.Urls.Count == 1)
            {
                return GetClient(_options.Value.Urls.First(), indexName);
            }
            else
            {
                return GetClient(_options.Value.Urls, indexName);
            }
        }

        /// <summary>
        /// 根据url获取ElasticClient
        /// </summary>
        private ElasticClient GetClient(string url, string defaultIndex = "")
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new Exception("es 地址不可为空");
            }
            var uri = new Uri(url);
            var connectionSetting = new ConnectionSettings(uri);
            if (!string.IsNullOrWhiteSpace(url))
            {
                connectionSetting.DefaultIndex(defaultIndex);
            }

            if (!string.IsNullOrEmpty(_options.Value.UserName) && !string.IsNullOrEmpty(_options.Value.Password))
            {
                connectionSetting.BasicAuthentication(_options.Value.UserName, _options.Value.Password);
            }

            return GetBaseClient(url + "_" + defaultIndex, connectionSetting);
        }

        /// <summary>
        /// 根据urls获取ElasticClient
        /// </summary>
        private ElasticClient GetClient(IList<string> urls, string defaultIndex = "")
        {
            if (urls == null || urls.Count < 1)
            {
                throw new Exception("urls can not be null");
            }
            var uris = urls.Select(p => new Uri(p)).ToArray();
            var connectionPool = new SniffingConnectionPool(uris);
            var connectionSetting = new ConnectionSettings(connectionPool);

            if (!string.IsNullOrWhiteSpace(defaultIndex))
            {
                connectionSetting.DefaultIndex(defaultIndex);
            }

            if (!string.IsNullOrEmpty(_options.Value.UserName) && !string.IsNullOrEmpty(_options.Value.Password))
            {
                connectionSetting.BasicAuthentication(_options.Value.UserName, _options.Value.Password);
            }

            return GetBaseClient(string.Join('_', urls) + defaultIndex, connectionSetting);
        }

        private ElasticClient GetBaseClient(string key, ConnectionSettings connectionSettings)
        {
            lock (_sync)
            {
                if (!_keyValuePairs.TryGetValue(key, out var elasticClient))
                {
                    elasticClient = new ElasticClient(connectionSettings);
                    _keyValuePairs[key] = elasticClient;
                }

                return elasticClient;
            }
        }
    }
}
