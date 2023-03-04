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
    public class MessageRepository : IMessageRepository
    {
        public readonly IBaseRepository<Message> _baseRepository;

        public MessageRepository(IBaseRepository<Message> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task AddAsync(Message model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(Message model)
        {
            await _baseRepository.DeleteAsync(model);
        }

        public async Task EditAdAsync(Message edit)
        {
            await _baseRepository.UpdateAsync(edit);
        }

        public async Task<Message> FindById(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public IQueryable<Message> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
