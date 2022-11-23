using com.gexin.rp.sdk.dto;
using com.igetui.api.openservice;
using com.igetui.api.openservice.igetui;
using com.igetui.api.openservice.igetui.template;
using com.igetui.api.openservice.igetui.template.notify;
using com.igetui.api.openservice.payload;

using Leelite.Modules.MessageCenter.Models.PushRecordAgg;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Leelite.Modules.MessageCenter.UniPush
{
    public class UniPushProvider : PushProviderBase
    {
        private readonly IUserClientIdService _userClientIdService;
        private UniPushOptions _config = new UniPushOptions();

        public const string HOST = "http://sdk.open.api.igexin.com/apiex.htm";

        public UniPushProvider(IUserClientIdService userClientIdService)
        {
            _userClientIdService = userClientIdService;
            ProviderName = "UniPush";
        }

        public override bool Push(PushRecord record)
        {
            IGtPush push = new IGtPush(HOST, _config.AppKey, _config.MasterSecret);
            TransmissionTemplate template = TransmissionTemplateAndroidiOS(record.Content, record.Content, record.Url);
            //单推消息模型
            SingleMessage message = new SingleMessage();
            //当用户不在线 是否离线存储
            message.IsOffline = true;
            //离线有效时间
            message.OfflineExpireTime = 1000 * 3600 * 12;
            message.Data = template;
            //当前网络 1wifi 2-234G 0不限制
            message.PushNetWorkType = 0;
            var target = new com.igetui.api.openservice.igetui.Target();
            target.appId = _config.AppId;
            target.clientId = _userClientIdService.GetClientID(record.UserId);

            var resultString = push.pushMessageToSingle(message, target);

            var result = JsonSerializer.Deserialize<UniPushResultModel>(resultString);

            if (result.result == "ok")
            {
                WriteLineString(result.status);
                return true;
            }
            else
            {

                WriteLineString(result.status);
                return false;
            }
        }

        public override void SetConfig(IDictionary<string, string> config)
        {
            var builder = new ConfigurationBuilder().AddInMemoryCollection(config);

            var configuration = builder.Build();

            configuration.Bind(_config);
        }

        /// <summary>
        /// 模版二
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="url">链接</param>
        /// <returns></returns>
        public TransmissionTemplate TransmissionTemplateAndroidiOS(string title, string content, string url)
        {
            TransmissionTemplate template = new TransmissionTemplate();
            template.AppId = _config.AppId;
            template.AppKey = _config.AppKey;
            //应用启动类型，1：强制应用启动 2：等待应用启动
            template.TransmissionType = 1;
            //透传内容  
            template.TransmissionContent = "{\"url\":\"" + url + "\"}";

            //安卓透传厂商通道
            Notify notify = new Notify();
            notify.Content = title;
            notify.Title = content;
            string newUrl = "{\"url\":\"" + url + "\"}";
            notify.Intent = $"intent:#Intent;action=android.intent.action.oppopush;launchFlags=0x14000000;component=您的安卓包名/io.dcloud.PandoraEntry;S.UP-OL-SU=true;S.title={title};S.content={content};S.payload={newUrl};end";
            notify.Type = NotifyInfo.Types.Type._intent;
            template.set3rdNotifyInfo(notify);

            //苹果透传配置
            APNPayload apnpayload = new APNPayload();
            DictionaryAlertMsg alertMsg = new DictionaryAlertMsg();
            // IOS 的body用这个
            alertMsg.Body = content;
            alertMsg.ActionLocKey = "ActionLocKey";
            alertMsg.LocKey = "LocKey";
            alertMsg.addLocArg("LocArg");
            alertMsg.LaunchImage = "LaunchImage";
            //iOS8.2支持字段
            alertMsg.Title = title;
            alertMsg.TitleLocKey = "TitleLocKey";
            alertMsg.addTitleLocArg("TitleLocArg");

            apnpayload.AlertMsg = alertMsg;
            //apnpayload.Badge = 0  +1;
            apnpayload.ContentAvailable = 0;
            apnpayload.Sound = "default";
            apnpayload.addCustomMsg("payload", "{\"url\":\"" + url + "\"}");

            template.setAPNInfo(apnpayload);

            string begin = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
            template.setDuration(begin, end);

            return template;
        }
    }
}
