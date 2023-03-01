using Doska.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.IRepository
{
    public interface ISubCategoryRepository
    {
        Task<Subcategory> FindById(Guid id);

        IQueryable<Subcategory> GetAll();

        public Task AddAsync(Subcategory model);

        Task DeleteAsync(Subcategory model);

        Task EditSubCategoryAsync(Subcategory edit);
    }
}
