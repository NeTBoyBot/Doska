using Doska.Contracts.SubCategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.SubCategories
{
    public interface ISubCategoryService
    {
        Task<InfoSubCategoryResponse> GetByIdAsync(Guid id);

        Task<Guid> CreateSubCategoryAsync(string categoryname, Guid CategoryId);

        Task<IReadOnlyCollection<InfoSubCategoryResponse>> GetAll(int take, int skip);

        Task DeleteAsync(Guid id);

        Task<InfoSubCategoryResponse> EditSubCategoryAsync(Guid Id, string categoryname, Guid? CategoryId);
    }
}
