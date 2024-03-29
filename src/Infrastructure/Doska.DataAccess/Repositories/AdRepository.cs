﻿using Doska.AppServices.IRepository;
using Doska.Domain;
using Doska.Infrastructure.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.DataAccess.Repositories
{
    public class AdRepository : IAdRepository
    {
        public readonly IBaseRepository<Ad> _baseRepository;

        public AdRepository(IBaseRepository<Ad> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task AddAsync(Ad model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(Ad model)
        {
            await _baseRepository.DeleteAsync(model);
        }

        public async Task EditAdAsync(Ad edit)
        {
            await _baseRepository.UpdateAsync(edit);
        }

        public async Task<Ad> FindById(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public IQueryable<Ad> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
