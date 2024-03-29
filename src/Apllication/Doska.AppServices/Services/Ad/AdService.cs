﻿using AutoMapper;
using Doska.AppServices.IRepository;
using Doska.Contracts.AdDto;
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
    public class AdService : IAdService
    {
        public readonly IAdRepository _adRepository;
        public readonly IMapper _mapper;

        public AdService(IAdRepository adRepository,IMapper mapper)
        {
            _adRepository = adRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAdAsync(CreateOrUpdateAdRequest createAd)
        {
            var newAd = _mapper.Map<Domain.Ad>(createAd);
            newAd.CreateTime = DateTime.UtcNow;
            await _adRepository.AddAsync(newAd);

            return newAd.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingad = await _adRepository.FindById(id);
            await _adRepository.DeleteAsync(existingad);
        }

        public async Task<InfoAdResponse> EditAdAsync(Guid Id,CreateOrUpdateAdRequest editAd)
        {
            var existingAd = await _adRepository.FindById(Id);
            await _adRepository.EditAdAsync(_mapper.Map(editAd,existingAd));

            return _mapper.Map<InfoAdResponse>(editAd);
        }

        public async Task<IReadOnlyCollection<InfoAdResponse>> GetAll(int take, int skip)
        {
            return await _adRepository.GetAll()
                .Select(a=>new InfoAdResponse
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                UserId = a.UserId,
                SubcategoryId = (Guid)a.SubcategoryId,
                CreateTime = a.CreateTime
                }).OrderBy(a => a.CreateTime).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<InfoAdResponse> GetByIdAsync(Guid id)
        {
            var existingad = await _adRepository.FindById(id);
            return _mapper.Map<InfoAdResponse>(existingad);
        }
    }
}
