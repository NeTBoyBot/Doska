using Doska.Contracts.AdDto;
using Doska.Contracts.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.Chat
{
    public interface IChatService
    {
        Task<InfoChatResponse> GetByIdAsync(Guid id);

        Task<Guid> CreateChatAsync(CreateChatRequest createAd);

        Task<IReadOnlyCollection<InfoChatResponse>> GetAll(int take, int skip);

        Task DeleteAsync(Guid id);

        Task<IReadOnlyCollection<InfoChatResponse>> GetAllChatsForUser(Guid UserId);

        Task<IReadOnlyCollection<InfoChatResponse>> GetAllUserChats(int take, int skip, CancellationToken token);
    }
}
