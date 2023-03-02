using Doska.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.IRepository
{
    public interface IFavoriteRepository
    {

        Task<Ad> FindById(Guid id);

        IQueryable<Ad> GetAll();

        public Task AddAsync(Ad model);

        Task DeleteAsync(Ad model);

        Task EditAdAsync(Ad edit);
    }
}
