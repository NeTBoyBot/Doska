using AutoMapper;
using Doska.AppServices.IRepository;
using Doska.Contracts.Message;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.Message
{
    public class MessageService : IMessageService
    {
        public readonly IMessageRepository _messageRepository;
        public readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateMessageAsync(CreateMessageRequest createMessage)
        {
            var newMessage = _mapper.Map<Domain.Message>(createMessage);
            await _messageRepository.AddAsync(newMessage);

            return newMessage.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingMessage = await _messageRepository.FindById(id);
            await _messageRepository.DeleteAsync(existingMessage);
        }

        public async Task<IReadOnlyCollection<InfoMessageResponse>> GetAll(int take, int skip)
        {
            return await _messageRepository.GetAll()
                .Select(a => new InfoMessageResponse
                {
                    Id = a.Id,
                    ChatId = a.ChatId,
                    SenderId = a.SenderId,
                    Containment = a.Containment
                }).OrderBy(a => a.Id).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<InfoMessageResponse> GetByIdAsync(Guid id)
        {
            var existingchat = await _messageRepository.FindById(id);
            return _mapper.Map<InfoMessageResponse>(existingchat);
        }
    }
}
