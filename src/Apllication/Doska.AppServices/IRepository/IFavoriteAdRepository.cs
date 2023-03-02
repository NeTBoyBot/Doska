using Doska.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.IRepository
{
    public interface IFavoriteAdRepository
    {
        Task<FavoriteAd> FindById(Guid id);

        IQueryable<FavoriteAd> GetAll();

        public Task AddAsync(FavoriteAd model);

        Task DeleteAsync(FavoriteAd model);

        Task EditFavoriteAdAsync(FavoriteAd edit);
    }
}
