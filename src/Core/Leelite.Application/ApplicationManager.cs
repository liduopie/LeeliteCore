﻿using Leelite.Application.Clients;
using Leelite.Core.Modular;
using Leelite.Core.Module.Store;

namespace Leelite.Application
{
    public static class ApplicationManager
    {
        /// <summary>
        /// 应用入口
        /// </summary>
        public static List<Client> Clients { get; set; } = [];

        /// <summary>
        /// 应用包含的模块
        /// </summary>
        public static List<ModuleInfo> Modules => ModularManager.Current.ModuleInfos.ToList();

        /// <summary>
        /// 应用功能
        /// </summary>
        public static List<FeatureItem> Features { get; set; } = [];
    }
}
