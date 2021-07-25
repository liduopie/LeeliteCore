using Hangfire.Console;
using Hangfire.Server;

using Leelite.Modules.MessageCenter.Models.PushRecordAgg;

using System;
using System.Collections.Generic;

namespace Leelite.Modules.MessageCenter
{
    public abstract class PushProviderBase : IPushProvider
    {
        private PerformContext _context = default!;
        protected Action<string> WriteLineString;
        protected Action<object> WriteLineObject;

        public PushProviderBase()
        {
            WriteLineString = Console.WriteLine;
            WriteLineObject = Console.WriteLine;
        }

        public string ProviderName { get; set; }
        public string ConfigSchema { get; set; }

        public abstract bool Push(PushRecord record);

        public abstract void SetConfig(IDictionary<string, string> config);

        public void SetPerformContext(PerformContext context)
        {
            WriteLineString = context.WriteLine;
            WriteLineObject = context.WriteLine;
        }
    }
}
