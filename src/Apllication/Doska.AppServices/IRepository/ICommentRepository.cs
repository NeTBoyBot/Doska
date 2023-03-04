using Doska.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.IRepository
{
    public interface ICommentRepository
    {
        Task<Comment> FindById(Guid id);

        IQueryable<Comment> GetAll();

        public Task AddAsync(Comment model);

        Task DeleteAsync(Comment model);
    }
}
