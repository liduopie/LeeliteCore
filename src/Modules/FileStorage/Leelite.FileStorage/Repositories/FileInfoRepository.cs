using System;

using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.FileStorage.Contexts;
using Leelite.FileStorage.Models.FileItemAgg;

namespace Leelite.FileStorage.Repositories
{
    public interface IFileInfoRepository : IRepository<FileItem, Guid>
    {
    }

    public class FileInfoRepository : EFRepository<FileItem, Guid>, IFileInfoRepository
    {
        public FileInfoRepository(FileStorageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
