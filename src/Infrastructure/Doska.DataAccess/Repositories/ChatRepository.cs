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
    public class ChatRepository : IChatRepository
    {
        public readonly IBaseRepository<Chat> _baseRepository;

        public ChatRepository(IBaseRepository<Chat> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task AddAsync(Chat model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(Chat model)
        {
            await _baseRepository.DeleteAsync(model);
        }

        public async Task EditAdAsync(Chat edit)
        {
            await _baseRepository.UpdateAsync(edit);
        }

        public async Task<Chat> FindById(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public IQueryable<Chat> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
