using Leelite.DataCategory.Dtos.CategoryTypeDtos;
using Leelite.DataCategory.Models.CategoryTypeAgg;
using Leelite.Framework.Service;

namespace Leelite.DataCategory.Interfaces
{
    public interface ICategoryTypeService : ICrudService<CategoryType, int, CategoryTypeDto, CategoryTypeCreateRequest, CategoryTypeUpdateRequest, CategoryTypeQueryParameter>
    {
        /// <summary>
        /// ���ݱ����ȡ
        /// </summary>
        /// <param name="code">�������</param>
        /// <returns>������Ϣ</returns>
        CategoryTypeDto GetByCode(string code);

        /// <summary>
        /// �������ƻ�ȡ
        /// </summary>
        /// <param name="name">��������</param>
        /// <returns>������Ϣ</returns>
        CategoryTypeDto GetByName(string name);
    }
}
