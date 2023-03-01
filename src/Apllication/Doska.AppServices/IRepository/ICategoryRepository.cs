using Doska.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.IRepository
{
    public interface ICategoryRepository
    {
        Task<Category> FindById(Guid id);

        IQueryable<Category> GetAll();

        public Task AddAsync(Category model);

        Task DeleteAsync(Category model);

        Task EditAdAsync(Category edit);
    }
}
