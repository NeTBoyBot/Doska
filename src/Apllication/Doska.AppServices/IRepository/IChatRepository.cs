using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doska.Domain;

namespace Doska.AppServices.IRepository
{
    public interface IChatRepository
    {
        Task<Chat> FindById(Guid id);

        IQueryable<Chat> GetAll();

        public Task AddAsync(Chat model);

        Task DeleteAsync(Chat model);
    }
}
