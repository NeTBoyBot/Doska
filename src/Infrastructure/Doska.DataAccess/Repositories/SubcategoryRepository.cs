using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doska.AppServices.IRepository;
using Doska.Domain;
using Doska.Infrastructure.BaseRepository;

namespace Doska.DataAccess.Repositories
{
    public class SubcategoryRepository : ISubCategoryRepository
    {
        public readonly IBaseRepository<Subcategory> _baseRepository;

        public SubcategoryRepository(IBaseRepository<Subcategory> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task AddAsync(Subcategory model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(Subcategory model)
        {
            await _baseRepository.DeleteAsync(model);
        }

        public async Task EditSubCategoryAsync(Subcategory edit)
        {
            await _baseRepository.UpdateAsync(edit);
        }

        public async Task<Subcategory> FindById(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public IQueryable<Subcategory> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
