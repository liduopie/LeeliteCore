using System.Collections.Generic;

using Hangfire.Server;

using Leelite.Commons.Lifetime;

namespace Leelite.MessageCenter.Jobs
{
    public interface IPushJob : ITransient
    {
        void SetTopics(IList<string> topics);
        void SetSleepInterval(int interval);
        void Execute(PerformContext context);
    }
}
