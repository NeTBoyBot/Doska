using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Contracts.Message
{
    public class InfoMessageResponse
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        public Guid ChatId { get; set; }

        public string Containment { get; set; }
    }
}
