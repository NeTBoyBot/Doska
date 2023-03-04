using AutoMapper;
using Doska.AppServices.IRepository;
using Doska.Contracts.AdDto;
using Doska.Contracts.Chat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.Chat
{
    public class ChatService : IChatService
    {
        public readonly IChatRepository _chatRepository;
        public readonly IMapper _mapper;

        public ChatService(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateChatAsync(CreateChatRequest createChat)
        {
            var newChat = _mapper.Map<Domain.Chat>(createChat);
            newChat.Id = Guid.NewGuid();
            await _chatRepository.AddAsync(newChat);

            return newChat.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingChat = await _chatRepository.FindById(id);
            await _chatRepository.DeleteAsync(existingChat);
        }

        public async Task<IReadOnlyCollection<InfoChatResponse>> GetAll(int take, int skip)
        {
            return await _chatRepository.GetAll()
                .Select(a => new InfoChatResponse
                {
                    Id = a.Id,
                    InitializerId = a.InitializerId,
                    ParticipantId = a.ParticipantId
                }).OrderBy(a => a.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<InfoChatResponse> GetByIdAsync(Guid id)
        {
            var existingchat = await _chatRepository.FindById(id);
            return _mapper.Map<InfoChatResponse>(existingchat);
        }
    }
}
