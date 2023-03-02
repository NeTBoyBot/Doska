using AutoMapper;
using Doska.AppServices.IRepository;
using Doska.Contracts.AdDto;
using Doska.Contracts.FavoriteAdDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.FavoriteAd
{
    public class FavoriteAdService : IFavoriteAdService
    {
        public readonly IFavoriteAdRepository _favoriteadRepository;
        public readonly IMapper _mapper;

        public FavoriteAdService(IFavoriteAdRepository favoriteadRepository, IMapper mapper)
        {
            _favoriteadRepository = favoriteadRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateFavoriteAdAsync(InfoFavoriteAdResponse createAd)
        {
            var newAd = _mapper.Map<Domain.FavoriteAd>(createAd);
            
            await _favoriteadRepository.AddAsync(newAd);

            return newAd.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingad = await _favoriteadRepository.FindById(id);
            await _favoriteadRepository.DeleteAsync(existingad);
        }

        public async Task<IReadOnlyCollection<InfoFavoriteAdResponse>> GetAll(int take, int skip)
        {
            return await _favoriteadRepository.GetAll()
                .Select(a => new InfoFavoriteAdResponse
                {
                    AdId = a.AdId,
                    UserId = a.UserId
                }).OrderBy(a => a.AdId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<InfoFavoriteAdResponse> GetByIdAsync(Guid id)
        {
            var existingad = await _favoriteadRepository.FindById(id);
            return _mapper.Map<InfoFavoriteAdResponse>(existingad);
        }
    }
}
