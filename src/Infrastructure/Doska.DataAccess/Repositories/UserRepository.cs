using Doska.AppServices.IRepository;
using Doska.Domain;
using Doska.Infrastructure.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Doska.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly IBaseRepository<User> _baseRepository;

        public UserRepository(IBaseRepository<User> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task AddAsync(User model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(User model)
        {
            await _baseRepository.DeleteAsync(model);
        }

        public async Task EditUserAsync(User edit)
        {
            await _baseRepository.UpdateAsync(edit);
        }

        public async Task<User> FindById(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public async Task<User> FindWhere(Expression<Func<User, bool>> predicate, CancellationToken token)
        {
            var data = _baseRepository.GetAllFiltered(predicate);

            return await data.Where(predicate).FirstOrDefaultAsync(token);
        }

        public IQueryable<User> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
