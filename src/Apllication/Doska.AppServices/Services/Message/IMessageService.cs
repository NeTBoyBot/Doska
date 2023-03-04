using Doska.Contracts.Chat;
using Doska.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.Services.Message
{
    public interface IMessageService
    {
        Task<InfoMessageResponse> GetByIdAsync(Guid id);

        Task<Guid> CreateMessageAsync(CreateMessageRequest createAd);

        Task<IReadOnlyCollection<InfoMessageResponse>> GetAll(int take, int skip);

        Task DeleteAsync(Guid id);
    }
}
