using Doska.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.IRepository
{
    public interface IUserRepository
    {
        Task<User> FindById(Guid id);

        IQueryable<User> GetAll();

        public Task AddAsync(User model);

        Task DeleteAsync(User model);

        Task EditUserAsync(User edit);

    }
}
