using Hangfire.Console;
using Hangfire.Server;

using Leelite.Core.BackgroundJob;
using Leelite.Framework.Data.Query;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Modules.MessageCenter.Dtos.SessionDtos;
using Leelite.Modules.MessageCenter.Models.SessionAgg;
using Leelite.Modules.MessageCenter.Repositories;

namespace Leelite.Modules.MessageCenter.Jobs
{
    [RecurringJob("*/1 * * * *", RecurringJobId = "删除过期会话")]
    public class DeleteExpiredSessionJob : IRecurringJob
    {
        private readonly ISessionRepository _sessionRepository;

        public DeleteExpiredSessionJob(
            ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public void Execute(PerformContext context)
        {
            // 获取过期的Session
            var parameter = new SessionQueryParameter()
            {
                Pager = new PageParam()
                {
                    PageSize = 100
                },
                Expired = true,
            };

            var query = new PagingQuery<Session, SessionQueryParameter>(parameter);

            // create progress bar
            var progress = context.WriteProgressBar();

            var total = _sessionRepository.Count(parameter.SatisfiedBy());

            context.WriteLine($"过期状态会话共{total}个。");

            if (total == 0) return;

            do
            {
                var sessions = _sessionRepository.FindPage(query);

                _sessionRepository.RemoveRange(sessions);

                context.WriteLine($"本次处理{sessions.Count}会话。");

                parameter.Pager.Page++;

                // update value for previously created progress bar
                if (parameter.Pager.GetSkipCount() >= total)
                {
                    progress.SetValue(100);
                }
                else
                {
                    progress.SetValue(parameter.Pager.GetSkipCount() * 100 / total);
                }
            } while (parameter.Pager.GetSkipCount() < total);
        }
    }
}
