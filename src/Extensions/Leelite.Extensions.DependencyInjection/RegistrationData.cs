﻿using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Extensions.DependencyInjection
{
    /// <summary>
    /// RegisterAssemblyTypes uses this to create the initial data
    /// </summary>
    /// <param name="types"></param>
    public class RegistrationData(IServiceCollection services, IEnumerable<Type> types)
    {
        private readonly IServiceCollection _services = services ?? throw new ArgumentNullException(nameof(services));
        private readonly List<Func<Type, IEnumerable<Type>>> _serviceMappings = [];
        private IEnumerable<Type> _types = types ?? throw new ArgumentNullException(nameof(types));

        /// <summary>
        /// 构建完成的 Descriptor
        /// </summary>
        public IList<ServiceDescriptor> Services { get; set; } = new List<ServiceDescriptor>();

        /// <summary>
        /// 源类型条件
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public RegistrationData Where(Func<Type, bool> predicate)
        {
            _types = _types.Where(predicate);

            return this;
        }

        /// <summary>
        /// 目标映射函数
        /// </summary>
        /// <param name="serviceMapping"></param>
        /// <returns></returns>
        public RegistrationData As(Func<Type, IEnumerable<Type>> serviceMapping)
        {
            _serviceMappings.Add(serviceMapping);

            return this;
        }

        /// <summary>
        /// 约定生命周期
        /// </summary>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        public RegistrationData With(ServiceLifetime lifetime)
        {
            Services = Build(_types, _serviceMappings, lifetime);

            foreach (var item in Services)
            {
                _services.Add(item);
            }

            return this;
        }

        private static List<ServiceDescriptor> Build(IEnumerable<Type> types, IList<Func<Type, IEnumerable<Type>>> serviceMappings, ServiceLifetime lifetime)
        {
            ArgumentNullException.ThrowIfNull(types);
            ArgumentNullException.ThrowIfNull(serviceMappings);

            var descriptors = new List<ServiceDescriptor>();

            foreach (var type in types)
            {
                foreach (var mapping in serviceMappings)
                {
                    var mappeds = mapping(type);
                    foreach (var mapped in mappeds)
                    {
                        var descriptor = new ServiceDescriptor(mapped, type, lifetime);

                        descriptors.Add(descriptor);
                    }
                }
            }

            return descriptors;
        }
    }
}
