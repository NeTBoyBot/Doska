using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Contracts.Chat
{
    public class CreateChatRequest
    {
        public Guid InitializerId { get; set; }

        public Guid ParticipantId { get; set; }
    }
}
