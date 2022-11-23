using AutoMapper;

using Leelite.Modules.FileStorage.Dtos.FileItemDtos;
using Leelite.Modules.FileStorage.Models.FileItemAgg;

namespace Leelite.Modules.FileStorage
{
    public class FileStorageProfile : Profile
    {
        public FileStorageProfile()
        {
            CreateMap<FileItem, FileItemDto>();
            CreateMap<FileItemCreateRequest, FileItem>();
            CreateMap<FileItemUpdateRequest, FileItem>();
        }
    }
}
