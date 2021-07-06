using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Modules.MessageCenter
{
    public interface IPushJob
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName { get; set; }
    }
}
