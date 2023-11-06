using System;
using System.Text.Json;
using Leelite.Framework.Domain.Aggregate;

namespace Leelite.AuditTrail.Models.AuditLogAgg
{
    public class AuditLog : AggregateRoot<long>
    {
        public string ModuleCode { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public string Level { get; set; }
        public JsonDocument CustomData { get; set; }
        public long OrganizationId { get; set; }
        public long UserId { get; set; }
        public DateTime OperationTime { get; set; }
        public string Signature { get; set; }
        public string Host { get; set; }
        public string Url { get; set; }
        public string AppId { get; set; }
        public string ClientName { get; set; }
        public string ClientIp { get; set; }
        public string BrowserInfo { get; set; }
    }
}
