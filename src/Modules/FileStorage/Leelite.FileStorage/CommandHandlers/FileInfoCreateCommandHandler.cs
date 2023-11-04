using System;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using HybridFS.FileSystem;
using HybridFS.FileSystem.Exceptions;
using HybridFS.FileSystem.Models;
using HybridFS.Utility;

using Leelite.Application.Settings;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service.Commands;
using Leelite.Framework.Service.Events;
using Leelite.FileStorage.Dtos.FileItemDtos;
using Leelite.FileStorage.Models.FileItemAgg;
using Leelite.FileStorage.Options;
using Leelite.FileStorage.Utility;

namespace Leelite.FileStorage.CommandHandlers
{
    public class FileInfoCreateCommandHandler : ICommandHandler<CreateCommand<FileItemCreateRequest, FileItemDto, FileItem, Guid>, FileItemDto>
    {
        private readonly IRepository<FileItem, Guid> _repository;
        private readonly IDomainEventBus _domainEventBus;
        private readonly IMapper _mapper;

        private readonly FileStorageOptions _options;

        private readonly IFileManager _fileManager;

        public FileInfoCreateCommandHandler(
            IRepository<FileItem, Guid> repository,
            IDomainEventBus domainEventBus,
            IMapper mapper,
            ISettingManager settingManage,
            IFileManager fileManager)
        {
            _repository = repository;
            _domainEventBus = domainEventBus;
            _mapper = mapper;

            _options = settingManage.GetApplicationOptions<FileStorageOptions>();

            _fileManager = fileManager;
        }

        public async Task<FileItemDto> Handle(CreateCommand<FileItemCreateRequest, FileItemDto, FileItem, Guid> request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<FileItem>(request.Source);

            entity.CreationTime = DateTime.Now;

            HybridFileInfo fileInfo;

            do
            {
                entity.Path = PathHelper.NormalizePath(PathGenerator.GeneratePath(entity, _options));

                try
                {
                    fileInfo = await _fileManager.CreateFileFromStreamAsync(entity.Path, request.Source.FileStream);
                }
                catch (FileHasExistedException)
                {
                    throw;
                }
            } while (fileInfo == null);

            await _repository.AddAsync(entity);

            await _domainEventBus.PublishAsync(new CreatedEvent<FileItem>(entity));

            return _mapper.Map<FileItemDto>(entity);
        }
    }
}
