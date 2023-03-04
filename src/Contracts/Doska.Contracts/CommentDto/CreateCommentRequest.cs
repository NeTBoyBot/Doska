using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Contracts.CommentDto
{
    public class CreateCommentRequest
    {
        public Guid UserId { get; set; }

        public string Containment {get; set; }
    }
}
