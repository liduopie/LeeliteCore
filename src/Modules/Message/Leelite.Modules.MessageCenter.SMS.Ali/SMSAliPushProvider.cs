using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;

using Leelite.Modules.MessageCenter.Models.PushRecordAgg;

using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Text;

namespace Leelite.Modules.MessageCenter.SMS.Ali
{
    public class SMSAliPushProvider : PushProviderBase
    {
        private readonly IUserPhoneService _userPhoneService;
        private SMSAliOptions _config = new SMSAliOptions();

        public SMSAliPushProvider(IUserPhoneService userPhoneService)
        {
            _userPhoneService = userPhoneService;
            ProviderName = "AliSMS";
            ConfigSchema = "RegionId、AccessKeyId、Secret、SignName";
        }

        public override bool Push(PushRecord record)
        {
            IClientProfile profile = DefaultProfile.GetProfile(_config.RegionId, _config.AccessKeyId, _config.Secret);
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            // request.Protocol = ProtocolType.HTTP;

            request.AddQueryParameters("PhoneNumbers", _userPhoneService.GetPhone(record.UserId));
            request.AddQueryParameters("SignName", _config.SignName);
            request.AddQueryParameters("TemplateCode", record.TemplateCode);
            request.AddQueryParameters("TemplateParam", record.Content);

            try
            {
                CommonResponse response = client.GetCommonResponse(request);

                WriteLineString(Encoding.Default.GetString(response.HttpResponse.Content));
            }
            catch (ServerException e)
            {
                WriteLineObject(e);
            }
            catch (ClientException e)
            {
                WriteLineObject(e);
            }

            return true;
        }

        public override void SetConfig(IDictionary<string, string> config)
        {
            var builder = new ConfigurationBuilder().AddInMemoryCollection(config);

            var configuration = builder.Build();

            configuration.Bind(_config);
        }
    }
}
