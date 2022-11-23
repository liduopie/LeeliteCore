using System;

using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.FileStorage.Contexts;
using Leelite.Modules.FileStorage.Models.FileItemAgg;

namespace Leelite.Modules.FileStorage.Repositories
{
    public interface IFileInfoRepository : IRepository<FileItem, Guid>
    {
    }

    public class FileInfoRepository : EFRepository<FileItem, Guid>, IFileInfoRepository
    {
        public FileInfoRepository(FileStorageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
