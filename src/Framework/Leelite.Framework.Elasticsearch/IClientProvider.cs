using Nest;

namespace Leelite.Framework
{
    public interface IClientProvider
    {
        /// <summary>
        /// 获取ElasticClient
        /// </summary>
        ElasticClient GetClient();

        /// <summary>
        /// 指定index获取ElasticClient
        /// </summary>
        ElasticClient GetClient(string indexName);
    }
}
