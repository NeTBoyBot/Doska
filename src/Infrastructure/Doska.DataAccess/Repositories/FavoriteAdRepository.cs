using Doska.AppServices.IRepository;
using Doska.Domain;
using Doska.Infrastructure.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.DataAccess.Repositories
{
    public class FavoriteAdRepository : IFavoriteAdRepository
    {
        public readonly IBaseRepository<FavoriteAd> _baseRepository;

        public FavoriteAdRepository(IBaseRepository<FavoriteAd> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task AddAsync(FavoriteAd model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(FavoriteAd model)
        {
            await _baseRepository.DeleteAsync(model);
        }

        public async Task EditFavoriteAdAsync(FavoriteAd edit)
        {
            await _baseRepository.UpdateAsync(edit);
        }

        public async Task<FavoriteAd> FindById(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public IQueryable<FavoriteAd> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
