using AutoMapper;
using Leelite.Commons.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Leelite.Framework.Service
{
    public abstract class AbstractService
    {
        private readonly IMapper _mapper;

        protected AbstractService(ILogger logger)
        {
            _mapper = HostManager.Context.HostServices.GetService<IMapper>();
            Logger = logger;
        }

        /// <summary>
        /// 日志
        /// </summary>
        protected ILogger Logger { get; set; }

        /// <summary>
        /// 用户会话
        /// </summary>
        // public ISession Session { get; set; }

        protected T MapTo<T>(object source)
        {
            return _mapper.Map<T>(source);
        }
    }
}
