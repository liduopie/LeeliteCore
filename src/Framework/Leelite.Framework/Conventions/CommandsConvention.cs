using Leelite.Commons.Convention;
using Leelite.Framework.Service;
using Leelite.Framework.Service.Commands;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Leelite.Framework.Conventions
{
    public class CommandsConvention : IConventionRegistrar
    {
        public void RegisterAssembly(Assembly assembly, IServiceCollection services)
        {
            var serviceTypes = assembly.GetTypes().Where(c => c.IsClass && !c.IsAbstract && !c.IsGenericType && c.HasImplementedRawGeneric(typeof(ICrudService<,,,,,>)));


            if (serviceTypes.Count() == 0) return;

            foreach (var service in serviceTypes)
            {
                var baseType = service.BaseType;

                var genericTypes = baseType.GenericTypeArguments;

                var args = service.GetInterface(typeof(ICrudService<,,,,,>).Name).GetGenericArguments();

                // CreateCommand
                var createCommandType = typeof(CreateCommand<,,,>)
                    .MakeGenericType(args[3], args[2], args[0], args[1]);

                var createRequestHandlerType = typeof(IRequestHandler<,>)
                    .MakeGenericType(createCommandType, args[2]);

                var createCommandHandlerType = typeof(CreateCommandHandler<,,,>)
                    .MakeGenericType(args[3], args[2], args[0], args[1]);

                services.AddTransient(createRequestHandlerType, createCommandHandlerType);

                // DeleteCommand
                var deleteCommandType = typeof(DeleteCommand<,>)
                    .MakeGenericType(args[0], args[1]);

                var deleteRequestHandlerType = typeof(IRequestHandler<,>)
                    .MakeGenericType(deleteCommandType, typeof(bool));

                var deleteCommandHandlerType = typeof(DeleteCommandHandler<,>)
                    .MakeGenericType(args[0], args[1]);

                services.AddTransient(deleteRequestHandlerType, deleteCommandHandlerType);

                // BatchDeleteCommand
                var batchDeleteCommandType = typeof(BatchDeleteCommand<,>)
                    .MakeGenericType(args[0], args[1]);

                var batchDeleteRequestHandlerType = typeof(IRequestHandler<,>)
                    .MakeGenericType(batchDeleteCommandType, typeof(bool));

                var batchDeleteCommandHandlerType = typeof(BatchDeleteCommandHandler<,>)
                    .MakeGenericType(args[0], args[1]);

                services.AddTransient(batchDeleteRequestHandlerType, batchDeleteCommandHandlerType);

                // UpdateCommand
                var updateCommandType = typeof(UpdateCommand<,,,>)
                    .MakeGenericType(args[3], args[2], args[0], args[1]);

                var updateRequestHandlerType = typeof(IRequestHandler<,>)
                    .MakeGenericType(updateCommandType, args[2]);

                var updateCommandHandlerType = typeof(UpdateCommandHandler<,,,>)
                    .MakeGenericType(args[3], args[2], args[0], args[1]);

                services.AddTransient(updateRequestHandlerType, updateCommandHandlerType);

                // BatchSaveCommand
                var batchSaveCommandType = typeof(BatchSaveCommand<,,>)
                    .MakeGenericType(args[2], args[0], args[1]);

                var listType = typeof(IList<>).MakeGenericType(args[2]);

                var batchSaveRequestHandlerType = typeof(IRequestHandler<,>)
                    .MakeGenericType(batchSaveCommandType, listType);

                var batchSaveCommandHandlerType = typeof(BatchSaveCommandHandler<,,>)
                    .MakeGenericType(args[2], args[0], args[1]);

                services.AddTransient(batchSaveRequestHandlerType, batchSaveCommandHandlerType);
            }
        }
    }
}
