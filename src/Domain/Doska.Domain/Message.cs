using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Domain
{
    public class Message
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        public Guid ChatId { get; set; }

        public User Sender { get; set; }

        public Chat Chat { get; set; }

        public string Containment { get; set; }
    }
}
