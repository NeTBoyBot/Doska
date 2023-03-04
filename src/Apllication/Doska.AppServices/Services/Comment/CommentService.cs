using AutoMapper;
using Doska.AppServices.IRepository;
using Doska.Contracts.CommentDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.Comment
{
    public class CommentService : ICommentService
    {
        public readonly ICommentRepository _commentRepository;
        public readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateCommentAsync(CreateCommentRequest createChat)
        {
            var newChat = _mapper.Map<Domain.Comment>(createChat);
            //newChat.Id = Guid.NewGuid();
            await _commentRepository.AddAsync(newChat);

            return newChat.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingChat = await _commentRepository.FindById(id);
            await _commentRepository.DeleteAsync(existingChat);
        }

        public async Task<IReadOnlyCollection<InfoCommentResponse>> GetAll(int take, int skip)
        {
            return await _commentRepository.GetAll()
                .Select(a => new InfoCommentResponse
                {
                    Id = a.Id,
                    UserId = a.UserId,
                    Containment = a.Containment
                }).OrderBy(a => a.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<InfoCommentResponse> GetByIdAsync(Guid id)
        {
            var existingchat = await _commentRepository.FindById(id);
            return _mapper.Map<InfoCommentResponse>(existingchat);
        }
    }
}
