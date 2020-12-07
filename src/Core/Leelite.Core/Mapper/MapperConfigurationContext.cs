using System;
using System.Collections.Generic;

using AutoMapper;

namespace Leelite.Core.Mapper
{
    public class MapperConfigurationContext
    {
        private IList<Action<IMapperConfigurationExpression>> _configures = new List<Action<IMapperConfigurationExpression>>();

        public void AddConfigure(Action<IMapperConfigurationExpression> configure)
        {
            _configures.Add(configure);
        }

        public IMapper CreateMapper()
        {
            Action<IMapperConfigurationExpression> action = (c) =>
            {
                foreach (var configure in _configures)
                {
                    configure.Invoke(c);
                }

            };
            return new MapperConfiguration(action).CreateMapper();
        }
    }
}
