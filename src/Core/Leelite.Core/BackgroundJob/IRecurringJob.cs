using Hangfire;
using Hangfire.Server;

namespace Leelite.Core.BackgroundJob
{
    /// <summary>
    /// Provides a unified interface to build hangfire <see cref="RecurringJob"/>, similar to quartz.net.
    /// </summary>
    public interface IRecurringJob
    {
        /// <summary>
        /// Execute the <see cref="RecurringJob"/>.
        /// </summary>
        /// <param name="context">The context to <see cref="PerformContext"/>.</param>
        [AutomaticRetry(Attempts = 0)]
        void Execute(PerformContext context);
    }
}
