using AutoMapper;
using Doska.AppServices.IRepository;
using Doska.Contracts.CategoryDto;
using Doska.Contracts.SubCategoryDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.SubCategories
{
    public class SubCategoryService : ISubCategoryService
    {
        public readonly ISubCategoryRepository _subcategoryRepository;
        public readonly IMapper _mapper;

        public SubCategoryService(ISubCategoryRepository subcategoryRepository, IMapper mapper)
        {
            _subcategoryRepository = subcategoryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateSubCategoryAsync(string categoryname, Guid CategoryId)
        {
            var newCategory = new Domain.Subcategory
            {
                Name = categoryname,
                CategoryId = CategoryId
            };

            await _subcategoryRepository.AddAsync(newCategory);

            return newCategory.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingCategory = await _subcategoryRepository.FindById(id);
            await _subcategoryRepository.DeleteAsync(existingCategory);
        }

        public async Task<InfoSubCategoryResponse> EditSubCategoryAsync(Guid Id, string categoryname, Guid? CategoryId)
        {
            var existingCategory = await _subcategoryRepository.FindById(Id);
            existingCategory.Name = categoryname;
            existingCategory.CategoryId = (Guid)(CategoryId != null ? CategoryId : existingCategory.CategoryId);
            await _subcategoryRepository.EditSubCategoryAsync(existingCategory);

            return _mapper.Map<InfoSubCategoryResponse>(existingCategory);
        }

        public async Task<IReadOnlyCollection<InfoSubCategoryResponse>> GetAll(int take, int skip)
        {
            return await _subcategoryRepository.GetAll()
                 .Select(a => new InfoSubCategoryResponse
                 {
                     Id = a.Id,
                     Name = a.Name

                 }).OrderBy(a => a.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<InfoSubCategoryResponse> GetByIdAsync(Guid id)
        {
            var existingCategory = await _subcategoryRepository.FindById(id);
            return _mapper.Map<InfoSubCategoryResponse>(existingCategory);
        }
    }
}
