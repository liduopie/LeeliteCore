using Leelite.MessageCenter.Models.PushRecordAgg;
using Leelite.MessageCenter.Weixin;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Senparc.CO2NET;
using Senparc.CO2NET.Cache;
using Senparc.CO2NET.Extensions;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin;
using Senparc.Weixin.Entities;
using Senparc.Weixin.Entities.TemplateMessage;
using Senparc.Weixin.WxOpen.AdvancedAPIs;

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Leelite.MessageCenter.Weixin
{
    public class WeixinWxOpenPushProvider : PushProviderBase
    {
        private readonly IUserOpenIDService _userOpenIDService;
        private WeixinWxOpenOptions _config = new WeixinWxOpenOptions();

        public WeixinWxOpenPushProvider(IUserOpenIDService userOpenIDService)
        {
            _userOpenIDService = userOpenIDService;

            ProviderName = "WeixinWxOpen";

            var dt1 = SystemTime.Now;

            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json", false, false);
            WriteLineString("完成 appsettings.json 添加");

            var config = configBuilder.Build();
            WriteLineString("完成 ServiceCollection 和 ConfigurationBuilder 初始化");

            //更多绑定操作参见：https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2
            var senparcSetting = new SenparcSetting();
            var senparcWeixinSetting = new SenparcWeixinSetting();

            config.GetSection("SenparcSetting").Bind(senparcSetting);
            config.GetSection("SenparcWeixinSetting").Bind(senparcWeixinSetting);

            var services = new ServiceCollection();
            services.AddMemoryCache(); // 使用本地缓存必须添加

            /*
            * CO2NET 是从 Senparc.Weixin 分离的底层公共基础模块，经过了长达 6 年的迭代优化，稳定可靠。
            * 关于 CO2NET 在所有项目中的通用设置可参考 CO2NET 的 Sample：
            * https://github.com/Senparc/Senparc.CO2NET/blob/master/Sample/Senparc.CO2NET.Sample.netcore/Startup.cs
            */

            services.AddSenparcGlobalServices(config);//Senparc.CO2NET 全局注册
            WriteLineString("完成 AddSenparcGlobalServices 注册");

            //输出 JSON 校验
            //var jsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore };
            //Console.WriteLine($"SenparcSetting:{senparcSetting.ToJson(true, jsonSerializerSettings)}");
            //Console.WriteLine($"SenparcWeixinSetting:{senparcWeixinSetting.ToJson(true,jsonSerializerSettings)}");

            // 启动 CO2NET 全局注册，必须！
            IRegisterService register = RegisterService.Start(senparcSetting)
                                                        //关于 UseSenparcGlobal() 的更多用法见 CO2NET Demo：https://github.com/Senparc/Senparc.CO2NET/blob/master/Sample/Senparc.CO2NET.Sample.netcore/Startup.cs
                                                        .UseSenparcGlobal();

            WriteLineString("完成 RegisterService.Start().UseSenparcGlobal()  启动设置");
            WriteLineString($"设定程序目录为：{Senparc.CO2NET.Config.RootDirectoryPath}");

            #region CO2NET 全局配置

            #region 全局缓存配置（按需）

            //当同一个分布式缓存同时服务于多个网站（应用程序池）时，可以使用命名空间将其隔离（非必须）
            register.ChangeDefaultCacheNamespace(Senparc.CO2NET.Config.DefaultCacheNamespace);
            WriteLineString($"默认缓存命名空间替换为：{Senparc.CO2NET.Config.DefaultCacheNamespace}");


            #region 配置和使用 Redis          -- DPBMARK Redis

            //配置全局使用Redis缓存（按需，独立）
            var redisConfigurationStr = senparcSetting.Cache_Redis_Configuration;
            var useRedis = !string.IsNullOrEmpty(redisConfigurationStr) && redisConfigurationStr != "#{Cache_Redis_Configuration}#"/*默认值，不启用*/;
            if (useRedis)//这里为了方便不同环境的开发者进行配置，做成了判断的方式，实际开发环境一般是确定的，这里的if条件可以忽略
            {
                /* 说明：
                 * 1、Redis 的连接字符串信息会从 Config.SenparcSetting.Cache_Redis_Configuration 自动获取并注册，如不需要修改，下方方法可以忽略
                /* 2、如需手动修改，可以通过下方 SetConfigurationOption 方法手动设置 Redis 链接信息（仅修改配置，不立即启用）
                 */
                Senparc.CO2NET.Cache.Redis.Register.SetConfigurationOption(redisConfigurationStr);
                WriteLineString("完成 Redis 设置");


                //以下会立即将全局缓存设置为 Redis
                Senparc.CO2NET.Cache.Redis.Register.UseKeyValueRedisNow();//键值对缓存策略（推荐）
                WriteLineString("启用 Redis UseKeyValue 策略");

                //Senparc.CO2NET.Cache.Redis.Register.UseHashRedisNow();//HashSet储存格式的缓存策略

                //也可以通过以下方式自定义当前需要启用的缓存策略
                //CacheStrategyFactory.RegisterObjectCacheStrategy(() => RedisObjectCacheStrategy.Instance);//键值对
                //CacheStrategyFactory.RegisterObjectCacheStrategy(() => RedisHashSetObjectCacheStrategy.Instance);//HashSet
            }
            // 如果这里不进行Redis缓存启用，则目前还是默认使用内存缓存 

            #endregion

            #endregion

            #endregion

            #region 微信相关配置


            /* 微信配置开始
             * 
             * 建议按照以下顺序进行注册，尤其须将缓存放在第一位！
             */

            //注册开始

            //开始注册微信信息，必须！
            register.UseSenparcWeixin(senparcWeixinSetting, senparcSetting);
            //注意：上一行没有 ; 下面可接着写 .RegisterXX()

            #region 注册公众号或小程序（按需）

            //注册公众号（可注册多个）                                                -- DPBMARK MP
            //.RegisterMpAccount(senparcWeixinSetting, "【盛派网络小助手】公众号")// DPBMARK_END


            //注册多个公众号或小程序（可注册多个）                                        -- DPBMARK MiniProgram
            //.RegisterWxOpenAccount(senparcWeixinSetting, "医统汇小程序");// DPBMARK_END

            //除此以外，仍然可以在程序任意地方注册公众号或小程序：
            //AccessTokenContainer.Register(appId, appSecret, name);//命名空间：Senparc.Weixin.MP.Containers
            #endregion

            /* 微信配置结束 */

            #endregion

            WriteLineString("Hello Senparc.Weixin!");
            WriteLineString($"Total initialization time: {(SystemTime.Now - dt1).TotalMilliseconds}ms");

            WriteLineString($"当前缓存策略: {CacheStrategyFactory.GetObjectCacheStrategyInstance()}");

            var jsonSetting = new Newtonsoft.Json.JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            WriteLineString($"SenparcWeixinSetting: {Senparc.Weixin.Config.SenparcWeixinSetting.ToJson(true, jsonSetting)}");
        }

        public override bool Push(PushRecord record)
        {
            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(record.Content);

            TemplateMessageData msgData = new TemplateMessageData();

            foreach (var item in data)
            {
                var value = item.Value;

                if (value.Length > 20)
                {
                    value = item.Value.Substring(0, 20);
                }
                msgData.Add(item.Key, new TemplateMessageDataValue(value));
            }

            string openId = _userOpenIDService.GetOpenID(_config.AppId, record.UserId);

            var result = MessageApi.SendSubscribe(_config.AppId, openId, record.TemplateCode, msgData, page: record.Url);

            if (result.errcode == 0)
            {
                return true;
            }
            else
            {
                WriteLineString($"WeixinWxOpen:{record.MessageId}:{result.errcode}");
                return false;
            }
        }

        public override void SetConfig(IDictionary<string, string> config)
        {
            var builder = new ConfigurationBuilder().AddInMemoryCollection(config);

            var configuration = builder.Build();

            configuration.Bind(_config);
        }
    }
}
