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
    public class CommentRepository : ICommentRepository
    {
        public readonly IBaseRepository<Comment> _baseRepository;

        public CommentRepository(IBaseRepository<Comment> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public Task AddAsync(Comment model)
        {
            return _baseRepository.AddAsync(model);
        }

        public async Task DeleteAsync(Comment model)
        {
            await _baseRepository.DeleteAsync(model);
        }

        public async Task EditCommentAsync(Comment edit)
        {
            await _baseRepository.UpdateAsync(edit);
        }

        public async Task<Comment> FindById(Guid id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public IQueryable<Comment> GetAll()
        {
            return _baseRepository.GetAll();
        }
    }
}
