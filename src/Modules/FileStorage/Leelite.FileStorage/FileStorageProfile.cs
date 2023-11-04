using AutoMapper;

using Leelite.FileStorage.Dtos.FileItemDtos;
using Leelite.FileStorage.Models.FileItemAgg;

namespace Leelite.FileStorage
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
