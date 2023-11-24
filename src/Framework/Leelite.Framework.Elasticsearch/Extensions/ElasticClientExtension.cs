//using Elastic.Clients.Elasticsearch;
//using Elastic.Clients.Elasticsearch.IndexManagement;

//namespace Leelite.Framework.Elastic.Extensions
//{
//    /// <summary>
//    /// ElasticClient 扩展类
//    /// </summary>
//    public static class ElasticClientExtension
//    {
//        /// <summary>
//        /// 创建索引
//        /// </summary>
//        public static bool CreateIndex<T>(this ElasticsearchClient elasticClient, string indexName = "", int numberOfShards = 5, int numberOfReplicas = 1) where T : class
//        {
//            if (string.IsNullOrWhiteSpace(indexName))
//            {
//                indexName = typeof(T).Name;
//            }

//            if (elasticClient.Indices.Exists(indexName).Exists)
//            {
//                return false;
//            }
//            else
//            {
//                var settings = new IndexSettings()
//                {
//                    NumberOfReplicas = numberOfReplicas,
//                    NumberOfShards = numberOfShards,
//                };

//                var response = elasticClient.Indices.Create(indexName);
//                return response.Acknowledged;
//            }
//        }
//    }
//}
