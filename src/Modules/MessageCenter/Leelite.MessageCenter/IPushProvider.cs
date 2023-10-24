using Hangfire.Server;

using Leelite.MessageCenter.Models.PushRecordAgg;

using System.Collections.Generic;

namespace Leelite.MessageCenter
{
    public interface IPushProvider
    {
        /// <summary>
        /// 提供程序名称
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 配置结构描述
        /// </summary>
        public string ConfigSchema { get; set; }

        public bool Push(PushRecord record);

        public void SetConfig(IDictionary<string, string> config);

        public void SetPerformContext(PerformContext context);
    }
}
