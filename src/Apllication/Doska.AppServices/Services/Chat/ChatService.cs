using AutoMapper;
using Doska.AppServices.IRepository;
using Doska.AppServices.Services.User;
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
        public readonly IUserService _userService;

        public ChatService(IChatRepository chatRepository, IMapper mapper, IUserService userService)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Guid> CreateChatAsync(CreateChatRequest createChat)
        {
            var newChat = _mapper.Map<Domain.Chat>(createChat);
            //newChat.Id = Guid.NewGuid();
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
                    ParticipantId = a.ParticipantId,
                    Messages = a.Messages.Select(s=>s.Containment).ToList()
                }).OrderBy(a => a.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IReadOnlyCollection<InfoChatResponse>> GetAllChatsForUser(Guid UserId)
        {
            return await _chatRepository.GetAll()
                .Where(c=>c.InitializerId == UserId)
                .Select(a => new InfoChatResponse
                {
                    Id = a.Id,
                    InitializerId = a.InitializerId,
                    ParticipantId = a.ParticipantId,
                    Messages = a.Messages.Select(s => s.Containment).ToList()
                }).OrderBy(a => a.Id).ToListAsync();
        }

        public async Task<IReadOnlyCollection<InfoChatResponse>> GetAllUserChats(int take, int skip, CancellationToken token)
        {
            var userId = await _userService.GetCurrentUserId(token);
            return await _chatRepository.GetAll().Where(a => a.InitializerId == userId || a.ParticipantId == userId)
                .Select(s => new InfoChatResponse
                {
                    Id = s.Id,
                    InitializerId = s.InitializerId,
                    ParticipantId = s.ParticipantId,   
                    Messages = s.Messages.Select(s=>s.Containment).ToList()
                    
                }).Take(take).Skip(skip).ToListAsync();
        }

        public async Task<InfoChatResponse> GetByIdAsync(Guid id)
        {
            var existingchat = await _chatRepository.FindById(id);
            return _mapper.Map<InfoChatResponse>(existingchat);
        }
    }
}
