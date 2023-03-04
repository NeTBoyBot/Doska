using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doska.Domain;

namespace Doska.AppServices.IRepository
{
    public interface IMessageRepository
    {
        Task<Message> FindById(Guid id);

        IQueryable<Message> GetAll();

        public Task AddAsync(Message model);

        Task DeleteAsync(Message model);
    }
}
