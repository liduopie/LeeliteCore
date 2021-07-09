﻿using System;
namespace Leelite.Modules.MessageCenter
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
    }
}