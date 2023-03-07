using Doska.Contracts.AdDto;
using Doska.Contracts.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.Categories
{
    public interface ICategoryService
    {
        Task<InfoCategoryResponse> GetByIdAsync(Guid id);

        Task<Guid> CreateCategoryAsync(CreateCategoryRequest request);

        Task<IReadOnlyCollection<InfoCategoryResponse>> GetAll(int take, int skip);

        Task DeleteAsync(Guid id);

        Task<InfoCategoryResponse> EditCategoryAsync(Guid Id, string categoryname);
    }
}
