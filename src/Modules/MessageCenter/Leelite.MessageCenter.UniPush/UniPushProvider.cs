using com.gexin.rp.sdk.dto;
using com.igetui.api.openservice;
using com.igetui.api.openservice.igetui;
using com.igetui.api.openservice.igetui.template;
using com.igetui.api.openservice.igetui.template.notify;
using com.igetui.api.openservice.payload;

using Leelite.MessageCenter.Models.PushRecordAgg;

using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Leelite.MessageCenter.UniPush
{
    public class UniPushProvider : PushProviderBase
    {
        private readonly IUserClientIdService _userClientIdService;
        private UniPushOptions _config = new UniPushOptions();
        private IGtPush _push = null;

        public const string HOST = "http://sdk.open.api.igexin.com/apiex.htm";

        public UniPushProvider(IUserClientIdService userClientIdService)
        {
            _userClientIdService = userClientIdService;
            ProviderName = "UniPush";
        }

        public override bool Push(PushRecord record)
        {
            TransmissionTemplate template = TransmissionTemplateAndroidiOS(record);

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

            if (target.clientId == null)
            {
                return true;
            }

            var resultString = _push.pushMessageToSingle(message, target);

            var result = JsonSerializer.Deserialize<UniPushResultModel>(resultString);

            if (result.result == "ok" || result.result == "AppidError")
            {
                return true;
            }
            else
            {
                WriteLineString($"UniPush:{record.MessageId}:{result.status}:{result.result}");
                return false;
            }
        }

        public override void SetConfig(IDictionary<string, string> config)
        {
            var builder = new ConfigurationBuilder().AddInMemoryCollection(config);

            var configuration = builder.Build();

            configuration.Bind(_config);

            _push = new IGtPush(HOST, _config.AppKey, _config.MasterSecret);
        }

        /// <summary>
        /// 模版二
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="url">链接</param>
        /// <returns></returns>
        public TransmissionTemplate TransmissionTemplateAndroidiOS(PushRecord record)
        {
            var data = JsonSerializer.Deserialize<Dictionary<string, string>>(record.Content);

            var title = "";
            var content = "";
            var payload = record.Content;
            if (data.ContainsKey("title"))
            {
                title = data["title"];
            }
            if (data.ContainsKey("content"))
            {
                content = data["content"];
            }

            TransmissionTemplate template = new TransmissionTemplate();
            template.AppId = _config.AppId;
            template.AppKey = _config.AppKey;
            //应用启动类型，1：强制应用启动 2：等待应用启动
            template.TransmissionType = 1;
            //透传内容  
            template.TransmissionContent = record.Content;

            //安卓透传厂商通道
            Notify notify = new Notify();
            notify.Content = content;
            notify.Title = title;
            notify.Intent = $"intent:#Intent;launchFlags=0x04000000;package=io.dcloud.H55C3CFB0;component=io.dcloud.H55C3CFB0/io.dcloud.PandoraEntry;S.UP-OL-SU=true;S.title={title};S.content={content};S.payload={payload};end";

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
            apnpayload.addCustomMsg("payload", payload);

            template.setAPNInfo(apnpayload);

            //string begin = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //string end = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
            //template.setDuration(begin, end);

            return template;
        }
    }
}
