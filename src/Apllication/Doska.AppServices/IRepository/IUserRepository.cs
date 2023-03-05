using Doska.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.IRepository
{
    public interface IUserRepository
    {
        Task<User> FindWhere(Expression<Func<User, bool>> predicate, CancellationToken token);

        Task<User> FindById(Guid id);

        IQueryable<User> GetAll();

        public Task AddAsync(User model);

        Task DeleteAsync(User model);

        Task EditUserAsync(User edit);

    }
}
