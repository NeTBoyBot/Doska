using Doska.Contracts.FavoriteAdDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.FavoriteAd
{
    public interface IFavoriteAdService
    {
        Task<InfoFavoriteAdResponse> GetByIdAsync(Guid id);

        Task<Guid> CreateFavoriteAdAsync(InfoFavoriteAdResponse createAd);

        Task<IReadOnlyCollection<InfoFavoriteAdResponse>> GetAll(int take, int skip);

        Task DeleteAsync(Guid id);
    }
}
