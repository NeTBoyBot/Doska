using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Domain
{
    public class Chat
    {
        public Guid Id { get; set; }

        public Guid InitializerId { get; set; }
                   
        public Guid ParticipantId { get; set; }

        public User Initializer { get; set; }

        //public User Participant { get; set; }

        public ICollection<Message> Messages { get; set; }

        
    }
}
