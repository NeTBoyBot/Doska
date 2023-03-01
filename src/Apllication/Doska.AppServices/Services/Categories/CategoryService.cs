using AutoMapper;
using Doska.AppServices.IRepository;
using Doska.AppServices.Services.Categories;
using Doska.Contracts.AdDto;
using Doska.Contracts.CategoryDto;
using Doska.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.Ad
{
    public class CategoryService : ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateCategoryAsync(string categoryname)
        {
            var newCategory = new Domain.Category
            {
                Name = categoryname
            };
           
            await _categoryRepository.AddAsync(newCategory);

            return newCategory.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingCategory = await _categoryRepository.FindById(id);
            await _categoryRepository.DeleteAsync(existingCategory);
        }

        public async Task<InfoCategoryResponse> EditCategoryAsync(Guid Id, string categoryname)
        {
            var existingCategory = await _categoryRepository.FindById(Id);
            existingCategory.Name = categoryname;
            await _categoryRepository.EditAdAsync(existingCategory);

            return _mapper.Map<InfoCategoryResponse>(existingCategory);
        }

       

        public async Task<IReadOnlyCollection<InfoCategoryResponse>> GetAll(int take, int skip)
        {
            return await _categoryRepository.GetAll()
                .Select(a => new InfoCategoryResponse
                {
                    Id = a.Id,
                    Name = a.Name
                    
                }).OrderBy(a => a.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<InfoCategoryResponse> GetByIdAsync(Guid id)
        {
            var existingCategory = await _categoryRepository.FindById(id);
            return _mapper.Map<InfoCategoryResponse>(existingCategory);
        }

        
    }
}
